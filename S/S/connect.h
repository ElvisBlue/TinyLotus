#ifndef CONNECTION_H
#define CONNECTION_H

#include <Windows.h>
//#include "miniz/miniz.h"
#include "zlib/zlib.h"

#pragma comment(lib, "lib/zlibstat.lib")

#define	TINY_LOTUS_HEADER		0xCAFEBABE

#pragma pack(push, 1)
struct RawPacketHeader
{
	DWORD	Header;					//0xCAFEBABE
	size_t	compressedPacketSize;
	size_t	originalPacketSize;
};
#pragma pack(pop)

struct PacketHeader
{
	DWORD	objID;
	DWORD	PacketSize;
};

class Connection
{
public:
	bool	IsConnected();
	bool	SendRawPacket(BYTE*, size_t);
	bool	Connect();
	bool	CloseConnection();
	bool	RecvRawPacket(BYTE*&, size_t*);
	Connection(char*, int);
	~Connection();
private:
	int		Port;
	char*	IP;
	bool	bConnected;

	//Winsock stuff
	WSADATA wsaData;
	SOCKET  s;
};
#endif