using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Karakterekkel valo dolgozas
            //var minta = Console.ReadLine()[0];
            var minta = 'H';
            if (minta >= 'A' && minta <= 'Z')
            {
                Console.WriteLine("Benne az abeceben");
            }

            // To feldolgozasa 
            var toSorok = File.ReadAllLines("../../melyseg.txt"); // Specialis lista
            var to = new List<List<int>>(); // (lista a listaban)
            var toTomb = new int[9,9]; // (2d-s tomb)


            for (int i = 2; i < toSorok.Length; i++) // Elindulunk a sorokon lefele (az elso for ciklus)
            {
                var sor = toSorok[i];

                /* Letrheozunk egy ideiglenes listat, amit ezen a fuggvenyen kivul
                 * sose fogunk hasznalni. Ez olyan, mint amikor hasznalunk egy format a cserep 
                 * kiontesere. Nekunk is ez csak a belso lista formajat adja meg, 
                 * amit vegul beleteszunk a nagy listaba. */
                var ideigList = new List<int>(); // Letrejon / torlodik az elozo ideiglenes lista
                
                var elemek = sor.Split(' ');
                foreach (var elem in elemek) // az a foreach ami az oszlopokon megy vegig
                {
                    var melyseg = int.Parse(elem);
                    ideigList.Add(melyseg);
                }
                to.Add(ideigList); // Es ez a pont utan, mar nem is lesz szukseg ra
            }

            for (int i = 2; i < toSorok.Length; i++) // Elindulunk a sorokon lefele (az elso for ciklus)
            {
                continue;
                var sor = toSorok[i];

                /* Letrheozunk egy ideiglenes listat, amit ezen a fuggvenyen kivul
                 * sose fogunk hasznalni. Ez olyan, mint amikor hasznalunk egy format a cserep 
                 * kiontesere. Nekunk is ez csak a belso lista formajat adja meg, 
                 * amit vegul beleteszunk a nagy listaba. */

                var elemek = sor.Split(' ');
                for (int j = 0; j < elemek.Length; j++) // Masodik for ciklus ami az oszlopokon megy vegig
                {
                    var melyseg = int.Parse(elemek[j]);
                    toTomb[i,j] = melyseg;
                }
            }


            /* ----------------
             * FAJLBA IRAS 
             * ------------- */

            // Abban az esetben, ha belepakoljuk az adatokat egy `Lista<string>`-be
            var fajlbaSzoveg = new List<string>();
            for (int i = 0; i < 50; i++)
            {
                // Valami formazasok meg atalakitasok ha kell
                // ....
                // ....

                fajlbaSzoveg.Add($"Joshua szereti a Csenget {i + 1}x{50+i} meg meg nehany");
            }
            File.WriteAllLines("../../mennyireis1.txt", fajlbaSzoveg);

            // A masik megoldas

            var fajlIro = new StreamWriter("../../mennyireis2.txt");
            for (int i = 0; i < fajlbaSzoveg.Count; i++)
            {
                // Pontosan mintha Console-ra iratnank, csak epp a fajlba megy
                fajlIro.WriteLine(fajlbaSzoveg[i]); 
                Console.WriteLine(fajlbaSzoveg[i]);
            }
            // DE ITT A NAGYON FONTOS!

            fajlIro.Close(); // Ha ez nincs, nem mentodik el vegul a fajl.
        }
    }
}
