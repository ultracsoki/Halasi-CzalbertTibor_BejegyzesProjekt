using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> bejegyzesekBekert = new List<Bejegyzes>();
        static List<Bejegyzes> bejegyzesekBeolvasas = new List<Bejegyzes>();
        static void Main(string[] args)
        {
            //Halasi-Czalbert Tibor

            BekertListaFeltoltese();
            BejegyzesekBekertKiiratas();

            Console.ReadKey();
        }

        static public void BekertListaFeltoltese()
        {
            Console.WriteLine("Hány darab bejegyzést szeretne felvenni?");
            int darabSzam = 0;
            try 
            {
                darabSzam = Convert.ToInt32(Console.ReadLine());
            } 
            catch 
            {
                Console.WriteLine("Nem szám formátumot adott meg!");
            }
            for (int i = 0; i < darabSzam; i++)
            {
                Console.WriteLine("Adjon meg egy bejegyzést!");
                Console.Write("Szerző:  ");
                string szerzo = Console.ReadLine();
                Console.Write("Tartalom:  ");
                string tartalom = Console.ReadLine();
                Bejegyzes bejegyzes = new Bejegyzes(szerzo,tartalom);
                bejegyzesekBekert.Add(bejegyzes);
            }
        }

        static public void BejegyzesekBekertKiiratas()
        {
            foreach (var item in bejegyzesekBekert)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
