#ifndef _VECTOR_H_
#define _VECTOR_H_

#include <string>

struct Vector
{
	int m_Size = 0;
	int m_Capacity = 1;
	const std::string** m_Tableau = new const std::string*[1];

	~Vector();

	// Retourne le nombre d'�l�ments.
	int size();

	// Retourne la capacit� r�elle du tableau.
	int capacity();

	// Ajoute un �l�ment � la fin du vecteur.
	void add(const std::string& element);

	// Ins�re un �l�ment � la position donn�e.
	void insert(const int position, const std::string& element);

	// Retourne l'�l�ment � la position donn�e.
	const std::string& get(const int position);

	// Efface l'�l�ment � la position donn�e.
	void remove(const int position);

	// Vide le vecteur.
	void clear();
};

#endif /* _VECTOR_H_ */
