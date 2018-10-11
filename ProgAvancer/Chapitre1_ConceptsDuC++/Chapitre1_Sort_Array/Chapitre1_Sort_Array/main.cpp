#include <iostream>

using std::cout;
using std::endl;

void Swap(int* val1, int* val2) {
	int temp = *val1;
	*val1 = *val2;
	*val2 = temp;
}

void PrintTable(int* table, int size) {
	for (int i = 0; i < size; i++) {
		cout << table[i] << " ";
	}
	cout << endl;
}

void Sort(int* table, int size) {
	for (int start = 0; start < size - 1; start++) {
		for (int k = start + 1; k < size; k++) {
			if (table[k] < table[start]) {
				Swap(&table[start], &table[k]);
			}
		}
	}
}

int main() {
	int table[] = { 4, 6, 3, 7, 9, 2, 1, 10, 5, 8 };
	int size = sizeof(table) / sizeof(int);

	PrintTable(table, size);
	Sort(table, size);
	PrintTable(table, size);

	system("pause");
	return 0;
}