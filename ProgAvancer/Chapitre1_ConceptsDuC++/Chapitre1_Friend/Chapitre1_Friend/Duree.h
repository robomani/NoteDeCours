#pragma once

class Duree
{
public:

	Duree(int heures = 0, int minutes = 0, int secondes = 0);
	Duree& operator+=(const Duree &duree);


private:

	void afficher(std::ostream& out) const;

	friend std::ostream &operator<<(std::ostream &out, Duree const& duree);

	int m_heures;
	int m_minutes;
	int m_secondes;
};

Duree operator+(Duree const& a, Duree const& b);

