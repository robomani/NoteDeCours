#include "Base.h"
#include "Derived1.h"
#include "Derived2.h"

int main()
{
	Base* base = new Derived1();

	Derived1* derived1 = static_cast<Derived1*>(base);
	Derived2* derived2 = static_cast<Derived2*>(base);

	return 0;
}
