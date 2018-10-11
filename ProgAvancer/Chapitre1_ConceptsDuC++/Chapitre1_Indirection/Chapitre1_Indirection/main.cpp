#include <iostream>

using std::cout;
using std::endl;

int main() {

	int a = 5, b = 2, c = 17;
	int* p = NULL;

	p = &a;
	cout << "p pointe sur a : " << *p << endl;

	p = &b;
	cout << "puis sur b : " << *p << endl;

	p = &c;
	cout << "et enfin sur c : " << *p << endl;

	system("pause");
	return 0;
}