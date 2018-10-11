#include "tinyxml2.h";
#include <string>;
#include <iostream>;

using namespace tinyxml2;

XMLDocument& CreateDocument();
void SaveXML(XMLDocument& XMLDoc, const std::string filename);
void WriteIntXML(XMLDocument& XMLDoc);
void WriteStringXML(XMLDocument& XMLDoc);
void ReadXML(const std::string filename);

int main()
{
	//create the xml documment instance
	XMLDocument& xmlDoc = CreateDocument();
	
	WriteIntXML(xmlDoc);
	WriteStringXML(xmlDoc);
	SaveXML(xmlDoc,"file.xml");

	ReadXML("file.xml");

	system("pause");
	return 0;
}

XMLDocument& CreateDocument()
{
	XMLDocument* xmlDoc = new XMLDocument();
	XMLElement* root = xmlDoc->NewElement("root");
	xmlDoc->InsertFirstChild(root);


	return *xmlDoc;
}


void SaveXML(XMLDocument& xmlDoc, const std::string filename)
{
	if (xmlDoc.SaveFile(filename.c_str()) == tinyxml2::XML_SUCCESS)
	{
		std::cout << "Save Success!" << std::endl;
	}
	else
	{
		std::cout << "Save Failed!" << std::endl;
	}
	
}

void WriteIntXML(XMLDocument& xmlDoc)
{
	XMLNode* intsElement = xmlDoc.NewElement("ints");
	for (int i = 0; i < 5; i++)
	{
		XMLElement* intElement = xmlDoc.NewElement("int");
		intElement->SetAttribute("index", i);
		intsElement->InsertEndChild(intElement);
	}

	xmlDoc.FirstChildElement()->InsertEndChild(intsElement);
	//<ints>
	//	<int index="0">0</int>
	//</ints>
}

void WriteStringXML(XMLDocument& XMLDoc)
{
	XMLNode* stringsElement = XMLDoc.NewElement("strings");
	for (int i = 0; i < 5; i++)
	{
		XMLElement* Element = XMLDoc.NewElement("string");
		Element->SetAttribute("index", i);
		Element->SetText(("string #" + std::to_string(i)).c_str());
		stringsElement->InsertEndChild(Element);
	}
	XMLDoc.FirstChildElement()->InsertEndChild(stringsElement);
}

void ReadXML(const std::string filename)
{
	XMLDocument xmlDoc;
	xmlDoc.LoadFile(filename.c_str());

	XMLElement* root = xmlDoc.FirstChildElement();
	XMLElement* intsElements = root->FirstChildElement("ints");

	XMLElement* element = intsElements->FirstChildElement();
	std::cout << "List of ints:" << std::endl;
	while (element != nullptr)
	{
		int intValue;
		if (element->QueryIntAttribute("index", &intValue) == XML_SUCCESS)
		{
			std::cout << intValue << std::endl;
		}

		element = element->NextSiblingElement();
	}

	XMLElement* stringElement = root->FirstChildElement("strings");
	element = stringElement->FirstChildElement();
	std::cout << "List of strings:" << std::endl;
	while (element != nullptr)
	{
		int intValue;
		if (element->QueryIntAttribute("index", &intValue) == XML_SUCCESS)
		{
			std::cout << element->GetText() << ": ";
			if (element->QueryIntAttribute("index", &intValue) == XML_SUCCESS)
			{
				std::cout << intValue;
			}
			std::cout << std::endl;
		}
		element = element->NextSiblingElement();
	}

}