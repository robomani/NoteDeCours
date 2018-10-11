#include <stdio.h>
#include <malloc.h>

void add_fish_pp(int** p);
int* add_fish_p(int* p);

int main(void)
{
	int* p = NULL;

	add_fish_pp(&p);    // On utilise un pointeur sur le paramètre envoyé
	p = add_fish_p(p);  // On utilise le retour de la fonction

	return 0;
}

void add_fish_pp(int** p)
{
	*p = (int*)malloc(sizeof(int));
}

int* add_fish_p(int* p)
{
	p = (int*)malloc(sizeof(int));
	return p;
}
