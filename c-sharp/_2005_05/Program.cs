namespace _2005_05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Console.Write("Kerem az 52.ik het lotto szamait: ");
            var beker = Console.ReadLine();
            var adat = beker.Split(' ');
            var szamok = new List<int>();
            
            foreach (var num in adat)
            {
                szamok.Add(int.Parse(num));
            }
            szamok.Sort();
            foreach (var szam in szamok)
            {
                Console.Write($"{szam }");
            }
            Console.WriteLine();
            
            Console.Write("Kerek egy szamot 1 es 51 kozott: ");
            var newSzam = int.Parse(Console.ReadLine());
            
            var sorok = File.ReadLines("../../../lottosz.dat");

            Console.ReadLine();

            var lottoSzamok = new List<List<int>>();

            foreach (var sor in sorok)
            {
                var adatok = sor.Split(' ');

                var ideigelenes = new List<int>();

                //ideigelenes.Add(int.Parse(adatok[0]));
                //ideigelenes.Add(int.Parse(adatok[1]));
                //ideigelenes.Add(int.Parse(adatok[2]));
                //ideigelenes.Add(int.Parse(adatok[3]));
                //ideigelenes.Add(int.Parse(adatok[4]));

                //for(int i = 0; i < adatok.Length; i++)
                //{
                //    ideigelenes.Add(int.Parse(adatok[i]));
                //}

                foreach(var adat1 in adatok)
                {
                    ideigelenes.Add(int.Parse(adat1));
                }

                lottoSzamok.Add(ideigelenes);
            }
            
        }
    }
}