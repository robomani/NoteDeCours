#include <iostream>
#include "Box.h"

int main() 
{
	Box box(10, 12, 14);
	std::cout << "Volume of the box: " << box.Volume() << std::endl;

	system("pause");
	return 0;
}