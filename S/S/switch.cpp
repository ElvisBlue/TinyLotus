#define _CRT_SECURE_NO_WARNINGS

#include "switch.h"
#include <Windows.h>

#define SWITCH_CLOSE			0
#define SWITCH_TERMINATE		1
#define SWITCH_ACCEPTPASSWORD	2

Switch::Switch(Connection* mConnObj, char* m_password)
{
	ConnObj = mConnObj;
	bIsServerAccepted = false;
	bClose = false;
	password = m_password;
}

Switch::~Switch() {}

void Switch::OnInit()
{
	objID = 5;
}

bool Switch::SendPasswordPacket()
{
	size_t packetSize = 2 + strlen(password);
	BYTE* packet = (BYTE*)malloc(packetSize);
	ZeroMemory(packet, packetSize);
	packet[0] = 0; //ID for authen password
	strcpy((char*)(packet + 1), this->password);
	bool ret = SendPacket(packet, packetSize);
	free(packet);
	return ret;
}

bool Switch::IsServerAccepted()
{
	return this->bIsServerAccepted;
}

void Switch::OnPacketArrived(BYTE* PacketData, size_t Size)
{
	switch (PacketData[0])
	{
	case SWITCH_CLOSE:
		bClose = true;
		break;
	case SWITCH_TERMINATE:
		ExitProcess(0);
		break;
	case SWITCH_ACCEPTPASSWORD:
		this->bIsServerAccepted = true;
		break;
	}
}

void Switch::OnExit()
{

}

bool Switch::IsCloseSignature()
{
	return bClose;
}