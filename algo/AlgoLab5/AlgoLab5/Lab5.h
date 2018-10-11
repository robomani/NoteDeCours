#ifndef Lab5
#define Lab5
#include<iostream>
#include<string>

class Fraction
{
	int m_Numerateur = 0;
	int m_Denominateur = 1;

public : 
	Fraction()
	{
		m_Numerateur = 0;
		m_Denominateur = 1;
	}
	Fraction(int p_Numerateur, int p_Denominateur)
	{
		m_Numerateur = p_Numerateur;
		m_Denominateur = p_Denominateur;
	}
	Fraction add(const int&);
	Fraction add(const Fraction&);
	Fraction normalize();
	void print();
	float toFloat();
};
#endif // !Lab5

