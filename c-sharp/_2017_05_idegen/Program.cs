using System;
using System.Collections.Generic;
using System.IO;

namespace _2017_05_idegen
{
    struct Furdozo
    {
        public int id;
        public int reszlegid;
        public int beki;
        public int ora;
        public int perc;
        public int mp;
        public int ido;

        public Furdozo(string sor) : this()
        {
            var adatok = sor.Split(' ');
            id = int.Parse(adatok[0]);
            reszlegid = int.Parse(adatok[1]);
            beki = int.Parse(adatok[2]);
            ora = int.Parse(adatok[3]);
            perc = int.Parse(adatok[4]);
            mp = int.Parse(adatok[5]);
            ido = mp + perc * 60 + (ora * 60 * 60);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var furdozok = new List<Furdozo>();

            var sorok = File.ReadLines("../../../furdoadat.txt");

            foreach (var sor in sorok)
            {
                var ideiglenesFurdozo = new Furdozo(sor);
                furdozok.Add(ideiglenesFurdozo);
            }


            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az első vendég {furdozok[0].ora}:{furdozok[0].perc}:{furdozok[0].mp}-kor lépett ki az öltözőből.");


            var ora = 0;
            var perc = 0;
            var mp = 0;

            //furdozok[i].beki == 1 && furdozok[i].reszlegid == 0
            for (int i = 0; i < furdozok.Count; i++)
            {
                if (furdozok[i].ora >= ora && furdozok[i].beki == 1 && furdozok[i].reszlegid == 0)
                {
                    ora = furdozok[i].ora;
                }

            }
            for (int i = 0; i < furdozok.Count; i++)
            {
                if (furdozok[i].perc >= perc && furdozok[i].ora == ora && furdozok[i].beki == 1 && furdozok[i].reszlegid == 0)
                {
                    perc = furdozok[i].perc;
                }

            }
            for (int i = 0; i < furdozok.Count; i++)
            {
                if (furdozok[i].mp >= mp && furdozok[i].perc == perc && furdozok[i].ora == ora && furdozok[i].beki == 1 && furdozok[i].reszlegid == 0)
                {
                    mp = furdozok[i].mp;
                }

            }
            Console.WriteLine($"Az utolsó vendég {ora}:{perc}:{mp}-kor lépett ki az öltözőből.");

            Console.WriteLine("\n3. feladat");
            var egyreszenjart = 0;
            var tomb = new int[1000];
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = 0;
            }

            for (int i = 0; i < furdozok.Count; i++)
            {
                var szemelyek = furdozok[i].id;
                tomb[szemelyek]++;
            }

            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] > 0)
                {
                    if (tomb[i] == 4)
                    {
                        egyreszenjart++;
                    }
                }
            }
            Console.WriteLine($"A fürdőben {egyreszenjart} vendég járt csak egy részlegen./n");

            Console.WriteLine("4. feladat");


            var legtobbido = 0;
            var legtobbId = 0;

            var tomb2 = new int[1000];
            for (int i = 0; i < tomb2.Length; i++)
            {
                tomb2[i] = 0;
            }

            var kezdes = 0;

            for (int i = 0; i < furdozok.Count; i++)
            {
                var pillantnyiIdo = furdozok[i].ido;
                var id = furdozok[i].id;
                var test = kezdes;

                if (furdozok[i].reszlegid == 0 && furdozok[i].beki == 1)
                {
                    kezdes = pillantnyiIdo;
                }
               
                if (furdozok[i].reszlegid == 0 && furdozok[i].beki == 0)
                {
                    tomb2[id] += pillantnyiIdo - kezdes;
                    kezdes = 0;
                }

            }

            for (int i = tomb2.Length - 1; i >= 0; i--)
            {
                if (tomb2[i] > 0)
                {
                    if (tomb2[i] >= legtobbido)
                    {
                        legtobbido = tomb2[i];
                        legtobbId = i;
                    }
                }
            }
            Console.WriteLine(legtobbId);

            //for (int i = 0; i < furdozok.Count; i++)
            //{
            //    var szemely = furdozok[i];
            //    for (int j = 0; j < furdozok.Count; j++)
            //    {
            //        if(szemely.id == furdozok[j].id)
            //        {

            //        }
            //    }
            //}
        }
    }
}
