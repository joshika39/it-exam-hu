using System;
using System.Collections.Generic;
using System.IO;

namespace _2018_10
{
    public struct Utca
    {
        public int parosVparatlan;
        public int szelesseg { get; set; }
        public string kerites { get; set; }
        public int hazszam { get; set; }

        public Utca(string sor) : this()
        {
            var adatok = sor.Split(' ');

            parosVparatlan = int.Parse(adatok[0]);
            szelesseg = int.Parse(adatok[1]);
            kerites = adatok[2];
            hazszam = 0;

        }
    }

    internal class Program
    {



        static void Main(string[] args)
        {
            var hazakLista = new List<Utca>();

            var sorok = File.ReadLines("../../../kerites.txt");

            foreach (var sor in sorok)
            {
                var ideiglenesHaz = new Utca(sor);
                hazakLista.Add(ideiglenesHaz);

            }

            var hazak = hazakLista.ToArray();

            //2.feladat
            Console.WriteLine("2. feladat");
            var osszhaz = 0;
            for (int i = 0; i < hazak.Length; i++)
            {
                osszhaz++;
            }
            Console.WriteLine(osszhaz);

            //3.feladat
            Console.WriteLine("\n3. feladat");
            var utolso = hazak.Length - 1;

            if (hazak[utolso].parosVparatlan == 0)
            {
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
            }
            else
            {
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");

            }
            var parosak = 0;
            var paratlanok = -1;

            for (int i = 0; i < hazak.Length; i++)
            {
                if (hazak[i].parosVparatlan == 0)
                {
                    parosak += 2;
                    hazak[i].hazszam = parosak;
                }
                if (hazak[i].parosVparatlan == 1)
                {
                    paratlanok += 2;
                    hazak[i].hazszam = paratlanok;
                }
            }
            if (hazak[utolso].parosVparatlan == 0)
            {
                Console.WriteLine($"Az utolsó telek házszáma: {parosak}");
            }
            else
            {
                Console.WriteLine($"Az utolsó telek házszáma: {paratlanok}");

            }
            //4.feladat
            Console.WriteLine("\n4. feladat");

            var ugyanolyanid = 0;

            for (var i = 0; i < hazak.Length; i++)
            {
                if(hazak[i].hazszam % 2 != 0)
                {
                    if (i + 2 < hazak.Length)
                    {
                        if (hazak[i].kerites == hazak[i].kerites && (hazak[i].kerites != ":" || hazak[i].kerites != "#"))
                        {
                            Console.WriteLine(hazak[i].hazszam);
                        }
                    }
                }
            }
            //hazak[1].hazszam = 2;

        }
    }
}
