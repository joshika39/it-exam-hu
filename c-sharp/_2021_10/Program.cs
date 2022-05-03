using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace _2021_10
{
    internal class Program
    {
        public class Test
        {
            public string Nev;
            public Test(string _nev)
            {
                Nev = _nev;
            }
            public void Kiir()
            {
                Console.WriteLine(Nev);
            }
        }
        public static void Main(string[] args)
        {
            #region 1. Feladat

            Console.WriteLine("1. Feladat");
            Console.Write("Kerem a nehezsegi szintet (csak a szint): ");
            // Fajl neve a kiterjesztes nelkul
            var file = Console.ReadLine();
            
            Console.Write("Adja meg egy sor számát: ");
            var sor = int.Parse(Console.ReadLine());

            Console.Write("Adja meg egy oszlop számát: ");
            var oszlop = int.Parse(Console.ReadLine());

            #endregion

            // Szukseges Valtozok
            var tabla = new int[9, 9];
            var lepesek = new List<int[]>();

            // Fajl sorainak beolvasasa
            var lines = File.ReadLines(file + ".txt");
            
            int sorSzam = 0;
            int oszlopSzam = 0;
            
            // Vegigmegyunk minden soron egyesevel, beleteve oket a line valtozoba minden korben
            foreach (var line in lines)
            {
                // A sor szamokra bontasa szokozoknel
                var numbers = line.Split(' ');
                
                // Ha a sudokut olvassuk (a sorok szama kisebb mint 9)
                if (sorSzam < 9)
                {
                    // Atrakjuk a szamokat a tabla[,] valtozoba
                    foreach (var num in numbers)
                    {
                        tabla[sorSzam, oszlopSzam] = int.Parse(num);
                        oszlopSzam++;
                    }
                }
                else
                {
                    // Kulonebn a lepeseket lementjuk soronkent tehat,
                    // van egy listank (lepesek) es a ban 3 elemu tombok (tempInt)
                    var tempInt = new int[3];
                    
                    // Ujra belerakjuk a tombokbe
                    foreach (var num in numbers)
                    {
                        tempInt[oszlopSzam] = int.Parse(num);
                        oszlopSzam++;
                    }
                    
                    // A tombot beletesszuk a listaba
                    lepesek.Add(tempInt);
                }
                sorSzam++;
                oszlopSzam = 0;
            }

            Console.WriteLine("3. Feladat");
            
            // Megnezzuk ki van e toltve a hely (nem e 0 az erteke)
            switch (tabla[sor-1, oszlop-1])
            {
                case 0:
                    Console.WriteLine("Az adott helyet még nem töltötték ki");
                    break;    
                default:
                    Console.WriteLine($"Az adott helyen szereplő szám: {tabla[sor-1, oszlop-1]}");
                    break;
            }
            Console.WriteLine($"A hely a(z)  {ReszTabla(sor-1,oszlop-1)} résztáblázathoz tartozik.");
            
            Console.WriteLine("4. Feladat");
            // Ureshelyek megszamolasa
            double uresHely = 0;
            foreach (var num in tabla)
            {
                if (num == 0)
                {
                    uresHely++;
                }
            }
            // Szazalekszamitas
            double szazalek = Math.Round(100 * uresHely / 81, 1);
            Console.WriteLine($"Az üres helyek aránya: {szazalek}");
            
            Console.WriteLine("5. Feladat");

            foreach (var lepes in lepesek)
            {
                var kSor = lepes[1] - 1;
                var kOszlop = lepes[2] - 1;
                var szam = lepes[0];
                
                Console.WriteLine($"A kiválasztott sor: {kSor} oszlop: {kOszlop} a szám: {szam} ");
                if (tabla[kSor, kOszlop] != 0)
                {
                    Console.WriteLine("A helyet már kitöltötték.");
                }
                else if (ReszTablaEllenorzes(kSor, kOszlop, tabla, szam))
                {
                    Console.WriteLine("Az adott résztáblázatban már szerepel a szám");
                }
                else if (SorEllenorzes(kSor, tabla, szam))
                {
                    Console.WriteLine("Az adott sorban már szerepel a szám");
                }
                else if(OszlopEllenorzes(kOszlop, tabla, szam))
                {
                    Console.WriteLine("Az adott oszlopban már szerepel a szám");
                }
                else
                {
                    Console.WriteLine($"A lépés megtehető");
                }
                Console.WriteLine();
            }
        }
        
        public static int ReszTabla(int sor, int oszlop)
        {
            var resztablak = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    resztablak[i, j] = i*3 + j;
                }
            }
            
            return resztablak[sor/3,oszlop/3] + 1;
        }

        public static bool ReszTablaEllenorzes(int sor, int oszlop, int[,] tabla, int keresettElem)
        {
            var van = false;
            
            for (int i =3 * (sor / 3); i < 3 * (sor / 3) + 3; i++)
            {
                for (int j = 3 * (oszlop / 3); j < 3 * (oszlop / 3) + 3; j++)
                {
                    // Console.Write($"{tabla[i,j]} ");
                    if (keresettElem == tabla[i,j])
                    {
                        van = true;
                    }
                }
            }

            return van;
        }

        public static bool SorEllenorzes(int sor, int[,] tabla, int keresettElem)
        {
            var van = false;
            for (int i = 0; i < 9; i++)
            {
                // Console.Write($"{tabla[sor, i]} ");
                if (keresettElem == tabla[sor, i])
                {
                    van = true;
                }
            }
            return van;
        }
        public static bool OszlopEllenorzes(int oszlop, int[,] tabla, int keresettElem)
        {
            
            var van = false;
            for (int i = 0; i < 9; i++)
            {
                if (keresettElem == tabla[i, oszlop])
                {
                    van = true;
                }
            }
            return van;
        }
    }
}