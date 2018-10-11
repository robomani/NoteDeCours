#pragma once

#include <iostream>

class Duree
{
public:
	explicit Duree(int heures = 0, int minutes = 0, int secondes = 0) 
		: m_time(heures * 3600 + minutes * 60 + secondes) 
	{
	}
	
	void afficher() const
	{
		std::cout << m_time / 3600 << "h" << m_time % 3600 / 60 << "m" << m_time % 60 << "s";
	}

private:
	unsigned int m_time;
};
