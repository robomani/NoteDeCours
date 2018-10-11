#include <memory>
#include <iostream>

using std::shared_ptr;
using std::make_shared;
using std::cout;
using std::endl;

void fonction1(const shared_ptr<int> a);

int main()
{
	shared_ptr<int> a(new int(42));
	cout << a.use_count() << endl;

	shared_ptr<int> b = a;
	cout << a.use_count() << endl;

	fonction1(a);

	cout << a.use_count() << endl;
	b.reset();
	cout << a.use_count() << endl;

	system("pause");
}

void fonction1(const shared_ptr<int> a) 
{
	shared_ptr<int> c;
	shared_ptr<int> d = make_shared<int>(56);
	c = a;
	cout << a.use_count() << endl;
	d = c;
	cout << a.use_count() << endl;
}