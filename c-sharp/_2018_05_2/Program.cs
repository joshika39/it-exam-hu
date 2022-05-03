using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2018_05_2
{
    internal class Program
    {
        public const string utvonal = "../../../ajto.txt";

        #region Strukturak

        public struct Belepes
        {
            public int ora;
            public int perc;
            public int ido;
            public string irany;

            public Belepes(int ora, int perc, string irany) : this()
            {
                this.ora = ora;
                this.perc = perc;
                this.irany = irany;
                ido = ora * 60 + perc;
            }
        }

        public struct Jarkalo
        {


            public int id;
            public List<Belepes> Logs;
            public Jarkalo(int id) : this()
            {
                Logs = new List<Belepes>();
                this.id = id;
            }

            public void AddBelepesToLogs(int ora, int perc, string irany)
            {
                Logs.Add(new Belepes(ora, perc, irany));
            }
            public Belepes FirstEnter()
            {
                var minIdo = Logs.Min(x => x.ido);
                var result = Logs.Where(
                j =>
                j.ido == minIdo &&
                j.irany == "be").FirstOrDefault();
                return result;
            }
            public Belepes LastLeave()
            {
                var maxIdo = Logs.Max(x => x.ido);
                var result = Logs.Where(
                j =>
                j.ido == maxIdo &&
                j.irany == "ki").LastOrDefault();

                return result;
            }

            public int Bentlet()
            {
                var bentlet = 0;
                var kezdes = 0;
                foreach (var log in Logs)
                {
                    if (log.irany == "be")
                    {
                        kezdes = log.ido;
                    }
                    else
                    {
                        bentlet += log.ido - kezdes;
                        kezdes = 0;
                    }
                }

                if (kezdes != 0)
                {
                    bentlet += 15 * 60 - kezdes;
                }

                return bentlet;
            }

        }

        #endregion

        static void Main(string[] args)
        {
            #region 1. Feladat

            var sorok = File.ReadLines(utvonal).ToList();
            var jarkalok = new List<Jarkalo>();
            var belepesek = new List<Belepes>();
            for (var i = 0; i < sorok.Count(); i++)
            {
                var adatok = sorok[i].Split(' ');
                belepesek.Add(new Belepes(int.Parse(adatok[0]),
                                          int.Parse(adatok[1]),
                                          adatok[3]));
                var id = int.Parse(adatok[2]);
                if (jarkalok.Any(x => x.id == id))
                {
                    jarkalok.Where(x => x.id == id).FirstOrDefault().AddBelepesToLogs(int.Parse(adatok[0]),
                                                                                      int.Parse(adatok[1]),
                                                                                      adatok[3]);
                }
                else
                {
                    jarkalok.Add(new Jarkalo(id));
                    jarkalok.Where(x => x.id == id).FirstOrDefault().AddBelepesToLogs(int.Parse(adatok[0]),
                                                                  int.Parse(adatok[1]),
                                                                  adatok[3]);
                }
            }

            #endregion

            #region 2. Feladat

            Belepes legelso = new(15, 60, "asf");
            Belepes legutolso = new(0, 0, "asf");
            var legelsoId = 0; 
            var legutolsoId = 0; 
            for (int i = 0; i < jarkalok.Count; i++)
            {
                if(legelso.ido > jarkalok[i].FirstEnter().ido)
                {
                    legelsoId = jarkalok[i].id;
                    legelso = jarkalok[i].FirstEnter();
                }

                if (legutolso.ido < jarkalok[i].LastLeave().ido)
                {
                    legutolsoId = jarkalok[i].id;
                    legutolso = jarkalok[i].LastLeave();
                }
            }

            #endregion

            #region 3. Feladat, 4. Feladat

            var sw = new StreamWriter("../../../athaladas.txt");
            jarkalok.Sort((s1, s2) => s1.id.CompareTo(s2.id));
            foreach (var jarkalo in jarkalok)
            {
                sw.WriteLine($"{jarkalo.id} {jarkalo.Logs.Count}");
                if(jarkalo.Logs.Count % 2 == 1)
                {
                    Console.Write($"{jarkalo.id} ");
                }
            }
            sw.Close();
            Console.WriteLine();

            #endregion

            #region 5. Feladat

            var maxBentlevo = 0;
            var bentlevok = 0;
            var pillanatIdo = new Belepes(0,0,"asd");
            foreach(var belepes in belepesek)
            {
                if (belepes.irany == "be")
                    bentlevok++;
                else
                    bentlevok--;

                if(bentlevok >= maxBentlevo)
                {
                    maxBentlevo=bentlevok;
                    pillanatIdo = belepes;
                }
            }
            Console.WriteLine($"A legtobben {pillanatIdo.ora}:{pillanatIdo.perc} oraakor voltak, {maxBentlevo}");

            #endregion

            #region 6. Feladat, 7. Feladat, 8. Feladat

            Console.Write("Kerem egy szemely azonositojat: ");
            var azon = int.Parse(Console.ReadLine());

            var tempJarkalo = jarkalok.Where(x => x.id == azon).FirstOrDefault();
            foreach(var belepes in tempJarkalo.Logs)
            {
                if(belepes.irany == "be")
                {
                    Console.Write($"{belepes.ora}:{belepes.perc}-");
                }
                else
                {
                    Console.WriteLine($"{belepes.ora}:{belepes.perc}");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"A(z) {azon} azonositoju szemely {tempJarkalo.Bentlet()} percet volt bent");

            #endregion
        }
    }
}
