#pragma once
#include <iostream>
#include "Contained1.h"
#include "Contained2.h"

using std::cout;
using std::endl;

class BaseClass {
public:
	BaseClass() {
		cout << "BaseClass constructor." << endl;
	}
private:
	Contained1 c1;
	Contained2 c2;
};