#include <iostream>

using std::cout;
using std::endl;

int main() {

	int a, b, c;

	// Utilisation du sizeof sur un int
	cout << "Taille d'un int: " << sizeof(int) << " octets" << endl;

	// Affiche les différentes adresses des variable a, b et c
	cout << "Adresse de a: " << &a << endl;
	cout << "Adresse de b: " << &b << endl;
	cout << "Adresse de c: " << &c << endl;

	system("pause");
	return 0;
}