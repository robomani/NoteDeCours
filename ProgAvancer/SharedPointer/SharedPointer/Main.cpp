#include <iostream>
#include <memory>

using std::cout;
using std::endl;
using std::shared_ptr;
using std::make_shared;

void fonction1(const shared_ptr<int>& a);

int main()
{
	shared_ptr<int> a(new int(42));
	cout << a.use_count() << endl << endl;

	shared_ptr<int> b = a;
	cout << a.use_count() << endl;
	cout << b.use_count() << endl << endl;

	fonction1(a);

	cout << a.use_count() << endl;
	b.reset();
	b = nullptr;

	cout << a.use_count() << endl;

	system("pause");
	return 0;
}

void fonction1(const shared_ptr<int>& a)
{
	shared_ptr<int> c;
	shared_ptr<int> d = make_shared<int>(56);
	c = a;
	cout << a.use_count() << endl;
	cout << c.use_count() << endl << endl;
	d = c;
	cout << a.use_count() << endl;
	cout << c.use_count() << endl;
	cout << d.use_count() << endl << endl;
}