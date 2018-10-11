// ConsoleApplication4.cpp : Définit le point d'entrée pour l'application console.
//

#include "stdafx.h"
#include <iostream>
#include <random>
#include <string>
#include <stdlib.h>
#include <windows.h>

int intro(); int block1_parchemin(); int block2_fin1(); int block3_porte(); int block4_coffre(); int block5_choix();
int block6_Livre(); int block7_Warrior(); int block8_Mage(); int block9_Sage(); int block10_Armee(); int block11_Combat(); int block12_victoire(); int block13_defaite();
void Restart();

std::random_device start;
std::mt19937 hasard(start());
std::uniform_int_distribution<> d2(1, 2);
std::uniform_int_distribution<> d100(0, 99);
HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE); /* https://www.daniweb.com/programming/software-development/code/216345/add-a-little-color-to-your-console-text */
using namespace std;

bool g_start = true;
int g_seen = 0;
int g_power = 0;
bool g_chest = false;
int g_lose = 0;

int main()
{
	SetConsoleOutputCP(CP_UTF8);
	int where = 0;
	while (true)
	{
		switch (where)
		{
		case 0: where = intro(); break;
		case 1: where = block1_parchemin(); break;
		case 2: where = block2_fin1(); break;
		case 3: where = block3_porte(); break;
		case 4: where = block4_coffre(); break;
		case 5: where = block5_choix(); break;
		case 6: where = block6_Livre(); break;
		case 7: where = block7_Warrior(); break;
		case 8: where = block8_Mage(); break;
		case 9: where = block9_Sage(); break;
		case 10: where = block10_Armee(); break;
		case 11: where = block11_Combat(); break;
		case 12: where = block12_victoire(); break;
		case 13: where = block13_defaite(); break;
		default:
			break;
		}
	}

}

int intro()
{
	std::cout << "-------------" << std::endl;
	if (g_start)
	{
		std::cout << "Règle : S'il n'y a aucune instruction pour continuer inscrivez nimporte quelle lettre et faite 'Entrée' pour continuer" << std::endl;
		std::cout << "Vous vous réveillez dans une caverne." << std::endl;
		g_start = false;
	}

	std::cout << "Derrière vous une entrée mène à un mur de lumière" << std::endl;
	std::cout << "Devant vous se trouvent une porte et un parchemin sur le mur" << std::endl;
	std::cout << "Choisir: Si vous voulez lire le parchemin [1]" << endl << "si vous voulez entrer le mur de lumière [2] " << endl << "Si vous voulez franchir la porte [3] "
		<< std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{
		std::cout << "Vous vous approchez du parchemin" << std::endl;
		std::cin >> choix;
		return 1;

	}
	else if (choix == "2")
	{
		std::cout << "Vous vous approchez de la lumière. Êtes-vous sûr de vouloir y entrer? sélectionner y pour entre ou n pour revenir" << std::endl;
		std::cin >> choix;
		if (choix == "y")
			return 2;
		else
		{
			return 0;
		}
	}
	else if (choix == "3")
	{
		std::cout << "Vous vous approchez de la porte. Êtes-vous sûr de vouloir y entrer? sélectionner y pour entrer ou n pour revenir" << std::endl;
		std::cin >> choix;
		if (choix == "y")
			return 3;
		else
		{
			return 0;
		}
	}
	else
	{
		return 0;
	}
}

int block1_parchemin()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Vous décidez de commencer par lire le parchemin" << std::endl;
	SetConsoleTextAttribute(hConsole, 2);
	std::cout << "Si vous lisez ceci c'est que pour une raison ou une autre votre âme a accumulé suffisamment d'énergie pour vous donner l'opportunité de devenir un dieu mineur"
		<< std::endl << std::endl;
	std::cout << "Si vous sortez de la zone de test en utilisant le rideau de lumière, vous perdrez l'opportunité de devenir un dieu, mais l'énergie que vous avez accumulée sera utilisé"
		<< std::endl;
	std::cout << "pour modifier votre corps physique, ce qui vous protégera des maladies et augmentera votre espérance de vie." << std::endl << std::endl;
	std::cout << "Si vous passez la porte, vous pourrez utiliser le coffre dans la prochaine salle pour transformer une partie de votre énergie en un objet." << std::endl;
	std::cout << "Il vous suffit de toucher le coffre et de penser à une faiblesse que vous voulez corriger et un objet apparaîtra dans le coffre." << std::endl << std::endl;
	std::cout << "Prenez garde, devenir un dieu n'est pas sans risque, si vous entrez votre survie n'est pas garantie." << std::endl;
	SetConsoleTextAttribute(hConsole, 7);
	std::cout << endl << "Choisir: Si vous voulez entrer le mur de lumière [1] " << endl << "Si vous voulez franchir la porte [2] " << std::endl;
	g_seen = 1;
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{
		std::cout << "Vous vous approchez de la lumière. Êtes-vous sûr de vouloir y entrer? sélectionner y pour entre ou n pour revenir" << std::endl;
		std::cin >> choix;
		if (choix == "y")
			return 2;
		else
		{
			return 0;
		}
	}
	else if (choix == "2")
	{
		std::cout << "Vous vous approchez de la porte. Êtes-vous sûr de vouloir y entrer? sélectionner y pour entrer ou n pour revenir" << std::endl;
		std::cin >> choix;
		if (choix == "y")
			return 3;
		else
		{
			return 0;
		}
	}
	else
	{
		return 1;
	}
}

int block2_fin1()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Vous vous réveillez dans votre lit et continuer votre vie normale." << std::endl;
	std::cout << "Vous vivez une vie longue et mourez à l'âge vénérable de 257 ans." << endl;

	if (g_seen == 1)
	{
		std::cout << "Vous avez vécu une vie heureuse, mais jusqu'à votre fin vous vous êtes toujours demandé : Auriez vous dû risquer votre vie pour la chance de devenir un dieu?" << std::endl;
	}
	std::cout << "Choisir: recommencer ou quitter" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "recommencer")
	{
		Restart();
		return 0;
	}
	else if (choix == "quitter")
	{
		exit(0);
	}
	else
	{
		return 2;
	}
}

int block3_porte()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Vous entrez dans une pièce vide à l'exception d'un coffre et de deux portes autres que celle que vous avez utilisée." << std::endl;
	std::cout << endl << "Choisir: Si vous voulez franchir la porte de gauche [1] " << endl << "Si vous voulez franchir la porte de droite [2] "
		<< endl;
	if (g_chest == 0)
	{
		std::cout << "Si vous voulez interagir avec le coffre [3] " << endl;
	}
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{
		std::cout << "Vous vous approchez de la porte et voyez une inscription : " << std::endl;
		SetConsoleTextAttribute(hConsole, 2);
		std::cout << "Parfois toutes nos compétences ont été inutiles, dans ses cas nous ne pouvons que nous fier à notre CHANCE" << std::endl;
		SetConsoleTextAttribute(hConsole, 7);
		std::cout << "Choisir: Si vous voulez tenter votre chance (1%)? sélectionner [y], pour revenir [n]" << std::endl;
		std::cin >> choix;
		if (choix == "y" && d100(hasard) == 10)
		{
			return 12;
		}
		else if (choix == "y" && g_power == 3)
		{
			std::cout << "Alors que vos aliez perdre, les dés que vous avez obtenus du coffre commencent à briller et la porte vous signale que vous avez réussi" << std::endl;
			std::cout << "Pour traverser la porte, entrez le chiffre de votre choix" << std::endl;
			cin >> choix;
			return 12;
		}
		else if (choix == "y")
		{
			g_lose = 1;
			return 13;
		}
		else if (g_seen == 1)
		{
			g_seen = 2;
			return 3;
		}
		else
		{
			return 3;
		}
	}
	else if (choix == "2")
	{
		return 5;
	}
	else if (choix == "3" && g_chest == 0)
	{
		return 4;
	}
	else
	{
		return 3;
	}
}

int block4_coffre()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Le coffre n'a pas de serrure, mais une inscription est visible sur le couvercle : " << std::endl;
	SetConsoleTextAttribute(hConsole, 2);
	std::cout << "Les mortels sont toujours limités par leur SAVOIR et leur POUVOIR" << std::endl;
	SetConsoleTextAttribute(hConsole, 7);

	if (g_seen == 0)
	{
		std::cout << "Choisir: Si vous voulez ouvrir le coffre [1], si vous voulez vous éloigner du coffre [2]" << std::endl;
	}
	else if (g_seen >= 1)
	{
		std::cout << "Choisir: Si vous voulez ouvrir le coffre pour du SAVOIR [1]" << std::endl << "Si vous voulez ouvrir le coffre pour du POUVOIR [2]" << std::endl;
		cout << "Si vous voulez vous éloigner du coffre [3]" << std::endl;
		if (g_seen == 2)
		{
			std::cout << "Si vous voulez ouvrir le coffre pour de la CHANCE [4]" << std::endl;
		}
	}
	else
	{
		std::cout << "Si vous voulez ouvrir le coffre [1]" << std::endl;
	}
	std::string choix;
	std::cin >> choix;

	if (choix == "1" && g_seen == 0)
	{
		std::cout << "Le coffre est vide..." << std::endl;
		std::cout << "Entrez un chiffre pour continuer" << std::endl;
		g_chest = 1;
		std::cin >> choix;
		return 3;
	}
	else if (choix == "2" && g_seen == 0)
	{
		return 3;
	}
	else if (choix == "1" && g_seen == 1)
	{
		std::cout << "Dans le coffre vous trouvez un Livre" << std::endl;
		g_chest = 1;
		g_power = 1;
		std::cin >> choix;
		return 3;
	}
	else if (choix == "2" && g_seen == 1)
	{
		std::cout << "Dans le coffre vous trouvez une Épée" << std::endl;
		g_chest = 1;
		g_power = 2;
		std::cin >> choix;
		return 3;
	}
	else if (choix == "3" && g_seen != 1)
	{
		return 3;
	}
	else if (choix == "4" && g_seen == 2)
	{
		std::cout << "Dans le coffre vous trouvez un Dé" << std::endl;
		g_chest = 1;
		g_power = 3;
		std::cin >> choix;
		return 3;
	}

	else
	{
		return 4;
	}
}

int block5_choix()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Vous entrez dans une petite salle avec une porte a votre gauche sur laquelle vous voyez des lettres brillantes et une porte à droite sur laquelle vous voyez une indentation de la forme d'une épée." << std::endl;
	std::cout << "Choisir: pour aller à la porte de gauche [1], pour aller à la porte de droite [2] pour retourner à la salle du coffre [3]" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{
		if (g_power = 1)
		{
			std::cout << "Vous vous approchez des lettres, mais n'arrivez pas à les comprendre." << endl 
				<< "Alors que vous vous apprêtiez à partir votre livre se met à briller et vous comprenez ce qui est écrit sur la porte." << std::endl;
			SetConsoleTextAttribute(hConsole, 2);
			std::cout << "Mieux que dieu" << std::endl;
			std::cout << "Pire que le diable" << std::endl;
			std::cout << "Les pauvres en ont" << std::endl;
			std::cout << "Les riches en ont besoin" << std::endl;
			std::cout << "Si on en mange, on meurt" << std::endl;
			SetConsoleTextAttribute(hConsole, 7);
			std::cout << "Un mur de lumière vous coupe de la salle, vous ne pouvez pas repartir!" << std::endl;
			std::cout << "(Entrez votre réponse en lettre minuscule, mot de 4 lettres, 3 essais)" << std::endl;
			
			int essais = 3;
			while (essais > 0)
			{
				std::cin >> choix;
				if (choix == "rien")
				{
					std::cout << "La porte s'ouvre et n'ayant pas d'autre sortie vous la franchisez" << std::endl;
					std::cin >> choix;
					return 6;
				}
				else
				{
					--essais;
					std::cout << "mauvaise réponse il vous reste " << essais << " essais" << std::endl;
				}
			}
			g_lose = 2;
			return 13;
		}
		else
		{
			std::cout << "Vous ne comprenez pas ce qui est écrit et retournez à l'entrée de la salle." << std::endl;
			std::cin >> choix;
			return 5;
		}
		

	}
	else if (choix == "2")
	{
		if (g_power = 2)
		{
			std::cout << "Vous vous approchez de la porte et remarquez que votre épée commence à briller." << endl
				<< "Vous remarquez aussi que l'indentation en forme d'épée dans la porte se transforme pour prendre les proportions de votre épée." << std::endl;
			std::cout << "Choisir: Pour placer votre épée dans l'indentation [1], pour partir [2]" << std::endl;
			std::cin >> choix;
			if (choix == "1")
			{
				std::cout << "Vous placer votre épée dans l'indentation et une lumière vous entoure et vous force à fermer vos yeux" << std::endl;
				return 7;
			}
			else if (choix == "2")
			{
				return 5;
			}
		}
		else
		{
			std::cout << "Vous ne réussissez pas à ouvrir la porte et retournez à l'entrée de la salle." << std::endl;
			std::cin >> choix;
			return 5;
		}

	}
	else if (choix == "3")
	{
		std::cout << "Vous décidez de retourner dans la salle avec le coffre." << std::endl;
		std::cin >> choix;
		return 3;
	}
	else
	{
		return 5;
	}
}

int block6_Livre()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Devant vous se trouve deux portes l'une à coté de l'autre au dessus de la première est inscrit MAGE et sur la deuxième SAGE" << std::endl;
	std::cout << "Choisir: Pour entrer dans la première porte [1], pour la seconde [2]" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{
		g_power = 5;
		return 8;

	}
	else if (choix == "2")
	{
		g_power = 6;
		return 9;
	}
	else
	{
		return 6;
	}
}

int block7_Warrior()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Quand vous entrez une voix vous dit:" << std::endl;
	SetConsoleTextAttribute(hConsole, 3);
	std::cout << "Deux chemins s'ouvrent à vous commander une armée contre une autre ou vaincre une créature en combat singulier." << std::endl;
	SetConsoleTextAttribute(hConsole, 7);
	std::cout << "Devant vous se trouve deux portes l'une à coté de l'autre au-dessus de la première est inscrit ARMÉE et sur la deuxième COMBAT" << std::endl;
	std::cout << "Choisir: Pour entrer dans la première porte [1], pour la seconde [2]" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{

		return 10;
	}
	else if (choix == "2")
	{
		return 11;
	}
	else
	{
		return 7;
	}
}

int block8_Mage()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Quand vous entrez votre livre brille pour quelques secondes et sur la couverture vous pouvez lire le mot magie. " << endl;
	std::cout << "Quelques secondes plus tard une voix vous dit:" << std::endl;
	SetConsoleTextAttribute(hConsole, 3);
	std::cout << "Un magicien est plus adapté à combattre des créatures que de commander une armée mais le choix est vôtre." << std::endl;
	SetConsoleTextAttribute(hConsole, 7);
	std::cout << "Devant vous se trouve deux portes l'une à coté de l'autre au-dessus de la première est inscrit ARMÉE et sur la deuxième COMBAT" << std::endl;
	std::cout << "Choisir: Pour entrer dans la première porte [1], pour la seconde [2]" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{
		return 10;

	}
	else if (choix == "2")
	{
		return 11;
	}
	else
	{
		return 8;
	}
}

int block9_Sage()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Quand vous entrez votre livre brille pour quelques secondes et sur la couverture vous pouvez lire le mot sage. " << endl;
	std::cout << "Quelques secondes plus tard une voix vous dit:" << std::endl;
	SetConsoleTextAttribute(hConsole, 3);
	std::cout << "Un sage est plus adapté à commander une armée qu'à combattre des créatures mais le choix est vôtre." << std::endl;
	SetConsoleTextAttribute(hConsole, 7);
	std::cout << "Devant vous se trouve deux portes l'une à coté de l'autre au-dessus de la première est inscrit ARMÉE et sur la deuxième COMBAT" << std::endl;
	std::cout << "Choisir: Pour entrer dans la première porte [1], pour la seconde [2]" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "1")
	{
		return 10;

	}
	else if (choix == "2")
	{
		return 11;
	}
	else
	{
		return 9;
	}
}

int block10_Armee()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Vous vous retrouvez dans une tente vide, à l'exception d'une table sur laquelle se trouve une carte stratégique et des pièces qui bouges" << std::endl;
	std::cout << "Vous savez immédiatement quelles pièces sont les vôtres et comment les commander. " << std::endl;
	std::cout << "Vous savez aussi que si vous sortez de la tente vous pourrez commander vos troupes depuis le front" << std::endl;
	std::cout << "Choisir: Pour commander votre armée depuis la tente [1], pour sortir combattre avec votre armée [2]" << std::endl;
	std::string choix;
	std::cin >> choix;

	int de = d100(hasard);
	if (choix == "1")
	{
		
		if (g_power == 6 && de >= 10)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 10" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 6 && de < 10)
		{
			std::cout << "Défaite! " << de << " est plus petit que 10" << std::endl;
			std::cin >> choix;
			g_lose = 3;
			return 13;
		}

		else if (g_power == 5 && de >= 80)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 80" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 5 && de < 80)
		{
			std::cout << "Défaite! " << de << " est plus petit que 80" << std::endl;
			std::cin >> choix;
			g_lose = 3;
			return 13;
		}

		else if (g_power == 2 && de >= 50)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 50" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 2 && de < 50)
		{
			std::cout << "Défaite! " << de << " est plus petit que 50" << std::endl;
			std::cin >> choix;
			g_lose = 3;
			return 13;
		}

	}
	else if (choix == "2")
	{
		if (g_power == 6 && de >= 80)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 80" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 6 && de < 80)
		{
			std::cout << "Défaite! " << de << " est plus petit que 80" << std::endl;
			std::cin >> choix;
			g_lose = 4;
			return 13;
		}

		else if (g_power == 5 && de >= 10)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 10" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 5 && de < 10)
		{
			std::cout << "Défaite! " << de << " est plus petit que 10" << std::endl;
			std::cin >> choix;
			g_lose = 4;
			return 13;
		}

		else if (g_power == 2 && de >= 50)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 50" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 2 && de < 50)
		{
			std::cout << "Défaite! " << de << " est plus petit que 50" << std::endl;
			std::cin >> choix;
			g_lose = 4;
			return 13;
		}
	}
	else
	{
		return 10;
	}
}

int block11_Combat()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Vous vous retrouvez dans une grande salle au milieu de laquelle se trouve une hydre" << std::endl;
	std::cout << "Votre combat est aussi impressionnant que difficile et des légendes de ce moment sont sûres d'être raconté pour des milliers d'années" << std::endl;
	std::cout << "Une attaque s'approche de vous et vous devez l'éviter soit vers la gauche ou vers la droite" << std::endl;
	std::cout << "Choisir: Pour évader vers la gauche [1], pour évader vers la droite [2]" << std::endl;
	std::string choix;
	std::cin >> choix;

	int de = d100(hasard);
	if (choix == "1")
	{

		if (g_power == 6 && de >= 80)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 80" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 6 && de < 80)
		{
			std::cout << "Défaite! " << de << " est plus petit que 80" << std::endl;
			std::cin >> choix;
			g_lose = 5;
			return 13;
		}

		else if (g_power == 5 && de >= 20)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 20" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 5 && de < 20)
		{
			std::cout << "Défaite! " << de << " est plus petit que 20" << std::endl;
			std::cin >> choix;
			g_lose = 5;
			return 13;
		}

		else if (g_power == 2 && de >= 50)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 50" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 2 && de < 50)
		{
			std::cout << "Défaite! " << de << " est plus petit que 50" << std::endl;
			std::cin >> choix;
			g_lose = 5;
			return 13;
		}

	}
	else if (choix == "2")
	{
		if (g_power == 6 && de >= 80)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 80" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 6 && de < 80)
		{
			std::cout << "Défaite! " << de << " est plus petit que 80" << std::endl;
			std::cin >> choix;
			g_lose = 6;
			return 13;
		}

		else if (g_power == 5 && de >= 20)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 20" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 5 && de < 20)
		{
			std::cout << "Défaite! " << de << " est plus petit que 20" << std::endl;
			std::cin >> choix;
			g_lose = 6;
			return 13;
		}

		else if (g_power == 2 && de >= 50)
		{
			std::cout << "Victoire! " << de << " plus grand ou égale à 50" << std::endl;
			std::cin >> choix;
			return 12;
		}
		else if (g_power == 2 && de < 50)
		{
			std::cout << "Défaite! " << de << " est plus petit que 50" << std::endl;
			std::cin >> choix;
			g_lose = 6;
			return 13;
		}
	}
	else
	{
		return 11;
	}
}

int block12_victoire()
{
	std::cout << "-------------" << std::endl;
	std::cout << "Vous franchisez la porte et vous retrouver dans une grande halle au plancher de marbre et des murs de pierre." << std::endl;
	std::cout << "Le long des murs, vous remarquez des trônes sur lesquels des hommes et femmes semblent soit regarder des cartes soit jouer les uns contre les autres" << std::endl;
	std::cout << "Vous voyez un trône vide et en vous y approchant vous remarquer votre nom inscrit sur le trône et une lettre sur une table devant le trône." << std::endl;
	std::cout << "N'ayant rien de mieux à faire, vous prenez la lettre et vous assoyez pour la lire." << std::endl;
	SetConsoleTextAttribute(hConsole, 2);
	std::cout << "Félicitations, vous avez réussi votre défi, prenez vos cartes et jouez." << std::endl;
	SetConsoleTextAttribute(hConsole, 7);
	std::cout << "Choisir: recommencer ou quitter" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "recommencer")
	{
		Restart();
		return 0;
	}
	else if (choix == "quitter")
	{
		exit(0);
	}
	else
	{
		return 12;
	}
}

int block13_defaite()
{
	std::cout << "-------------" << std::endl;
	if (g_lose == 1)
	{
		std::cout << "La dernière chose que vous voyez, c'est la porte qui s'ouvre et une épée qui transperce votre torse et vous empale sur le mur." << std::endl;
	}
	else if (g_lose == 2)
	{
		std::cout << "Vous entendez une voix dire < MAUVAISE RÉPONSE > et soudainement les ombres de la pièce se jettent sur vous et vous perdez conscience" << std::endl;
	}
	else if (g_lose == 3)
	{
		std::cout << "Vous voyez les dernières de vos pièces fuir la carte et les pièces ennemies entourer votre tente. Vous entendez une explosion et plus rien" << std::endl;
	}
	else if (g_lose == 4)
	{
		std::cout << "Alors que vous tentez de reprendre le contrôle de vos soldats en fuite. Vous entendez une explosion et plus rien" << std::endl;
	}
	else if (g_lose == 5)
	{
		std::cout << "Vous tenter d'évité une attaque en sautant vers la gauche, mais vous êtes trop lents et la dernière chose que vous resentez c'est une douleur intense" << std::endl;
	}
	else if (g_lose == 6)
	{
		std::cout << "Vous tenter d'éviter une attaque en sautant vers la droite, mais vous êtes trop lents et la dernière chose que vous resentez c'est une douleur intense" << std::endl;
	}
	std::cout << "Choisir: recommencer ou quitter" << std::endl;
	std::string choix;
	std::cin >> choix;

	if (choix == "recommencer")
	{
		Restart();
		return 0;
	}
	else if (choix == "quitter")
	{
		exit(0);
	}
	else
	{
		return 13;
	}
}

void Restart()
{
	system("cls");
	g_start = true;
	g_chest = false;
	g_power = 0;
	g_seen = 0;

}