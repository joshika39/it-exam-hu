using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2017_05
{
    internal class Program
    {

        private const string _utvonal = "../../../valaszok.txt";
        private static string _valasz;
        private static List<Versenyzo> _versenyzok;
        class Versenyzo
        {
            public string Id { get; set; }
            public string Valaszok { get; set; }
            public int Pont { get; set; }

            public Versenyzo(string id, string valaszok)
            {
                Id = id;
                Valaszok = valaszok;
                Pont = 0;
                for (int i = 0; i < Valaszok.Length; i++)
                {
                    if(i >= 0 && i <= 4)
                    {
                        if (Valaszok[i] == _valasz[i]) Pont += 3;
                    }
                    else if (i >= 5 && i <= 9)
                    {
                        if (Valaszok[i] == _valasz[i]) Pont += 4;

                    }
                    else if (i >= 10 && i <= 12)
                    {
                        if (Valaszok[i] == _valasz[i]) Pont += 5;
                    }
                    else if (i == 13)
                    {
                        if (Valaszok[i] == _valasz[i]) Pont += 6;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            FeladatKiir(1, Feladat1);
            FeladatKiir(2, Feladat2);
            FeladatKiir(3, Feladat3);
            FeladatKiir(5, Feladat5);
            FeladatKiir(7, Feladat7);
        }

        private static void FeladatKiir(int feladatSzam, Action feladat)
        {
            
            Console.Write($"{feladatSzam}. Feladat: ");
            feladat.DynamicInvoke();
            Console.WriteLine("\n");
            
        }
        
        private static void Feladat1()
        {
            _versenyzok = new List<Versenyzo>();
            _valasz = File.ReadLines(_utvonal).First();
            foreach (var sor in File.ReadAllLines(_utvonal))
            {
                var adatok = sor.Split(' ');
                if(adatok.Length > 1)
                    _versenyzok.Add(new Versenyzo(adatok[0], adatok[1]));
            }
            Console.Write("Adatok beolvasa");
        }

        private static void Feladat2()
        {
            Console.Write($"A versenyen {_versenyzok.Count} versenyzo vett reszt");
        }

        private static void Feladat3()
        {
            Console.Write("A versenyzo azonositoja = ");
            var id = Console.ReadLine();
            var versenyzo = _versenyzok.Where(v => v.Id == id).FirstOrDefault();
            Console.WriteLine($"{versenyzo.Valaszok}\t(a versenyző válasza)");

            Console.WriteLine("4. Feladat:");
            Console.WriteLine($"{_valasz}\t(a helyes megoldás)");
            for (int i = 0; i < versenyzo.Valaszok.Length; i++)
            {
                char c = versenyzo.Valaszok[i];
                if (c == _valasz[i]) Console.Write("+"); else Console.Write(" ");
            }
            Console.WriteLine("\t(a versenyző helyes válaszai)");
        }
        
        private static void Feladat5()
        {
            Console.Write("A feladat sorszáma = ");
            var sorszam = int.Parse(Console.ReadLine());
            var joValaszok = 0;

            foreach (var v in _versenyzok)
            {
                if(v.Valaszok[sorszam-1] == _valasz[sorszam - 1])
                {
                    joValaszok++;
                }
            }
            double szazalek = Math.Round((double)joValaszok / (double)_versenyzok.Count * 100, 2);
            Console.WriteLine($"A feladatra {joValaszok} fo valaszolt jol, ami a versenyzok {szazalek}%-a");
        }

        private static void Feladat7()
        {
            var sortedList = _versenyzok.OrderByDescending(x => x.Pont).ToList();

            var hely = 1;
            Console.WriteLine();
            for (int i = 0; i < sortedList.Count; i++)
            {
                Versenyzo v = sortedList[i];
                if(hely <= 3)
                {
                    if (v.Pont == sortedList[i + 1].Pont)
                    {
                        Console.WriteLine($"{hely}. dij ({v.Pont} pont): {v.Id}");
                    }
                    else
                    {
                        Console.WriteLine($"{hely}. dij ({v.Pont} pont): {v.Id}"); hely++;
                    }
                        
                }
                
            }
        }

    }
}
