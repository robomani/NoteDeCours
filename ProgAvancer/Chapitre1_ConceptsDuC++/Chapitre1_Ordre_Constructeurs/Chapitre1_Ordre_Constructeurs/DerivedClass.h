#pragma once

#include "BaseClass.h"
#include "Contained3.h"

class DerivedClass : public BaseClass {
public:
	DerivedClass()
		: BaseClass() 
	{
		cout << "DerivedClass constructor." << endl;
	}
private:
	Contained3 c3;
};

