#include <iostream>

using std::cout;
using std::endl;

struct ABC {
	int a, b, c;
};

void ChangerValeurs(ABC* p, int valeur) {
	p->a = valeur - 1;
	p->b = valeur;
	p->c = valeur + 1;
}

int main() {
	ABC maStruct;

	ChangerValeurs(&maStruct, 10);

	cout << "Valeurs :";
	cout << " a = " << maStruct.a;
	cout << " b = " << maStruct.b;
	cout << " c = " << maStruct.c;
	cout << endl;

	system("pause");
	return 0;
}