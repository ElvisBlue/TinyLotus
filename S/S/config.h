#ifndef CONFIG_H
#define CONFIG_H

#pragma pack(push, 1)
struct config
{
	DWORD	Signature[2];
	WCHAR	ClientTag[20];
	char	hostIP[50];
	char	password[20];
	int		port;
};
#pragma pack(pop)

#endif