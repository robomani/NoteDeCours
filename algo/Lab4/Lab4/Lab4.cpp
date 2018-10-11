#include "stdafx.h"
#include <iostream>
#include <string>


int main()
{
	std::string etudiant[30];
	int notes[30][30];
	int nbrEvaluation, nbrEleve, rep, moyenne, moyenneGroupe = 0;
	std::string repString;

	do
	{
		std::cout << "Combien d'evaluation(s) (max: 30 min: 1)? ";
		std::cin >> rep;
		if (rep < 1)
		{
			std::cout << "Minimum 1!" << std::endl;
		}
		else if (rep > 30)
		{
			std::cout << "Maximum 30!" << std::endl;
		}
	} while (rep < 1 || rep > 30);
	nbrEvaluation = rep;
	nbrEleve = 0;
	do
	{
		nbrEleve++;
		std::cout << "Nom de l'etudiant " << nbrEleve << ": ";
		std::cin >> repString;
		etudiant[nbrEleve - 1] = repString;
		for (int i = 0; i < nbrEvaluation; i++)
		{
			std::cout << "Note " << i + 1 << ": ";
			std::cin >> rep;
			notes[nbrEleve - 1][i] = rep;

		}
		

		while (repString != "oui" && repString != "non" && nbrEleve < 30)
		{
			std::cout << "Voulez-vous continuer? (oui/non) ";
			std::cin >> repString;
			if (repString != "oui" && repString != "non")
			{
				std::cout << "Reponse invalide!" << std::endl;
			}
		}

		if (repString == "non")
		{
			break;
		}
	} while (nbrEleve < 30);

	std::cout << std::endl << "Resultat:" << std::endl;
	for (int i = 0; i < nbrEleve; i++)
	{
		if (etudiant[i] != "")
		{
			moyenne = 0;
			for (int j = 0; j < nbrEvaluation; j++)
			{
				moyenne += notes[i][j];
				moyenneGroupe += notes[i][j];
			}
			moyenne /= nbrEvaluation;
			std::cout << etudiant[i] << " : " << moyenne << std::endl;
		}
		else
		{
			break;
		}
	}
	moyenneGroupe /= (nbrEleve * nbrEvaluation);
	std::cout << std::endl << "Moyenne: " << moyenneGroupe << std::endl;

}

