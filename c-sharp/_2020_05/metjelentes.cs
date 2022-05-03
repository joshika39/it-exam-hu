using System;
using System.Collections.Generic;
using System.IO;

namespace Majus20
{
    class metjelentes
    {
        public const string utvonal = @"../../../tavirathu13.txt"; 

        public struct Jelentes
        {
            public string telepules;
            public string ido;
            public string szel;
            public int homerseklet;

            public Jelentes(string telepules, string ido, string szel, int homerseklet)
            {
                this.telepules = telepules;
                this.ido = ido;
                this.szel = szel;
                this.homerseklet = homerseklet;
            }

            public void KiirTelepules() 
            {
                Console.WriteLine($"Telepules: {telepules}");
            }
        }

        public struct TelepulesekKiir
        {
            public string telepules;
            public bool voltMar;
        }

        static void Main(string[] args)
        {
            #region 1. Feladat
            Console.WriteLine("1. Feladat ------------------------- ");

            var sorok = File.ReadLines(utvonal);
            var jelentesek = new List<Jelentes>();
            foreach(var sor in sorok)
            {
                var adatok = sor.Split(' ');
                // 1. megoldas
                Jelentes ideig;
                ideig.ido = "asd";

                // 2. megoldas var valtozo (muszaj constructor)
                var ideigelen = new Jelentes(adatok[0], adatok[1], adatok[2], int.Parse(adatok[3]));
                
                // 3. megoldas nincs valtozo 
                jelentesek.Add(new Jelentes(adatok[0], adatok[1], adatok[2], int.Parse(adatok[3])));
            }

            #endregion

            #region 2. Feladat

            var varos = Console.ReadLine();
            for(var i = jelentesek.Count-1; i >= 0; i--)
            {
                if(jelentesek[i].telepules == varos)
                {
                    var ido = jelentesek[i].ido;
                    Console.WriteLine($"{ido[0]}{ido[1]}:{ido[2]}{ido[3]}");
                    break;

                }
            }

            #endregion

            #region 5. Feladat


            for(var i = 0; i <= jelentesek.Count - 1; i++)
            {
              
                var telepules = jelentesek[i].telepules;
                double atlagOsszeg = 0;
                double adatSzam = 0;
                
                for(var j = 0; j <= jelentesek.Count - 1; j++)
                {
                    if(telepules == jelentesek[j].telepules)
                    {
                        if (jelentesek[j].ido[0] == '0' && jelentesek[j].ido[1] == '1' || jelentesek[j].ido[1] == '7')
                        {
                            atlagOsszeg += jelentesek[j].homerseklet;
                            adatSzam++;
                        }
                        if (jelentesek[j].ido[0] == '1' && jelentesek[j].ido[1] == '3')
                        {
                            atlagOsszeg += jelentesek[j].homerseklet;
                            adatSzam++;
                        }
                        if (jelentesek[j].ido[0] == '1' && jelentesek[j].ido[1] == '9')
                        {
                            atlagOsszeg += jelentesek[j].homerseklet;
                            adatSzam++;
                        }
                    }
                }
                if(adatSzam >= 4)
                {
                    var vaross = telepules;
                    double atlag = atlagOsszeg / adatSzam;
                    var vegAtlag = Math.Round(atlag);
                }
            }

            #endregion

            #region 6. Feladat
            var kiirtTelepulesek = new List<TelepulesekKiir>();
            foreach(var jelentes in jelentesek)
            {
                TelepulesekKiir ideiglenesTelepulesKiir;
                ideiglenesTelepulesKiir.telepules = jelentes.telepules;
                ideiglenesTelepulesKiir.voltMar = true;

                kiirtTelepulesek.Add(ideiglenesTelepulesKiir);
            }
            #endregion
        }
    }
}
