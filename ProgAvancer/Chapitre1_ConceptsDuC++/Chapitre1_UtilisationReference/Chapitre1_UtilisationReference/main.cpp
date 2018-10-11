#include <iostream>

using std::cout;
using std::endl;

int main() {
	int age = 21;
	int &referenceSurAge = age;

	cout << referenceSurAge << endl;
	cout << age << endl;
	
	system("pause");

	referenceSurAge = 40;

	cout << referenceSurAge << endl;
	cout << age << endl;

	system("pause");
	return 0;
}