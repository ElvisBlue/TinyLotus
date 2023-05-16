#ifndef BONE_OBJ_H
#define BONE_OBJ_H
#include "connect.h"

class BoneObj
{
public:
	int				GetObjID()	{return objID;}
	virtual void	OnInit() = 0;
	virtual void	OnPacketArrived(BYTE*, size_t) = 0;
	virtual void	OnExit() = 0;
protected:
	bool			SendPacket(BYTE*, size_t);

	int				objID = -1;
	Connection*		ConnObj;
};

#endif