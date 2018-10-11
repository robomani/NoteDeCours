#include <iostream>

int main()
{
	int var = 10;
	std::cout << "Adresse de var : " << &var << std::endl;

	int i;
	std::cout << "Adresse: ";
	std::cin >> std::hex >> i >> std::dec;
	std::cout << "Contenu: " << *(reinterpret_cast<int*>(i));

	system("pause");
	return 0;
}