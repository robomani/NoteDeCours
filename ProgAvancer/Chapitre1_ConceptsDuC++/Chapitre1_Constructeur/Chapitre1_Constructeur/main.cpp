class Toto 
{
public:
	Toto(int, char, float);

private:
	int age;
	char sexe;
	float taille;
};

Toto::Toto(int age, char sexe, float taille) 
{
	this->age = age;
	this->sexe = sexe;
	this->taille = taille;
}