#pragma once
class A
{
public:
	// Constructeur par défaut
	A();

	// Constructeur par copie
	A(const A& p_a);

	// Destructeur
	~A();

	static int nbInstances;	  // Nombre instance de la classe

protected:
	static int numberNextInstance; // Numero de la prochaine instance
	const int m_number; // numero de l'instance
};

