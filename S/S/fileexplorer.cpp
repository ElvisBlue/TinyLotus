#include "fileexplorer.h"

void CALLBACK DownloadThread(DownloadInfo* downloadInfoPtr)
{
	//TODO: Consider to write a file stream class???
	wchar_t* filePath = downloadInfoPtr->filePath;
	FileExplorer* fileExplorerObj = (FileExplorer*)downloadInfoPtr->fileExplorerObj;

	HANDLE hFile = CreateFile(filePath, FILE_GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hFile == INVALID_HANDLE_VALUE)
	{
		DWORD sendBack[2] = {0};
		sendBack[0] = FILE_ERROR;
		sendBack[1] = FILE_ERROR_DOWNLOAD;
		fileExplorerObj->SendPacket((BYTE*)&sendBack, sizeof(sendBack));
		free(downloadInfoPtr);
		return;
	}

	#pragma pack(push, 1)
	struct DownloadHeader
	{
		DWORD	ID;
		DWORD	Session;
		DWORD	totalSize;
		DWORD	sizeLeft;
		DWORD	chunkSize;
	};
	#pragma pack(pop)

	DWORD fileSize = GetFileSize(hFile, NULL);
	DWORD sizeLeft = fileSize;
	BYTE* chunk = NULL;
	while (chunk == NULL)
	{
		chunk = (BYTE*)malloc(DOWNLOAD_CHUNK_SIZE + sizeof(DownloadHeader));
		Sleep(100);
	}
	ZeroMemory(chunk, DOWNLOAD_CHUNK_SIZE + sizeof(DownloadHeader));
	DWORD status = FILE_DOWNLOAD_BEGIN;
	DWORD session = downloadInfoPtr->session;

	while(sizeLeft)
	{
		DWORD readSize;
		DWORD dwBytesRead;
		if (sizeLeft <= DOWNLOAD_CHUNK_SIZE)
		{
			readSize = sizeLeft;
			status = FILE_DOWNLOAD_END;
		}
		else
			readSize = DOWNLOAD_CHUNK_SIZE;
		ReadFile(hFile, chunk + sizeof(DownloadHeader), readSize, &dwBytesRead, NULL);
		sizeLeft -= dwBytesRead;

		//Build header
		DownloadHeader* Header = (DownloadHeader*)chunk;
		Header->ID = status;
		Header->Session = session;
		Header->chunkSize = dwBytesRead;
		Header->sizeLeft = sizeLeft;
		Header->totalSize = fileSize;

		if (!fileExplorerObj->SendPacket(chunk, dwBytesRead + sizeof(DownloadHeader)))
			break; // Break if send packet fail. Exit thread to return system resource

		if (status != FILE_DOWNLOAD_END)
			status = FILE_DOWNLOAD_PROGRESS;

		Sleep(5);
	}
	CloseHandle(hFile);
	free(chunk);
	free(downloadInfoPtr);
	return;
}

void WIN32_FIND_DATA_To_Lite(WIN32_FIND_DATA* src, LITE_WIN32_FIND_DATA* dst)
{
	wcscpy(dst->cFileName, src->cFileName);
	dst->ftCreationTime = src->ftCreationTime;
	dst->ftLastWriteTime = src->ftLastWriteTime;
	dst->nFileSizeHigh = src->nFileSizeHigh;
	dst->nFileSizeLow = src->nFileSizeLow;
	dst->isFolder = (src->dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) ? 1 : 0;
}

FileExplorer::FileExplorer(Connection* mConnObj)
{
	ConnObj = mConnObj;
}

FileExplorer::~FileExplorer()
{

}

void FileExplorer::OnInit()
{
	//Set obj id
	objID = 3;
}

void FileExplorer::OnExit()
{

}

void FileExplorer::OnPacketArrived(BYTE* packet, size_t packetSize)
{
	switch(*(DWORD*)packet)
	{
	case FILE_LIST_ALL_DISK:
		{
			struct FILE_LIST_ALL_DISK_RESULT
			{
				DWORD	ID;
				DWORD	uDriveMask;
			};
			FILE_LIST_ALL_DISK_RESULT Buffer;
			ZeroMemory((void*)&Buffer, sizeof(Buffer));
			Buffer.uDriveMask = GetLogicalDrives();
			Buffer.ID = FILE_LIST_ALL_DISK; // Set ID
			SendPacket((BYTE*)&Buffer, sizeof(Buffer));
			break;
		}
	//File Browser Protocol
	//DWORD: ID
	//DWORD: Size of wide string
	//WCHAR[]: Wide String
	case FILE_BROWSER_FOLDER:
		{
			#pragma pack(push, 1)
			struct FILE_BROWSER_FOLDER_RESULT
			{
				DWORD					ID;
				DWORD					NumerOfItems;
				DWORD					Session;
				WCHAR					CurrentPath[MAX_PATH];
				LITE_WIN32_FIND_DATA	Data[100];
			};
			#pragma pack(pop)

			WIN32_FIND_DATA FindFileData;
			HANDLE hFind;

			//Prepare result data
			FILE_BROWSER_FOLDER_RESULT* sendData = (FILE_BROWSER_FOLDER_RESULT*)malloc(sizeof(FILE_BROWSER_FOLDER_RESULT));
			ZeroMemory(sendData, sizeof(FILE_BROWSER_FOLDER_RESULT));
			sendData->ID = FILE_BROWSER_FOLDER;
			sendData->NumerOfItems = 0;
			wcscpy(sendData->CurrentPath, (WCHAR*)(packet + 8));
			sendData->Session = Utilities::Random();

			//Process file
			ZeroMemory(&sendData->Data, sizeof(sendData->Data));
			WCHAR filePath[MAX_PATH+5];
			wcscpy(filePath, sendData->CurrentPath);
			wcscat(filePath, L"*.*");

			hFind = FindFirstFile(filePath, &FindFileData);
			if (hFind == INVALID_HANDLE_VALUE)
			{
				DWORD sendBack[2] = {0};
				sendBack[0] = FILE_ERROR;
				sendBack[1] = FILE_ERROR_BROWSER;
				SendPacket((BYTE*)&sendBack, sizeof(sendBack));
				free(sendData);
				break;
			}

			//Get first file data
			WIN32_FIND_DATA_To_Lite(&FindFileData, &sendData->Data[sendData->NumerOfItems]);
			sendData->NumerOfItems++;

			while (FindNextFile(hFind, &FindFileData) != 0)
			{
				//Get next file data
				WIN32_FIND_DATA_To_Lite(&FindFileData, &sendData->Data[sendData->NumerOfItems]);
				sendData->NumerOfItems++;
				if (sendData->NumerOfItems >= 100)
				{
					SendPacket((BYTE*)sendData, sizeof(FILE_BROWSER_FOLDER_RESULT));
					ZeroMemory(&sendData->Data, sizeof(sendData->Data));
					sendData->NumerOfItems = 0;
				}
			}
			SendPacket((BYTE*)sendData, sizeof(FILE_BROWSER_FOLDER_RESULT) - (100 - sendData->NumerOfItems)*sizeof(LITE_WIN32_FIND_DATA));
			FindClose(hFind);
			free(sendData);
			break;
		}
	case FILE_UPLOAD_BEGIN:
		{
			#pragma pack(push, 1)
			struct UploadBeginHeader
			{
				DWORD	ID;
				DWORD	Session;
				DWORD	sizeOfPath;
				wchar_t	Path;
			};
			#pragma pack(pop)
			UploadBeginHeader* Header = (UploadBeginHeader*)packet;
			DWORD Session = Header->Session;
			wchar_t* filePath = &Header->Path;

			Uploader* uploadItem = new Uploader(filePath, Session);
			if (!uploadItem->StartUpload())
			{
				#pragma pack(push, 1)
				struct UploadFailedResultHeader
				{
					DWORD	ID;
					DWORD	ErrorCode;
					DWORD	Session;
				};
				#pragma pack(pop)
				UploadFailedResultHeader sendBack;
				sendBack.ID = FILE_ERROR;
				sendBack.ErrorCode = FILE_ERROR_UPLOAD;
				sendBack.Session = Session;
				SendPacket((BYTE*)&sendBack, sizeof(sendBack));
				delete uploadItem;
				break;
			}
			else
				listOfUploadItems.push_back(uploadItem);

			break;
		}
	case FILE_UPLOAD_PROGRESS:
		{
			UploadHeader* Header = (UploadHeader*)packet;
			Uploader* currentUploader = NULL;
			std::list<Uploader*>::iterator it;
			//Refresh upload list. Revoke idle upload packet
			for (it = listOfUploadItems.begin(); it != listOfUploadItems.end(); ++it)
			{
				if (GetTickCount() - 120000 > (*it)->GetLastPacketTick())
				{
					(*it)->FinishUpload();
					it = listOfUploadItems.erase(it);
				}
			}

			for (it = listOfUploadItems.begin(); it != listOfUploadItems.end(); ++it)
				if ((*it)->GetSession() == Header->Session)
				{
					currentUploader = *it;
					break;
				}
			
			if (currentUploader != NULL)
			{
				currentUploader->Uploading(packet, packetSize);
			}
			break;
		}
	case FILE_UPLOAD_END:
		{
			struct UploadEndHeader
			{
				DWORD	ID;
				DWORD	Session;
			};
			UploadEndHeader* Header = (UploadEndHeader*)packet;
			Uploader* currentUploader = NULL;
			std::list<Uploader*>::iterator it;
			for (it = listOfUploadItems.begin(); it != listOfUploadItems.end(); ++it)
				if ((*it)->GetSession() == Header->Session)
				{
					currentUploader = *it;
					it = listOfUploadItems.erase(it);
					break;
				}
			if (currentUploader)
				currentUploader->FinishUpload();
			delete currentUploader;
			break;
		}
	case FILE_DOWNLOAD_BEGIN:
		{
			#pragma pack(push, 1)
			struct DownloadBeginHeader
			{
				DWORD	ID;
				DWORD	Session;
				DWORD	sizeOfPath;
				wchar_t	Path;
			};
			#pragma pack(pop)
			DownloadBeginHeader* Header = (DownloadBeginHeader*)packet;
			DownloadInfo* downloadInfoPtr = (DownloadInfo*)malloc(sizeof(DownloadInfo));
			downloadInfoPtr->fileExplorerObj = this;
			wcscpy_s(downloadInfoPtr->filePath, &Header->Path);
			downloadInfoPtr->session = Header->Session;
			CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)DownloadThread, downloadInfoPtr, NULL, NULL);
			break;
		}
	case FILE_DELETE:
		{
			DWORD strSize = *(DWORD*)(packet + 4);
			DeleteFile((WCHAR*)(packet + 8)); 
			break;
		}
	case FILE_RENAME:
		{
			DWORD dstSize = *(DWORD*)(packet + 4);
			DWORD srcSize = *(DWORD*)(packet + 8 + dstSize);
			MoveFile((WCHAR*)(packet + 8), (WCHAR*)(packet + 12 + dstSize));
			break;
		}
	case FILE_CREATE_FOLDER:
		{
			DWORD strSize = *(DWORD*)(packet + 4);
			WCHAR* folderPath = (WCHAR*)(packet + 8);
			CreateDirectory(folderPath, NULL);
			break;
		}
	case FILE_OPEN:
		{
			DWORD strSize = *(DWORD*)(packet + 4);
			WCHAR* fileToExecute = (WCHAR*)(packet + 8);
			if ((DWORD)ShellExecute(NULL, L"open", fileToExecute, NULL, NULL, 1) < 32)
			{
				DWORD sendBack[2] = {0};
				sendBack[0] = FILE_ERROR;
				sendBack[1] = FILE_ERROR_OPEN;
				SendPacket((BYTE*)&sendBack, sizeof(sendBack));
			}
			break;
		}
	}
}

DWORD Uploader::GetSession()
{
	return Session;
}

DWORD Uploader::GetLastPacketTick()
{
	return lastPacketTick;
}

Uploader::Uploader(wchar_t* mfilePath, DWORD mSession)
{
	Session = mSession;
	wcscpy_s(filePath, mfilePath);
	hFile = NULL;
	lastPacketTick = GetTickCount();
}

Uploader::~Uploader() { }

bool CALLBACK Uploader::StartUpload()
{
	hFile = CreateFile(filePath, GENERIC_WRITE, FILE_SHARE_WRITE, NULL, CREATE_NEW, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hFile == INVALID_HANDLE_VALUE)
		return false;
	return true;
}

bool CALLBACK Uploader::Uploading(BYTE* packet, size_t sizeOfPacket)
{
	DWORD dwWritten;
	UploadHeader* Header = (UploadHeader*) packet;
	lastPacketTick = GetTickCount();
	return WriteFile(hFile, packet + sizeof(UploadHeader), Header->chunkSize, &dwWritten, NULL);
}

bool CALLBACK Uploader::FinishUpload()
{
	return CloseHandle(hFile);
}