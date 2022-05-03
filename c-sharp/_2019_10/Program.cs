using System;
using System.Collections.Generic;
using System.IO;

namespace _2019_10
{
    struct Felszallas
    {
        public int Megallohey { get; set; }
        public string IdoBelyeg { get; set; }
        public int JegyAzonosito { get; set; }
        public string Tipus { get; set; }
        public string Ervenyesseg { get; set; }
        public int Darab { get; set; }

        public Felszallas(string adat) : this()
        {
            var adatok = adat.Split(' ');
            Megallohey = int.Parse(adatok[0]);
            IdoBelyeg = adatok[1];
            JegyAzonosito = int.Parse(adatok[2]);
            Tipus = adatok[3];
            if (Tipus == "JGY")
            {
                Ervenyesseg = "-";
                Darab = int.Parse(adatok[4]);
            }
            else
            {
                Ervenyesseg = adatok[4];
                Darab = -1;
            }
        }
    }

    class Program
    {
        static int napokszama(int e1, int h1, int n1, int e2, int h2, int n2)
        {
            int d1, d2;
            h1 = (h1 + 9) % 12;
            e1 -= h1 / 10;
            d1 = 365 * e1 + e1 / 4 - e1 / 100 + e1 / 400 + (h1 * 306 + 5) / 10 + n1 - 1;
            h2 = (h2 + 9) % 12;
            e2 -= h2 / 10;
            d2 = 365 * e2 + e2 / 4 - e2 / 100 + e2 / 400 + (h2 * 306 + 5) / 10 + n2 - 1;

            return d2 - d1;
        }

        static List<Felszallas> felszallasok = new List<Felszallas>();

        static void Main(string[] args)
        {
            FeladatKiir(1, Feladat1, false);
            FeladatKiir(2, Feladat2, true);
            FeladatKiir(3, Feladat3, true);
            FeladatKiir(4, Feladat4, true);
            FeladatKiir(5, Feladat5, true);
            FeladatKiir(7, Feladat7, false);

        }

        static void Mintak()
        {
            Console.WriteLine("20190326".CompareTo("20190325"));
            var testIdo = felszallasok[5].IdoBelyeg;
            var tomb = testIdo.Split('-');
            var datum = tomb[0];
            var ev = datum[0..4];
            var evnekazelsoszama = ev[0];
            Console.WriteLine(evnekazelsoszama);
            Console.WriteLine(felszallasok[5].IdoBelyeg.Split('-')[0].Substring(0, 4)[0]);
        }

        static void Feladat1()
        {
            foreach (var sor in File.ReadLines("../../../utasadat.txt"))
            {
                felszallasok.Add(new Felszallas(sor));
            }
        }
        static void Feladat2()
        {
            var darab = 0;

            foreach (var felszallas in felszallasok)
            {
                darab++;
            }

            Console.WriteLine($"{darab}-an akartak felszallni.");
        }
        static void Feladat3()
        {
            var probalkozas = 0;
            foreach (var felszallas in felszallasok)
            {
                if (felszallas.Tipus == "JGY")
                {
                    if (felszallas.Darab == 0)
                    {
                        probalkozas++;
                    }
                }
                else
                {
                    var datum = felszallas.IdoBelyeg.Split('-')[0];
                    if (datum.CompareTo(felszallas.Ervenyesseg) == 1)
                    {
                        probalkozas++;
                    }
                }
            }
            Console.WriteLine($"Felszallasi problakozasok szama: {probalkozas}");
        }
        static void Feladat4()
        {
            var tomb = new int[30];
            Array.Clear(tomb, 0, tomb.Length);

            for (int i = 0; i < felszallasok.Count; i++)
            {
                var megallo = felszallasok[i].Megallohey;
                tomb[megallo]++;
            }

            var maxFelszallo = 0;
            var maxIndex = 0;

            for (int i = tomb.Length - 1; i >= 0; i--)
            {
                if (tomb[i] >= maxFelszallo)
                {
                    maxFelszallo = tomb[i];
                    maxIndex = i;
                }
            }
            Console.WriteLine($"A legtobben a {maxIndex}. felszallon szalltak fel, {maxFelszallo}-an/en");
        }
        static void Feladat5()
        {
            var kedv = 0;
            var ingy = 0;

            foreach (var felszallas in felszallasok)
            {
                var datum = felszallas.IdoBelyeg.Split('-')[0];
                if (felszallas.Tipus != "JGY" && datum.CompareTo(felszallas.Ervenyesseg) <= 0)
                {
                    if (felszallas.Tipus == "TAB" || felszallas.Tipus == "NYB")
                    {
                        kedv++;
                    }
                    else if (felszallas.Tipus == "NYP" || felszallas.Tipus == "RVS" || felszallas.Tipus == "GYK")
                    {
                        ingy++;
                    }
                }
            }

            Console.WriteLine($"Ingyenesen utazók száma: {ingy} fő\nA kedvezményesen utazók száma: {kedv} fő");
        }
        static void Feladat7()
        {
            var sorok = new List<string>();
            foreach (var felszallas in felszallasok)
            {

                if (felszallas.Tipus != "JGY")
                {
                    var ervEv = int.Parse(felszallas.Ervenyesseg.Substring(0, 4));
                    var ervHo = int.Parse(felszallas.Ervenyesseg.Substring(4, 2));
                    var ervNap = int.Parse(felszallas.Ervenyesseg.Substring(6, 2));
                    var ev = int.Parse(felszallas.IdoBelyeg.Substring(0, 4));
                    var ho = int.Parse(felszallas.IdoBelyeg.Substring(4, 2));
                    var nap = int.Parse(felszallas.IdoBelyeg.Substring(6, 2));

                    var napkulonb = Math.Abs(napokszama(ervEv, ervHo, ervNap, ev, ho, nap));
                    if (napkulonb <= 3)
                    {
                        sorok.Add($"{felszallas.JegyAzonosito} {ervEv}-{ervHo}-{ervNap}");
                        //Console.WriteLine($"{felszallas.JegyAzonosito} {ervEv}-{ervHo}-{ervNap}");
                    }
                }
            }
            File.WriteAllLines("../../../figyelmeztetes.txt", sorok);
        }

        static void FeladatKiir(int sorszam, Action feladat, bool hasOutput)
        {
            if (!hasOutput)
            {
                Console.WriteLine($"{sorszam}. Feladat: Done");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
                feladat.DynamicInvoke(new object[] { });
            }
            else
            {
                Console.WriteLine($"{sorszam}. Feladat");

                feladat.DynamicInvoke(new object[] { });

                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
