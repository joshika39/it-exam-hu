using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var szam = int.Parse(Console.ReadLine());
            int szam1;
            // $"{szam}"
            // Console.WriteLine("kisebbitendo:{0} kivonando:{1:#.###} kulonbseg:{2:###.#}", szam4, szam3, kulonbseg);

            string egyik = "ket egyforma szoveg", masik = "ket egyforma szoveg";
            int ertek = egyik.CompareTo(masik); //szovegek osszehasonlitasa (egyforma, rovidebb, hosszabb)
            if (ertek == 0)
                Console.WriteLine(" Az \"{0}\" szoveg azonos a \"{1}\" szoveggel.");
            if (egyik.Equals(masik)) //egyenlo-e a ket szoveg
                Console.WriteLine(" Az \"{0}\" szoveg azonos a \"{1}\" szoveggel.");
            int i = "almafa".IndexOf("fa"); //szovegresz megjelenese masik szovegben
            Console.WriteLine("Az \"almafa\" szovegben eloszor a {0}. indexnel jelenik meg a \"fa\" szovegresz", i);

            #region letrehozas
            var a = new int[4]; //indexeles 0-tol
            var szam4 = 0;
            char[] abc = { 'a', 'b', 'c', 'd' };

            //VARRAL MUKODIK E AZ INT[] HELYETT?
            //TOMBOK NEM MENNEK
            #endregion 
        }
    }
}
