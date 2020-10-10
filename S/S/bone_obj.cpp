#include <Windows.h>
#include "bone_obj.h"

bool BoneObj::SendPacket(BYTE* packetData, size_t packetSize)
{
	size_t FullPacketSize = packetSize + sizeof(PacketHeader);
	PacketHeader* dataToSent = (PacketHeader*)malloc(FullPacketSize);
	dataToSent->objID = objID;
	dataToSent->PacketSize = packetSize;
	memcpy((BYTE*)dataToSent + sizeof(PacketHeader), packetData, packetSize);
	ConnObj->SendRawPacket((BYTE*)dataToSent, FullPacketSize);
	free(dataToSent);
	return true;
}