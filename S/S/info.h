#ifndef INFO_H
#define INFO_H

#include "bone_obj.h"
#include "connect.h"
#include "config.h"

class Info:public BoneObj
{
public:
	virtual void OnInit();
	virtual void OnPacketArrived(BYTE*, size_t);
	virtual void OnExit();
	Info(Connection*, config*);
	~Info();
private:
	bool GetComputerInfo(BYTE*, size_t*);
	bool GetRATInfo(BYTE* dataBuffer, size_t* dataMaxSize);
	config* conf;
};

#endif