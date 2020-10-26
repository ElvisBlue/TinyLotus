#include "objMgr.h"
#include "Utilities.h"
#include "switch.h"

ObjMgr::ObjMgr()
{

}

ObjMgr::~ObjMgr()
{
	objList.clear();
}

bool ObjMgr::ClearObjList()
{
	objList.clear();
	return true;
}

bool ObjMgr::OnPacketArrived(BYTE* Packet, size_t size)
{
	Switch* switchObj = (Switch*)GetObjByID(5);
	for (auto it = objList.begin(); it != objList.end(); ++it)
	{
		BoneObj* Obj = *it;
		PacketHeader* Header = (PacketHeader*)Packet;
		if ((Obj->GetObjID() == Header->objID))
		{
			//If client is not auth, only allow switch packet. Should I??
			if (switchObj->IsServerAccepted() || Header->objID == 5)
			{
				Obj->OnPacketArrived(Packet + sizeof(PacketHeader), Header->PacketSize);
				break;
			}
		}
	}
	return true;
}

bool ObjMgr::RegisterObj(BoneObj* Obj)
{
	Obj->OnInit();
	objList.push_back(Obj);
	return true;
}

void ObjMgr::OnExit()
{
	for (auto it = objList.begin(); it != objList.end(); ++it)
	{
		(*it)->OnExit();
	}
}

BoneObj* ObjMgr::GetObjByID(int objID)
{
	for (auto it = objList.begin(); it != objList.end(); ++it)
	{
		BoneObj* Obj = *it;
		if (Obj->GetObjID() == objID)
			return Obj;
	}
	return NULL;
}