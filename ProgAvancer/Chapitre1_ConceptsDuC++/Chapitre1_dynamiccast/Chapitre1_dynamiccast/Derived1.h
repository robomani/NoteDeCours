#pragma once
#include <iostream>
#include "Base.h"

class Derived1 : public Base
{
public:
	void ShowDerived1()
	{
		std::cout << "Derived1" << std::endl;
	}
};
