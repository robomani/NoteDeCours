#include <memory>
#include <iostream>

using std::shared_ptr;
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
	shared_ptr<A> a(new A());
	shared_ptr<B> b(new B());
	cout << a.use_count() << ", " << b.use_count() << endl;
	a->myB = b;
	cout << a.use_count() << ", " << b.use_count() << endl;
	b->myA = a;
	cout << a.use_count() << ", " << b.use_count() << endl;
	a.reset();
	cout << b.use_count() << endl;
	b.reset();

	system("pause");
}