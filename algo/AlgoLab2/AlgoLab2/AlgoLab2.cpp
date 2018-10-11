// AlgoLab2.cpp : Définit le point d'entrée pour l'application console.
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include <stdlib.h>
#include <windows.h>

using namespace std;

float Asknumber();
bool AskNext();

int main()
{
	SetConsoleOutputCP(CP_UTF8);
    float total = 0.0; float temp = 0.0;
	cout << "Voici une calculatrice " << endl;
	bool calcul = true;
	while (calcul)
	{
		
		cout << "Choisissez une opération (+, -, * ou /): ";
		string str;
		char operation;
		cin >> str;
		operation = str.at(0); // http://www.cplusplus.com/reference/string/string/at/
		switch (int(operation))
		{
		case 43: total += Asknumber(); cout << "Total : " << total << endl;  calcul = AskNext(); break;
		case 45 : total -= Asknumber(); cout << "Total : " << total << endl;  calcul = AskNext(); break;
		case 42 : total *= Asknumber(); cout << "Total : " << total << endl;  calcul = AskNext(); break;
		case 47 : total /= Asknumber(); cout << "Total : " << total << endl;  calcul = AskNext(); break;
		default:
			cout << "Opération inconnue." << endl; break;

		}
	}

}

float Asknumber()
{
	cout << "Choisissez une valeure: ";
	float temp;
	cin.clear();
	cin >> temp;
	return temp;
}

bool AskNext()
{
	string rep;
	bool con = true;
	while (con)
	{
		cout << "Voulez-vous continuer? (oui ou non) ";

		cin >> rep;
	
		if (rep == "oui")
		{
			con = false;
			return true;
		}
		else if (rep == "non")
		{
			con = false;
			return false;
		}
		else
		{
			cout << "Réponse inconnue." << endl; 
		}	
	}
	
}