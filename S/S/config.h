#ifndef CONFIG_H
#define CONFIG_H

#pragma pack(push, 1)
struct config
{
	DWORD	Signature[2];
	WCHAR	ClientTag[20];
	char	hostIP[40];
	int		port;
	WCHAR	mutex[30];
	bool	startupWithWindow;
	char	startupRegistryKeyName[30];
};
#pragma pack(pop)

#endif