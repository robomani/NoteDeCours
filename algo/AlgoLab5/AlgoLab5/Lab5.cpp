#include "stdafx.h"
#include "Lab5.h"

int main()
{
	Fraction fractionBase;
	std::string rep;
	int addInt, addDenum;
	bool end = false;
	do
	{
		std::cout << "Voulez-Vous ajouter un entier, une fraction, ou quitter? ";
		std::cin >> rep;

		if (rep == "entier")
		{
			std::cout << "Entier: ";
			std::cin >> addInt;
			fractionBase = fractionBase.add(addInt);
			fractionBase.print();
		}
		else if (rep == "fraction")
		{
			std::cout << "Numerateur: ";
			std::cin >> addInt;
			std::cout << "Denominateur: ";
			std::cin >> addDenum;
			Fraction fractionRep(addInt, addDenum);
			fractionBase = fractionBase.add(fractionRep);
			fractionBase.print();
		}
		else if (rep == "quitter")
		{
			std::cout << "Resultat: " << fractionBase.toFloat() << std::endl;
			end = true;
		}
		else
		{
			std::cout << "Reponse invalide" << std::endl;
		}
	} while (!end);
}




Fraction Fraction::add(const int& p_Number)
{
	// A / B + C = (A + B * C) / B
	m_Numerateur = (m_Numerateur + m_Denominateur * p_Number);
	return normalize();

}

Fraction Fraction::add(const Fraction& p_Fraction)
{
	// A / B + C / D = (A * D + C * B) / (B * D)
	m_Numerateur = m_Numerateur * p_Fraction.m_Denominateur + p_Fraction.m_Numerateur * m_Denominateur;
	m_Denominateur = m_Denominateur * p_Fraction.m_Denominateur;
	return normalize();
}

Fraction Fraction::normalize()
{
	int repNum, repDenum;
	int i = m_Numerateur + 1;
	do
	{
		i--;
		repNum = m_Numerateur % i;
		repDenum = m_Denominateur % i;

	} while ((repNum != 0 || repDenum != 0) && i > 1);
	if (i ==1)
	{
		Fraction rep{ m_Numerateur, m_Denominateur};
		return rep;
	}
	else
	{
		Fraction rep{ m_Numerateur / i, m_Denominateur / i };
		Fraction rep2;
		rep2 = rep.normalize();
		return rep2;
	}

	
	
}

void Fraction::print()
{
	std::cout << m_Numerateur << " / " << m_Denominateur << std::endl;
}

float Fraction::toFloat()
{
	
	return static_cast<float>(m_Numerateur) /m_Denominateur;
}
