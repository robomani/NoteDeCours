#include <iostream>

using std::cout;
using std::endl;

struct Coordonnees
{
	int x;
	int y;
};

void remiseAZero(Coordonnees &pointAModifier);

int main()
{
	Coordonnees point;

	point.x = 5;
	point.y = 10;

	cout << "x: " << point.x << "  y: " << point.y << endl;

	// Pas besoin d'indiquer l'adresse de point avec un & lors de l'appel
	remiseAZero(point); 

	cout << "x: " << point.x << "  y: " << point.y << endl;

	system("pause");
	return 0;
}

// La fonction indique qu'elle r�cup�re une r�f�rence
void remiseAZero(Coordonnees &pointAModifier) 
{
	// La r�f�rence s'utilise exactement comme une variable
	// On utilise donc des points "." et non des fl�ches "->"
	pointAModifier.x = 0;
	pointAModifier.y = 0;
}
