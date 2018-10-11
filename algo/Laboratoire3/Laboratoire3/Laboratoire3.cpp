#include "stdafx.h"
#include "Laboratoire3.h"

std::string Laboratoire3::question(const std::string& p_question)
{
	std::string rep;
	std::cout << p_question;
	std::cin >> rep;
	return rep;
}

bool Laboratoire3::question(const std::string& p_question, std::string& p_rep, const std::string& p_cond1, const std::string& p_cond2)
{
	std::cout << p_question;
	std::cin >> p_rep;
	if (p_rep == p_cond1 || p_rep == p_cond2)
	{
		return true;
	}
	else
	{
		return false;
	}
}

bool Laboratoire3::question(const std::string& p_question, std::string& p_rep, const std::string& p_cond1, const std::string& p_cond2, const std::string& p_cond3, const std::string& p_cond4)
{
	std::cout << p_question;
	std::cin >> p_rep;
	if (p_rep == p_cond1 || p_rep == p_cond2 || p_rep == p_cond3 || p_rep == p_cond4)
	{
		return true;
	}
	else
	{
		return false;
	}
}
