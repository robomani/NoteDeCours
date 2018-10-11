#include "Base.h"
#include "Derived1.h"
#include "Derived2.h"

int main()
{
	Base* base = new Derived1();

	// Apres l'appel, derived pointe vers l'instance de Derived
	// car base pointe en fait vers une instance de Derived1
	Derived1* derived1 = dynamic_cast<Derived1*>(base);

	// Apres l'appel, derived2 vaut 0
	// car base ne pointe pas vers une instance de Derived2
	Derived2* derived2 = dynamic_cast<Derived2*>(base);

	// Dans le cas d'une reference, si le cast n'est pas possible
	// une exception de type std::bad_alloc est lance.
	Derived2& derived2_ref = dynamic_cast<Derived2&>(*base);

	return 0;
}
