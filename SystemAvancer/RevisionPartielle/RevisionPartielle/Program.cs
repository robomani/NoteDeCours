using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RevisionPartielle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tableau a une dimention
            //Lorce qu'on declare la variable il n'est pas necessaire de spécifier la taille du tableau
            int[] monTableau;
            //Lorsqu'on instentie le tableau il faut specifier la taille
            monTableau = new int[42];

            //tableau a deux dimentions
            int[,] monTableau2D;
            monTableau2D = new int[42, 10];
            monTableau2D[3, 5] = 100;

            for (int i = 0; i < monTableau2D.GetLength(0); i++)
            {
                for (int x = 0; x < monTableau2D.GetLength(1); x++)
                {
                    monTableau2D[i, x] = i + x;
                    Console.WriteLine($"[{i},{x}] = {monTableau2D[i, x]}");
                }
            }

            //On peut cree une instence de inventorySection de type Weapon car weapon hérite de inventoryItem
            InventorySection<Weapon> weapons = new InventorySection<Weapon>();
            //weapons.Add(new Weapon());

            //-------------------------------------------------------------------------------------------------------------------------
            //Serialisation
            //-------------------------------------------------------------------------------------------------------------------------

            string fileContent = File.ReadAllText("people.json");

            Person[] pepole = JsonConvert.DeserializeObject<Person[]>(fileContent);

            foreach (Person item in pepole)
            {
                Console.WriteLine($"First name : {item.first_name} / Last name : {item.last_name} / Gender : {item.gender} / Age : {item.age}");
            }

            //-------------------------------------------------------------------------------------------------------------------------------
            //LinQ
            //-------------------------------------------------------------------------------------------------------------------------------

            // IEnumarable<X> maQuery = from x in List
            //                          where x.age > 10
            //                          orderby x.age descending
            //                          select x

            Console.WriteLine("");
            IEnumerable<Person> adultList = from Person in pepole
                                            where Person.age >= 18
                                            orderby Person.age
                                            select Person;

            foreach (Person adult in adultList)
            {
                Console.WriteLine($"First name : {adult.first_name} / Last name : {adult.last_name} / Gender : {adult.gender} / Age : {adult.age}");
            }

            //-------------------------------------------------------------------------------------------------------------------------------------
            //Lambda
            //-------------------------------------------------------------------------------------------------------------------------------------

            Func<int, int, int> myFunction = (int a, int b) => { return a + b; };
            // ==
            Func<int, int, int> myFunction2 = (a, b) =>  a + b;
            Console.WriteLine("");
            Console.WriteLine("Result : " + myFunction(2,5));
            Console.WriteLine("Result : " + myFunction2(2, 5));

            //-------------------------------------------------------------------------------------------------------------------------------------
            //Attributes
            //-------------------------------------------------------------------------------------------------------------------------------------
            //Pour aller chercher des informations sur le code au runtime (Par exemple, les attributes), on utilise une technique nommées la Reflexion (Reflection)


            //-------------------------------------------------------------------------------------------------------------------------------------
            //Methode d'extention
            //-------------------------------------------------------------------------------------------------------------------------------------

            Console.WriteLine("42 is enven ? " + 42.IsEven());
            Console.WriteLine("7 is enven ? " + 7.IsEven());

            Console.ReadKey();

        }


        //-------------------------------------------------------------------------------------------------------------------------------------
        //Attributes
        //-------------------------------------------------------------------------------------------------------------------------------------

        [Comment("ceci est une methode")]
        void MaMethode()
        {

        }

        [Comment]
        void MaMethode2()
        {

        }
    }
}
