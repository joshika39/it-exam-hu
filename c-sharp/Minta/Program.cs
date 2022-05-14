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
            var minta = Console.ReadLine()[0];
            if (minta >= 'A' && minta <= 'Z')
            {
                Console.WriteLine("Benne az abeceben");
            }

            // To feldolgozasa 
            var toSorok = File.ReadAllLines("../../../melyseg.txt"); // Specialis lista
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


        }
    }
}
