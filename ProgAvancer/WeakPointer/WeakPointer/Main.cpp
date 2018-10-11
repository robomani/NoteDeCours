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
		cout << "Class B" << endl;
	}
};

int main()
{
	shared_ptr<A> a = std::make_shared<A>(); 
	shared_ptr<B> b = std::make_shared<B>();

	cout << a.use_count() << ", " << b.use_count() << endl;
	a->myB = b;
	cout << a.use_count() << ", " << b.use_count() << endl;
	b->myA = a;
	cout << a.use_count() << ", " << b.use_count() << endl;

	b->Function1();
	a->myB.lock()->Function1();

	shared_ptr<B> myB(a->myB);
	myB->Function1();
	myB.reset();

	b.reset();
	if (a->myB.lock() == nullptr)
	{
		cout << "Nullptr" << endl;
	}



	system("pause");
	return 0;
}