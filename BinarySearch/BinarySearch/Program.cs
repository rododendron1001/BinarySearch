using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //nr elemente in array
            //int n = 5;
            bool ok = false;
            int n = 0;
            while (!ok)
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.Write("repeta introducere ");
            }
            //citeste array
            int[] t = citeste_array(n);
            bool ordonat = validare_array(t);
            if (!ordonat)
            {
                Console.WriteLine("Tabloul nu este ordonat crescator, nu se poate face cautare binara!");
            }
            else
            {
                Console.Write("Element pt care se cauta indexul: ");
                //bool ok = false;
                int r = 0;
                while (!ok)
                {
                    ok = Int32.TryParse(Console.ReadLine(), out r);
                    if (!ok) Console.Write("repeta introducere ");
                }
                Console.ReadKey();
                Console.WriteLine($"Index : {r}");
                int l = 0;
                int r1 = t.Length - 1;

                int pozitia = cautare_binara(t, l, r1, r);
                if (pozitia == -1)
                {
                    Console.WriteLine("Elementul cautat nu este in array");
                }
                else
                {
                    Console.WriteLine($"Elementul cautat se gaseste la indexul {pozitia}");
                }
                Console.WriteLine();


                // verificare folosind functia ce foloseste metoda BinarySearch din .NET
                Console.WriteLine("\tVerificare folosind functia care foloseste metoda BinarySearch din .NET");
                int pozitia_dot_net = cautare_binara_dot_net(t, r);
                if (pozitia_dot_net < 0)
                {
                    Console.WriteLine("\tElementul cautat nu este in array");
                }
                else
                {
                    Console.WriteLine($"\tElementul cautat se gaseste la indexul {pozitia_dot_net}");
                }
            }
            Console.WriteLine("Apasa o tasta pt iesire");
            Console.ReadKey();

        }

        //citire array
        static int[] citeste_array(int n)
        {
            Console.WriteLine($"Introduceti un array de {n} elemente ordonat crescator");
            int[] t = new int[n];
            for (int i = 0; i < n; i++)
            {
                int r = 0;
                bool ok = false;
                while (!ok)
                {
                    Console.Write($"element{i}: ");
                    ok = Int32.TryParse(Console.ReadLine(), out r);
                    if (!ok) Console.Write("repeta introducere ");
                }
                t[i] = r;
            }
            return t;

        }


        //verific daca array indeplineste conditia sa fi fost introdus corect, adica ordonat crescator
        static bool validare_array(int[] t)
        {
            bool ordonat = true;
            for (int i = 1; i < t.Length; i++)
                ordonat = ordonat && (t[i] > t[i - 1]);
            return ordonat;
        }


        //algoritmul de cautare binara recursiv, returneaza index elementului cautat sau -1 daca elementul nu e in array
        static int cautare_binara(int[] t, int l, int r1, int cautat)
        {

            int mijloc = l + (r1 - l) / 2;

            if (r1 >= l)
            {
                if (t[mijloc] == cautat) return mijloc;
                if (cautat < t[mijloc])
                {

                    return cautare_binara(t, l, mijloc - 1, cautat);
                }
                else
                {

                    return cautare_binara(t, mijloc + 1, r1, cautat);
                }
            }
            return -1; //returnez -1 daca nu s-a gasit in tablou
        }

        //cautare binara folosind metoda BinarySearach pusa la dispozitie de .NET, returneaza indexul elementului sau o valoare negativa daca nu gaseste
        static int cautare_binara_dot_net(int[] t, int cautat)
        {
            int pozitia_dot_net = Array.BinarySearch(t, cautat); //metoda BinarySearch returneaza nr negativ daca nu gaseste, nu neaparat -1
            return pozitia_dot_net;
        }



    }
}
