#include <iostream>
#include <memory>

using std::shared_ptr;
using std::make_shared;
using std::cout;
using std::endl;

class A;
class B;

class A
{
public:
	shared_ptr<B> myB;
};

class B
{
public:
	shared_ptr<A> myA;
};

int main()
{
	shared_ptr<A> a = make_shared<A>();
	shared_ptr<B> b = make_shared<B>();

	cout << a.use_count() << ", " << b.use_count() << endl; 
	a->myB = b;
	cout << a.use_count() << ", " << b.use_count() << endl;
	b->myA = a;
	cout << a.use_count() << ", " << b.use_count() << endl;
	a.reset();
	a = nullptr;
	cout << b.use_count() << endl;
	b.reset();
	b = nullptr;

	system("pause");
	return 0;
}