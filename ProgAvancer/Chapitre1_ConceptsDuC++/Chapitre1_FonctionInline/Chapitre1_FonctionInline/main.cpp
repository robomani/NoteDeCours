#pragma once
#include <iostream>

using std::cout;
using std::endl;

inline int carre(int nombre);

int main()
{
	cout << carre(10) << endl;
	return 0;
}

inline int carre(int nombre)
{
	return nombre * nombre;
}
