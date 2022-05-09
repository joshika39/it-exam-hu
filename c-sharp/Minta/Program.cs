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
            var minta = Console.ReadLine()[0];
            if (minta >= 'A' && minta <= 'Z')
            {
                Console.WriteLine("Benne az abeceben");
            }
        }
    }
}
