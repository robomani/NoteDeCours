#include <iostream>

using std::cout;
using std::endl;

void Swap(int a, int b);
void Swap(int* a, int* b);

int main()
{
	int x = 10;
	int y = 15;
	cout << "x = " << x << " y = " << y << endl;
	Swap(x, y);
	cout << "x = " << x << " y = " << y << endl;

	Swap(&x, &y);
	cout << "x = " << x << " y = " << y << endl;

	system("pause");
	return 0;
}

void Swap(int a, int b)
{
	int temp = a;
	a = b;
	b = temp;
}

void Swap(int* a, int* b)
{
	int temp = *a;
	*a = *b;
	*b = temp;
}