#include <iostream>
#include "A.h"

using std::cout;
using std::endl;

int main()
{
	/* Utilisation du this-> à l'intérieur de la classe */
	A a;
	cout << a.m_entierStatic << endl;
	/**********************/

	/* Méthode à prescire */
	a.m_entierStatic = 15;
	cout << a.m_entierStatic << endl;
	/**********************/

	/* Méthode à prévilégier */
	A::m_entierStatic = 52;
	cout << A::m_entierStatic << endl;
	/*************************/

	system("pause");
	return 0;
}