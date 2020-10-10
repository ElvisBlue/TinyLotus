#ifndef UTILITIES_H
#define UTILITIES_H

#include <cstdlib>
#include <windows.h>

static bool isSeedCreated=false;

namespace Utilities
{
	static DWORD DJBHash(char* str) 
	{
	   unsigned int hash = 0xCAFEBABE;

	   for(; *str; str++)
		  hash = ((hash << 5) + hash) + (*str);

	   return hash;	
	}

	static DWORD Random()
	{
		if (!isSeedCreated)
		{
			srand(GetTickCount()^0xDEADBEEF);
			isSeedCreated = true;
		}
		return (rand()^0xBAADF00D);
	}
};

#endif