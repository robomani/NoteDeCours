#include "Vector.h"


Vector::~Vector()
{
	delete[] m_Tableau;
}

int Vector::size()
	{
		return m_Size;
	}
	int Vector::capacity()
	{
		return m_Capacity;
	}

	void Vector::add(const std::string& a_Element)
	{
		m_Size++;
		if (m_Capacity < m_Size)
		{
			m_Capacity *= 2;
			const std::string** tabTemp = new const std::string*[m_Capacity];

			for (int i = 0; i < m_Size - 1; i++)
			{
				tabTemp[i] = m_Tableau[i];
			}
			tabTemp[m_Size-1] = &a_Element;
			delete[] m_Tableau;
			m_Tableau = tabTemp;
			tabTemp = nullptr;
		}
		else
		{
			m_Tableau[m_Size - 1] = &a_Element;
		}
	}

	void Vector::insert(const int a_Position, const std::string & a_Element)
	{
		
		if (m_Capacity < m_Size + 1)
		{
			m_Capacity *= 2;
		}

		const std::string** tabTemp = new const std::string*[m_Capacity];

		for (int i = 0; i < m_Size + 1; i++)
		{
			if (i == a_Position)
			{
				tabTemp[i] = &a_Element;
			}
			else if(i < a_Position)
			{
				tabTemp[i] = m_Tableau[i];
			}
			else
			{
				tabTemp[i] = m_Tableau[i - 1];
			}
			
		}
		delete[] m_Tableau;
		m_Tableau = tabTemp;
		tabTemp = nullptr;
		m_Size++;
	}

	const std::string & Vector::get(const int a_Position)
	{
		return  *m_Tableau[a_Position];
	}

	void Vector::remove(const int a_Position)
	{
		m_Size--;
		const std::string** tabTemp = new const std::string*[m_Capacity];

		for (int i = 0; i < m_Size+1; i++)
		{
			if (i == a_Position)
			{

			}
			else if (i < a_Position)
			{
				tabTemp[i] = m_Tableau[i];
			}
			else
			{
				tabTemp[i - 1] = m_Tableau[i];
			}

		}
		delete[] m_Tableau;
		m_Tableau = tabTemp;
		tabTemp = nullptr;
	}

	void Vector::clear()
	{
		m_Size = 0;
	}
