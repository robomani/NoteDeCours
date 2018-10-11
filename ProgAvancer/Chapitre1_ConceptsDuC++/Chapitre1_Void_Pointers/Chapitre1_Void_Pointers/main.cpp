#include <iostream>

using std::cout;
using std::endl;

struct Exemple { 
	int a;
	int b;
};

int main() {
	int i;
	void* p;
	
	Exemple e;
	e.a = 45;
	e.b = 32;
	i = 12;

	p = &e;
	cout << "e.a = " << ((Exemple*)p)->a << endl;
	cout << "e.b = " << ((Exemple*)p)->b << endl;

	p = &i;
	cout << "i.a = " << ((Exemple*)p)->a << " ????\n";
	cout << "i.b = " << ((Exemple*)p)->b << " !!!!\n";

	system("pause");
	return 0;
}
