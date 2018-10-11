#include <new>
#include <iostream>

using std::cout;
using std::endl;

void CreateInt();
void CreateArrayInt();
void CreateObject();

class Point2D {
private:
	int x; 
	int y;

public:
	Point2D(const int aX, const int aY) 
		: x(aX), y(aY) {

	}

	void Show() {
		std::cout << this << " x: " << x << ", y: " << y << endl;
	}

	void SetY(const int aY) {
		y = aY;
	}
};

int main() {

	CreateInt();
	CreateArrayInt();
	CreateObject();

	system("pause");
	return 0;
}

void CreateInt() {
	cout << "CreateInt()" << endl << "-----------------" << endl;
	int* p1 = new int; // pointeur sur un entier

	*p1 = 1; // ecrit 1 dans la zone mémoire allouée

	cout << *p1 << endl; // lit et affiche le contenu de la zone mémoire allouée

	delete p1; // libère la zone mémoire allouée
	cout << "-----------------" << endl << endl;
}

void CreateArrayInt() {
	cout << "CreateArrayInt()" << endl << "-----------------" << endl;
	int * p2 = new int[5]; // alloue un tableau de 5 entiers en mémoire

	// initialise le tableau avec des 0 (cf. la fonction memset)
	for (int i = 0; i < 5; i++)
	{
		*(p2 + i) = 0; // les 2 écritures sont possibles

		p2[i] = 0; // identique à la ligne précèdente

		cout << "p2[" << i << "] = " << p2[i] << endl;
	}
	delete[] p2; // libère la mémoire allouée
	cout << "-----------------" << endl << endl;
}

void CreateObject() {
	cout << "CreateObject()" << endl << "-----------------" << endl;
	Point2D *pointC; // je suis pointeur sur un objet de type Point

	pointC = new Point2D(2, 2); // j’alloue dynamiquement un objet de type Point

	pointC->Show(); // Comme pointC est une adresse, je dois utiliser l’opérateur -> pour accéder aux membres de cet objet

	pointC->SetY(0); // je modifie la valeur de l’attribut _y de pointB

	(*pointC).Show(); // cette écriture est possible : je pointe l’objet puis j’appelle sa méthode afficher()
	
	delete pointC; // ne pas oublier de libérer la mémoire allouée pour cet objet
	cout << "-----------------" << endl << endl;
}