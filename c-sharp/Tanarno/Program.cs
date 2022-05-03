using System;
using System.Collections.Generic;
using System.IO;

namespace Majus20
{
    class Program
    {
        struct jelentes //egy sor tarolasara szolgal
        {
            public string telepules; //2 karakter
            public string ido; //4 karakter (elso ketto ora, masodik ketto perc)
            public string szel; //5 karakter (elso 3 szelirany, utolso ketto erosseg)
            public int homerseklet;
        }
        static void Main(string[] args)
        {
            //1. feladat
            List<jelentes> adatok = new List<jelentes>(); //listaban taroljuk az osszes sort
            string sor; //segedvaltozo egy sor beolvasasahoz
            jelentes seged; //segedvaltozo egy varos adataihoz

            StreamReader olvas = new StreamReader(@"../../../tavirathu13.txt");

            while (!olvas.EndOfStream)
            {
                sor = olvas.ReadLine();
                seged.telepules = sor.Split(' ')[0];
                seged.ido = sor.Split(' ')[1];
                seged.szel = sor.Split(' ')[2];
                seged.homerseklet = Convert.ToInt32(sor.Split(' ')[3]);
                adatok.Add(seged);
            }
            olvas.Close();

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.Write("Adja meg egy telepules kodjat! Telepules: ");
            string telep = Console.ReadLine();

            for (int i = adatok.Count - 1; i >= 0; i--)
            {
                if (telep == adatok[i].telepules)
                {
                    Console.WriteLine("Az utolso meresi adat a megadott telepulesrol {0}{1}:{2}{3}-kor erkezett.", adatok[i].ido[0], adatok[i].ido[1], adatok[i].ido[2], adatok[i].ido[3]);
                    break;
                }
            }

            //3. feladat
            Console.WriteLine("3. feladat");
            jelentes min = adatok[0];
            jelentes max = adatok[0];
            for (int i = 1; i < adatok.Count; i++)
            {
                if (adatok[i].homerseklet < min.homerseklet)
                {
                    min = adatok[i];
                }
                if (adatok[i].homerseklet > max.homerseklet)
                {
                    max = adatok[i];
                }
            }
            Console.WriteLine("A legalacsonyabb homerseklet: {0} {1}{2}:{3}{4} {5} fok.", min.telepules, min.ido[0], min.ido[1], min.ido[2], min.ido[3], min.homerseklet);
            Console.WriteLine("A legmagasabb homerseklet: {0} {1}{2}:{3}{4} {5} fok.", max.telepules, max.ido[0], max.ido[1], max.ido[2], max.ido[3], max.homerseklet);

            //4. feladat
            Console.WriteLine("4.feladat");
            int szelcsendSzam = 0;

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].szel == "00000")
                {
                    szelcsendSzam++;
                    Console.WriteLine("{0} {1}{2}:{3}{4}", adatok[i].telepules, adatok[i].ido[0], adatok[i].ido[1], adatok[i].ido[2], adatok[i].ido[3]);
                }
            }
            if (szelcsendSzam == 0)
            {
                Console.WriteLine("Nem volt szelcsend a meresek idejen.");
            }

            //5. feladat
            Console.WriteLine("5. feladat");
            //kesobb oldjuk meg

            //6.feladat
            //kesobb oldjuk meg

            Console.ReadKey();
        }
    }
}
