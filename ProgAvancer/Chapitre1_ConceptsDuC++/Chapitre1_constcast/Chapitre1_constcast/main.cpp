int main() 
{
	char* buf = new char[16];

	// L'ajout de l'attribut const ne nécessite pas de cast
	// Il est implicite
	const char* cbuf = buf;

	// Le retrait de l'attribut const nécessite const_cast&lt;&gt;.
	char* buf2 = const_cast<char*>(cbuf);

	return 0;
}