#include <memory>
#include <iostream>

using std::shared_ptr;
using std::weak_ptr;
using std::cout;
using std::endl;

class A;
class B;

class A
{
public:
	weak_ptr<B> myB;
};

class B
{
public:
	weak_ptr<A> myA;

	void Function1() 
	{
		std::cout << "Class B" << endl;
	}
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

	// a->myB->  ??
	// a->myB.   ??
	a->myB.lock()->Function1();

	shared_ptr<B> myB(a->myB);
	myB->Function1();
	myB.reset();

	// Si myB n'existe pas?
	b.reset();
	if (a->myB.lock()) 
	{
		cout << "FW" << endl;
	}

	a.reset();

	system("pause");
}