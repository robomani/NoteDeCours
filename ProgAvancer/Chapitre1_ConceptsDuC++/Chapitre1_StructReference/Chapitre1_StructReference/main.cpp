#include <iostream>

using std::cout;
using std::endl;

struct Coordonnees
{
	int x;
	int y;
};

int main()
{
	Coordonnees point;
	Coordonnees &referenceSurPoint = point;

	referenceSurPoint.x = 10;
	referenceSurPoint.y = 5;

	cout << "x : " << referenceSurPoint.x << endl;
	cout << "y : " << referenceSurPoint.y << endl;


	return 0;
}
