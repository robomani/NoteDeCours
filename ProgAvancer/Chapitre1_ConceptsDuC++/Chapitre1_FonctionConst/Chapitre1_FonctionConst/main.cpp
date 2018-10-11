#include "Duree.h"

void showTime(const Duree& duree);

int main() 
{
	Duree duree(1, 5);
	showTime(duree);
	double d = 0.0000000000;
	float f = d;

	
	return 0;
}

void showTime(const Duree& duree)
{
	duree.afficher();
}