#pragma once
class Box 
{
public:
	Box(int width, int length, int height)
		: m_width(width)
		, m_length(length)
		, m_height(height)
	{
	}

	int Volume() 
	{ 
		return m_width * m_length * m_height;
	}

private:
	int m_width;
	int m_length;
	int m_height;
};

