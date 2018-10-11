#include "A.h"

int A::nbInstances = 0;
int A::numberNextInstance = 0;

A::A()
	: m_number(A::numberNextInstance)
{
	A::nbInstances++;
	A::numberNextInstance++;
}

A::A(const A& p_a)
	: m_number(A::numberNextInstance)
{
	A::nbInstances++;
	A::numberNextInstance++;

	// Ici, copier les valeur du parametre dans la nouvelle
	// instance.
}

A::~A()
{
	A::nbInstances--;
}
