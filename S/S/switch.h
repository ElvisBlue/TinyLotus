#pragma once
#include "bone_obj.h"

class Switch :public BoneObj
{
public:
	virtual void OnInit();
	virtual void OnPacketArrived(BYTE*, size_t);
	virtual void OnExit();
	Switch(Connection*, char*);
	~Switch();
	bool SendPasswordPacket();
	bool IsCloseSignature();
	bool IsServerAccepted();
	void SetServerAcceptedState(bool);

private:
	bool bIsServerAccepted;
	bool bClose;
	char* password;
};