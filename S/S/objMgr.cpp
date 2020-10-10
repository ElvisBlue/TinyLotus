#include "objMgr.h"
#include "Utilities.h"

ObjMgr::ObjMgr()
{

}

ObjMgr::~ObjMgr()
{

}


bool ObjMgr::OnPacketArrived(BYTE* Packet, size_t size)
{
	for (auto it = objList.begin(); it != objList.end(); ++it)
	{
		BoneObj* Obj = *it;
		PacketHeader* Header = (PacketHeader*)Packet;
		if (Obj->GetObjID() == Header->objID)
		{
			Obj->OnPacketArrived(Packet + sizeof(PacketHeader), Header->PacketSize);
			break;
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