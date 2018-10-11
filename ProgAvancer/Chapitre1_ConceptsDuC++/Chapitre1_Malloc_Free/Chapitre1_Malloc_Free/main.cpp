#include <malloc.h>

int main() {
	int *p; // pointeur sur un entier
	int *T; // pointeur sur un entier

	// allocation dynamique d�un entier
	p = (int *)malloc(sizeof(int)); // alloue 4 octets (= int) en m�moire

	*p = 1; // ecrit 1 dans la zone m�moire allou�e
	
	// allocation dynamique d�un tableau de 10 int
	T = (int *)malloc(sizeof(int) * 10); // alloue 4 * 10 octets en m�moire
										 
	// initialise le tableau avec des 0 (cf. la fonction memset)
	for (int i = 0; i < 10; i++) {
		*(T + i) = 0; // les 2 �critures sont possibles
		T[i] = 0; // identique � la ligne pr�c�dente
	}

	// liberation des espaces m�moire allou�e dynamiquement.
	free(p);
	free(T);
}