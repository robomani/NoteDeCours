#pragma once
#include <iostream>
#include "Base.h"

class Derived2 : public Base
{
public:
	void ShowDerived2()
	{
		std::cout << "Derived2" << std::endl;
	}
};