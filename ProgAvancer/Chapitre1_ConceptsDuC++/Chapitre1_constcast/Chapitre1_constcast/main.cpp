int main() 
{
	char* buf = new char[16];

	// L'ajout de l'attribut const ne n�cessite pas de cast
	// Il est implicite
	const char* cbuf = buf;

	// Le retrait de l'attribut const n�cessite const_cast&lt;&gt;.
	char* buf2 = const_cast<char*>(cbuf);

	return 0;
}