#include <iostream>
#include "A.h"

using std::cout;
using std::endl;

int main()
{
	std::cout << A::nbInstances << endl;
	A* a1 = new A();
	std::cout << A::nbInstances << endl;

	A* a2 = new A();
	std::cout << A::nbInstances << endl;

	delete a1;
	std::cout << A::nbInstances << endl;

	delete a2;
	std::cout << A::nbInstances << endl;

	system("pause");
	return 0;
}