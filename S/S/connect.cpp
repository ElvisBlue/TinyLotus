#include <winsock2.h>
#include <WS2tcpip.h>
#include <windows.h>
#include "connect.h"

#pragma comment (lib, "Ws2_32.lib")


Connection::Connection(char* mIP, int mPort)
{
	IP = mIP;
	Port = mPort;
	bConnected = false;
	s = NULL;
	wsaData = { 0 };
}

Connection::~Connection() 
{
	CloseConnection();
}

bool Connection::CloseConnection()
{
	if (s != NULL)
	{
		closesocket(s);
		WSACleanup();
		s = NULL;
	}
	return true;
}

bool Connection::IsConnected()
{
	return bConnected;
}

bool Connection::Connect()
{
	if (WSAStartup(MAKEWORD(2,2), &wsaData) != 0)
		return false;

	if ((s = socket(AF_INET, SOCK_STREAM, 0)) == INVALID_SOCKET)
		return false;

	struct sockaddr_in server = {0};
	unsigned long ip_addr = inet_addr(IP);
	if (ip_addr == INADDR_NONE)
	{
		struct hostent* host;
		host = gethostbyname(IP);
		ip_addr = *((unsigned long*)host->h_addr);
	}
	server.sin_addr.s_addr = ip_addr;
    server.sin_family = AF_INET;
    server.sin_port = htons(Port);

	if (connect(s, (struct sockaddr*)&server, sizeof(server)) < 0)
    {
        WSACleanup();
        return false;
    }
	bConnected = true;
	return true;
}

bool Connection::SendRawPacket(BYTE* packetData, size_t packetSize)
{
	bool ret;
	//Well let do a simple compression
	uLong src_len = (uLong)packetSize;
	uLong cmp_len = compressBound(src_len);
	uLong uncomp_len = src_len;
	unsigned char *pCmp, *pUncomp;

	pCmp = (unsigned char *)malloc((size_t)cmp_len);
	if (!pCmp)
		return false;

    pUncomp = (unsigned char *)malloc((size_t)src_len);
	if (!pCmp)
	{
		free(pCmp);
		return false;
	}

	if (compress(pCmp, &cmp_len, (const unsigned char *)packetData, src_len) != Z_OK)
	{
		free(pCmp);
		free(pUncomp);
		return false;
	}

	//Build raw packet header
	size_t RawPacketSize = cmp_len + sizeof(RawPacketHeader);
	RawPacketHeader* RawPacket = (RawPacketHeader*)malloc(RawPacketSize);
	RawPacket->Header = TINY_LOTUS_HEADER;
	RawPacket->compressedPacketSize = cmp_len;
	RawPacket->originalPacketSize = packetSize;
	memcpy((BYTE*)RawPacket + sizeof(RawPacketHeader), pCmp, cmp_len);

	int sendbytes;
	unsigned int totalSend = 0;

	ret = true;
	do
	{
		sendbytes = send(s, (char*)(RawPacket + totalSend), cmp_len + sizeof(RawPacketHeader) - totalSend, 0);
		if (sendbytes == SOCKET_ERROR)
		{
			if (WSAGetLastError() == WSAECONNRESET)
			{
				closesocket(s);
				WSACleanup();
				bConnected = false;
			}
			ret = false;
			break;
		}
		totalSend += sendbytes;
		Sleep(1);
	}
	while(totalSend < (cmp_len + sizeof(RawPacketHeader)));

	free(pCmp);
	free(pUncomp);
	free(RawPacket);
	return ret;
}

bool Connection::RecvRawPacket(BYTE* &packetBuffer, size_t* pBufferSize)
{
	bool ret = false;

	if (packetBuffer == NULL)
		return false;

	RawPacketHeader* Header = (RawPacketHeader*)malloc(sizeof(RawPacketHeader));

	//Could be error if connection too slow
	int iResult = recv(s, (char*)Header, sizeof(RawPacketHeader), NULL);
	if ((iResult != SOCKET_ERROR) && (iResult > 0))
	{
		if (Header->Header == TINY_LOTUS_HEADER)
		{
			//Perform decompress data
			BYTE* compressedBuffer = (BYTE*)malloc(Header->compressedPacketSize);

			int totalSize = Header->compressedPacketSize;
			int receivedSize = 0;
			int chunkSize = 0;

			while (receivedSize < totalSize)
			{
				chunkSize = recv(s, (char*)compressedBuffer + receivedSize, totalSize - receivedSize, NULL);
				if (chunkSize == SOCKET_ERROR)
				{
					free(compressedBuffer);
					free(Header);
					return false;
				}
				receivedSize += chunkSize;
				Sleep(1);
			}


			if (*pBufferSize < Header->originalPacketSize)
			{
				//re alloc memory
				free(packetBuffer);
				packetBuffer = (BYTE*)malloc(Header->originalPacketSize);
				*pBufferSize = Header->originalPacketSize;
			}

			uLong destSize = *pBufferSize;
			if (uncompress(packetBuffer, &destSize, compressedBuffer, Header->compressedPacketSize) == Z_OK)
				ret = true;
			else
				ret = false;

			free(compressedBuffer);
			free(Header);
			return ret;
		}
	}


	closesocket(s);
	WSACleanup();
	bConnected = false;

	free(Header);
	return false;
}