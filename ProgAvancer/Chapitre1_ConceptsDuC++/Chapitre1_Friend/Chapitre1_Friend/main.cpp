#include <iostream>
#include "Duree.h"

using std::cout;
using std::endl;

int main()
{
    Duree duree1(0, 10, 42), duree2(0, 53, 27);
    Duree resultat;

	cout << duree1;
    cout << "+" << endl;
	cout << duree2;

    resultat = duree1 + duree2;

    cout << "=" << endl;
	cout << resultat;

	system("pause");
    return 0;
}



