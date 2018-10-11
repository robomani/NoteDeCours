#include <iostream>

using std::cout;
using std::endl;

int main() {

	int a = 10, *p = &a;
	cout << "a est un int, de taille " << sizeof(a) << " octets\n";
	cout << "adresse de a: " << p << endl;
	cout << "adresse suivante: " << ++p << endl;

	system("pause");
	return 0;
}