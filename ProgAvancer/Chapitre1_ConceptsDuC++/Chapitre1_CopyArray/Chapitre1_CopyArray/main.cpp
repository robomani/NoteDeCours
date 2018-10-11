#include <iostream>

using std::cout;
using std::endl;

void AfficheTableau(int* t) {
	while (*t++) {
		cout << *t << " ";
	}
	cout << endl;
}

int main() {

	int tableau1[10] = { 5, 3, 9, 11, 4, 132, 45, 2, 89, 0 };
	int tableau2[10] = { -1, -1, -1, -1, -1, -1, -1, -1, -1, 0 };
	int* t1 = tableau1;
	int* t2 = tableau2;

	AfficheTableau(tableau2);

	while (*t2++ = *t1++); // :O

	AfficheTableau(tableau2);

	system("pause");
	return 0;
}