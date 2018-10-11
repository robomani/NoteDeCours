#ifndef _VECTOR_H_
#define _VECTOR_H_

#include <string>

struct Vector
{
	int m_Size = 0;
	int m_Capacity = 1;
	const std::string** m_Tableau = new const std::string*[1];

	~Vector();

	// Retourne le nombre d'éléments.
	int size();

	// Retourne la capacité réelle du tableau.
	int capacity();

	// Ajoute un élément à la fin du vecteur.
	void add(const std::string& element);

	// Insère un élément à la position donnée.
	void insert(const int position, const std::string& element);

	// Retourne l'élément à la position donnée.
	const std::string& get(const int position);

	// Efface l'élément à la position donnée.
	void remove(const int position);

	// Vide le vecteur.
	void clear();
};

#endif /* _VECTOR_H_ */
