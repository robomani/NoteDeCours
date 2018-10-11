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

	*p1 = 1; // ecrit 1 dans la zone m�moire allou�e

	cout << *p1 << endl; // lit et affiche le contenu de la zone m�moire allou�e

	delete p1; // lib�re la zone m�moire allou�e
	cout << "-----------------" << endl << endl;
}

void CreateArrayInt() {
	cout << "CreateArrayInt()" << endl << "-----------------" << endl;
	int * p2 = new int[5]; // alloue un tableau de 5 entiers en m�moire

	// initialise le tableau avec des 0 (cf. la fonction memset)
	for (int i = 0; i < 5; i++)
	{
		*(p2 + i) = 0; // les 2 �critures sont possibles

		p2[i] = 0; // identique � la ligne pr�c�dente

		cout << "p2[" << i << "] = " << p2[i] << endl;
	}
	delete[] p2; // lib�re la m�moire allou�e
	cout << "-----------------" << endl << endl;
}

void CreateObject() {
	cout << "CreateObject()" << endl << "-----------------" << endl;
	Point2D *pointC; // je suis pointeur sur un objet de type Point

	pointC = new Point2D(2, 2); // j�alloue dynamiquement un objet de type Point

	pointC->Show(); // Comme pointC est une adresse, je dois utiliser l�op�rateur -> pour acc�der aux membres de cet objet

	pointC->SetY(0); // je modifie la valeur de l�attribut _y de pointB

	(*pointC).Show(); // cette �criture est possible : je pointe l�objet puis j�appelle sa m�thode afficher()
	
	delete pointC; // ne pas oublier de lib�rer la m�moire allou�e pour cet objet
	cout << "-----------------" << endl << endl;
}