// Basic_Loader.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <Windows.h>
#include <iostream>

using namespace std;

void LoadDllThread()
{
	cout<<"Prepare to load S.dll\n";
	if (!LoadLibrary(L"S.dll"))
		cout<<"Could not load S.dll\n";
	cout<<"Finished\n";
}

int _tmain(int argc, _TCHAR* argv[])
{
	CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE) LoadDllThread, NULL, NULL, NULL);
	system("pause");
	return 0;
}

