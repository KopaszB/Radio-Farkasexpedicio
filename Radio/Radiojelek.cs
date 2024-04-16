using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Radio
{
    class Radiojelek
    {
        int nap;
        int ramator;
        string uzenet;

        struct Adat
        {
            public int Nap { get; set; }
            public int Ramator { get; set; }
            public string Uzenet { get; set; }
        }

        static void Main() 
        {
            string sor;
            string[] elemek;
            List<Adat> vetel = new List<Adat>();

            using (StreamReader olvaso = new StreamReader("veetel.txt"))
            {
                while ((sor = olvaso.ReadLine()) != null)
                {
                    elemek = sor.Split(' ');
                    Adat ujadat = new Adat();
                    ujadat.Nap = int.Parse(elemek[0]);
                    ujadat.Ramator = int.Parse(elemek[1]); 
                    ujadat.Uzenet = olvaso.ReadLine();
                    vetel.Add(ujadat);
                }
            }

            //2.feladat
            Console.WriteLine();
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"    Az első üzenet rögzítője: {vetel[0].Ramator}");
            Console.WriteLine($"    Az utolsó üzenet rögzítője: {vetel[vetel.Count()-1].Ramator}");


            //3.feladat
            Console.WriteLine();
            Console.WriteLine("3. feladat:");
            for (int i = 0; i < vetel.Count(); i++)
            {
                if (vetel[i].Uzenet.Contains("farkas"))
                {
                    Console.WriteLine($"    {vetel[i].Nap}. nap {vetel[i].Ramator}. rádióamatőr");
                }
            }

            //4.feladat
            Console.WriteLine();
            Console.WriteLine("4. feladat:");
            int amatorszam = 0;
            for (int i = 1; i < 12; i++)
            {
                for (int j = 0; j < vetel.Count(); j++)
                {
                    if (vetel[j].Nap == i)
                    {
                        amatorszam++;
                    }
                }
                Console.WriteLine($"    {i}. nap: {amatorszam} rádióamatőr");
                amatorszam = 0;
            }
            //5.feladat - 1.rész
            Console.WriteLine();
            Console.WriteLine("5. feladat:");
            using (StreamWriter iro = new StreamWriter("adaas.txt"))
            {
                for (int i = 1; i < 12; i++)
                {
                        for (int j = 0; j < vetel.Count(); j++)
                        {
                            if (vetel[j].Nap == i)
                            {

                                iro.WriteLine($"{i} {vetel[j].Ramator}"); 
                                iro.WriteLine($"{vetel[j].Uzenet}");
                            }
                        }
                }
            }
            //5.feladat - 2.rész
            List<Adat> rendezettvetel = new List<Adat>();

            using (StreamReader olvaso = new StreamReader("adaas.txt"))
            {
                while ((sor = olvaso.ReadLine()) != null)
                {
                    elemek = sor.Split(' ');
                    Adat ujadat = new Adat();
                    ujadat.Nap = int.Parse(elemek[0]);
                    ujadat.Ramator = int.Parse(elemek[1]);
                    ujadat.Uzenet = olvaso.ReadLine();
                    rendezettvetel.Add(ujadat);
                }
            }
            List<int> uzenetszam = new List<int>();
            int sorszam = rendezettvetel[0].Nap;
            int szamlalo = 0;
            for (int i = 0; i < rendezettvetel.Count(); i++)
            {
                if (rendezettvetel[i].Nap == sorszam)
                {
                    szamlalo++;
                }
                else
                {
                   
                    uzenetszam.Add(szamlalo);
                    sorszam = rendezettvetel[i].Nap;
                    szamlalo = 1;                    
                }
       
            }
            int a = 0;
            int b = 0;
            for (int i = 0; i < uzenetszam.Count(); i++)
            {
                a = b;
                b = a + uzenetszam[i];
                Console.WriteLine($"{i+1}/{uzenetszam[i]} sor: {a} - {b}");
            }

            for (int i = 0; i < 90; i++)
            {
                for (int j = 0; j < uzenetszam[1]-1; j++)
                {
                    char csere = '#';
                    if (rendezettvetel[j].Uzenet[i] != '#')
                    {
                        csere = rendezettvetel[j].Uzenet[i];
                        Console.Write($"{csere} ");
                        break;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Masodik sor:");
            for (int i = 0; i < 90; i++)
            {
                for (int j = uzenetszam[1]; j < uzenetszam[1]+uzenetszam[2]-1; j++)
                {
                    char csere = '#';
                    if (rendezettvetel[j].Uzenet[i] != '#')
                    {
                        csere = rendezettvetel[j].Uzenet[i];
                        Console.Write($"{csere} ");
                        break;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Harmadik sor:");
            for (int i = 0; i < 90; i++)
            {
                for (int j = uzenetszam[2]; j < uzenetszam[2] + uzenetszam[3]-1; j++)
                {
                    char csere = '#';
                    if (rendezettvetel[j].Uzenet[i] != '#')
                    {
                        csere = rendezettvetel[j].Uzenet[i];
                        Console.Write($"{csere} ");
                        break;
                    }
                }
            }



            //Console.WriteLine($"{rendezettvetel[0].Nap} - {rendezettvetel[0].Uzenet}");
            Console.ReadKey();
        }

    }
}
