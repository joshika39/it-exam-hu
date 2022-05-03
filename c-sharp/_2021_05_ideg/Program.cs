using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2021_05_ideg
{
    internal class Program
    {
        #region Haver

        static int[,] melyseg = new int[100, 100];
        static int sorok;
        static int oszlopok;

        #endregion

        static List<List<int>> to = new List<List<int>>();


        static void Main(string[] args)
        {
            Feladat1_Joshua();
            //Feladat2_Joshua();
            //Feladat3_Joshua();
            //Feladat4_Joshua();
            Feladat5_Joshua();
            //Feladat6_Joshua();

        }

        #region Haver 

        static void Feladat6()
        {
            //Sávdiagram készítése
            Console.WriteLine("6. feladat");
            Console.Write("A vizsgált szelvény oszlopának azonosítója=");
            int oszlop = Convert.ToInt32(Console.ReadLine());
            StreamWriter sw = new StreamWriter("diagram.txt");
            for (int sor = 1; sor <= sorok; sor++)
            {
                string egysor = sor.ToString("D2");
                for (int i = 0; i < Math.Round((double)melyseg[sor, oszlop] / 10); i++)
                    egysor = egysor + "*";
                sw.WriteLine(egysor);
            }
            sw.Close();
        }
        static void Feladat5()
        {
            //A tó kerülete
            Console.WriteLine("5. feladat");
            int db = 0;
            for (int sor = 2; sor < sorok; sor++)
                for (int oszlop = 2; oszlop < oszlopok; oszlop++)
                    if (melyseg[sor, oszlop] > 0)
                    {
                        if (melyseg[sor - 1, oszlop] == 0) db++;
                        if (melyseg[sor + 1, oszlop] == 0) db++;
                        if (melyseg[sor, oszlop - 1] == 0) db++;
                        if (melyseg[sor, oszlop + 1] == 0) db++;
                    }
            Console.WriteLine("A tó partvonala {0} m hosszú", db);
        }
        static void Feladat4()
        {
            //A tó legmélyebb pontja(i)
            Console.WriteLine("4. feladat");
            int max = melyseg[1, 1];
            for (int sor = 1; sor <= sorok; sor++)
                for (int oszlop = 1; oszlop <= oszlopok; oszlop++)
                    if (max < melyseg[sor, oszlop]) max = melyseg[sor, oszlop];
            Console.WriteLine("A tó legnagyobb mélysége: {0} dm", (double)max);

            Console.WriteLine("A legmélyebb helyek sor-oszlop koordinátái: ");
            for (int sor = 1; sor <= sorok; sor++)
                for (int oszlop = 1; oszlop <= oszlopok; oszlop++)
                    if (max == melyseg[sor, oszlop]) Console.Write("({0}; {1})   ", sor, oszlop);
            Console.WriteLine();
        }
        static void Feladat3()
        {
            //A tó felszíne és átlagos mélysége
            Console.WriteLine("3. feladat");
            int f = 0;
            double s = 0;
            for (int sor = 1; sor <= sorok; sor++)
                for (int oszlop = 1; oszlop <= oszlopok; oszlop++)
                    if (melyseg[sor, oszlop] > 0)
                    {
                        f++;
                        s += melyseg[sor, oszlop];
                    }
            Console.WriteLine("A tó felszíne: {0} m2, átlagos mélysége: {1} m", f, ((double)s / (10 * f)).ToString("F2"));
        }
        static void Feladat2()
        {
            //Tó mélysége adott helyen
            Console.WriteLine("2. feladat");
            Console.Write("A mérés sorának azonosítója=");
            int sor = Convert.ToInt32(Console.ReadLine());
            Console.Write("A mérés oszlopának azonosítója=");
            int oszlop = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("A mért mélység az adott helyen {0} dm", melyseg[sor, oszlop]);
        }
        static void Feladat1()
        {
            //Adatok beolvasása
            var sr = new StreamReader("../../../melyseg.txt");
            sorok = int.Parse(sr.ReadLine());
            oszlopok = int.Parse(sr.ReadLine());
            string[] egysor = new string[oszlopok];

            for (int sor = 1; sor <= sorok; sor++)
            {
                egysor = sr.ReadLine().Split(' ');
                for (int oszlop = 1; oszlop <= oszlopok; oszlop++)
                    melyseg[sor, oszlop] = Convert.ToInt32(egysor[oszlop - 1]);
            }
            sr.Close();

        }

        #endregion

        static void Feladat1_Joshua()
        {
            //Adatok beolvasása
            var sorok = File.ReadLines("../../../melyseg.txt").ToList();

            for (int i = 2; i < sorok.Count; i++)
            {
                var sor = sorok[i];
                var elemek = sor.Split(' ');
                var ideigList = new List<int>();

                foreach (var elem in elemek)
                {
                    ideigList.Add(int.Parse(elem));
                }
                to.Add(ideigList);
            }
            Matrix_Kiir();

            void Matrix_Kiir()
            {
                // 2D tomb kiiratasa
                for (int i = 0; i < to.Count; i++)
                {
                    var sor = to[i];
                    for (int j = 0; j < sor.Count; j++)
                    {
                        Console.Write($"{to[i][j]}\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Feladat2_Joshua()
        {
            Console.Write("Kerem a sor azonositot: ");
            var sor = int.Parse(Console.ReadLine());
            Console.Write("Kerem az oszlop azonositot: ");
            var oszlop = int.Parse(Console.ReadLine());

            //Console.WriteLine($"A mert ertek: {to[sor - 1][oszlop - 1]} dm");
            For_Megold();

            void For_Megold()
            {
                for (int i = 0; i < to.Count; i++)
                {
                    for (int j = 0; j < to[i].Count; j++)
                    {
                        if (i == sor && j == oszlop)
                        {
                            Console.WriteLine($"A mert ertek: {to[i][j]} dm");
                        }
                    }
                }
            }
        }
        static void Feladat3_Joshua()
        {
            var felulet = 0;
            var atlag = 0.0;

            for (int i = 0; i < to.Count; i++)
            {
                for (int j = 0; j < to[i].Count; j++)
                {
                    if (to[i][j] > 0)
                    {
                        felulet++;
                        atlag += to[i][j];
                    }
                }
            }
            atlag = Math.Round(atlag / (felulet * 10), 2);
            //atlag = (atlag / 10) / felulet;
            Console.WriteLine($"A felulete: {felulet} es az atlag melyseg: {atlag}");
        }
        static void Feladat4_Joshua()
        {
            var maxMely = 0;
            for (int i = 0; i < to.Count; i++)
            {
                for (int j = 0; j < to[i].Count; j++)
                {
                    if (to[i][j] >= maxMely)
                    {
                        maxMely = to[i][j];
                    }
                }
            }
            Console.WriteLine($"A tó legnagyobb mélysége: {maxMely} dm");
            Console.Write($"A legmélyebb helyek sor - oszlop koordinátái:");
            
            for (int i = 0; i < to.Count; i++)
            {
                for (int j = 0; j < to[i].Count; j++)
                {
                    if (to[i][j] == maxMely)
                    {
                        Console.Write($" ({i + 1}; {j + 1}),");
                    }
                }
            }

            Console.WriteLine();
        }
        static void Feladat5_Joshua()
        {
            var kerulet = 0;
            for (int i = 0; i < to.Count; i++)
            {
                for (int j = 0; j < to[i].Count; j++)
                {
                    var pont = to[i][j];

                    if (pont != 0)
                    {
                        // Sorok ellenorzese ( i +- 1)
                        if (i - 1 >= 0 && to[i - 1][j] == 0)
                        {
                            kerulet++;
                        }
                        if (i + 1 <= to.Count - 1 && to[i + 1][j] == 0)
                        {
                            kerulet++;
                        }

                        // Oszlopok ellenorzese ( i +- 1)
                        if (j - 1 >= 0 && to[i][j - 1] == 0)
                        {
                            kerulet++;
                        }                     
                        if (j + 1 <= to[i].Count - 1 && to[i][j + 1] == 0)
                        {
                            kerulet++;
                        }
                       
                    }
                }
            }
            Console.WriteLine($" tó partvonala {kerulet} m hosszú");
        }
        static void Feladat6_Joshua()
        {
            Console.WriteLine("Kerek egy oszlop azonositot: ");
            var oszlop = int.Parse(Console.ReadLine());
            var szovegAFileba = new List<string>();

            for (int i = 0; i < to.Count; i++)
            {
                var beirandoSor = "";
                var melyseg = to[i][oszlop - 1];

                if (i < 10)
                {
                    beirandoSor += "0" + (i + 1);
                }
                else
                {
                    beirandoSor += i + 1;
                }
                var csillagSzam = Math.Round((double)melyseg / 10);
                for (int j = 0; j < csillagSzam; j++)
                {
                    beirandoSor += "*";
                }
                szovegAFileba.Add(beirandoSor);
            }
            File.WriteAllLines("../../../diagram.txt", szovegAFileba);

        }

    }
}
