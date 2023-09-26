using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            BeolvasottListaFeltoltese();
            LikeokKiosztasa();
            TartalomModositasa();
            BejegyzesekBekertKiiratas();
            BejegyzesekBeolvasottKiiratas();
            Console.WriteLine("\n---------------------------------------------\n");
            LegnepszerubbBejegyzes();

            Console.ReadKey();
        }

        static void BekertListaFeltoltese()
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

        static void BejegyzesekBekertKiiratas()
        {
            foreach (var item in bejegyzesekBekert)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void BeolvasottListaFeltoltese()
        {
            StreamReader sr = new StreamReader("bejegyzesek.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darabok = sor.Split(';');
                Bejegyzes bejegyzes = new Bejegyzes(darabok[0], darabok[1]);
                bejegyzesekBeolvasas.Add(bejegyzes);
            }
            sr.Close();
        }

        static void BejegyzesekBeolvasottKiiratas()
        {
            foreach (var item in bejegyzesekBeolvasas)
            {
                Console.WriteLine(item);
            }
        }

        static void LikeokKiosztasa()
        {
            Random rand = new Random();
            for (int i = 0; i < bejegyzesekBekert.Count*20; i++)
            {
                int randomNumber = rand.Next(0,bejegyzesekBekert.Count);
                bejegyzesekBekert[randomNumber].Like();
            }

            for (int i = 0; i < bejegyzesekBeolvasas.Count * 20; i++)
            {
                int randomNumber = rand.Next(0, bejegyzesekBeolvasas.Count);
                bejegyzesekBeolvasas[randomNumber].Like();
            }
        }

        static void TartalomModositasa()
        {
            Console.Write("Adjon meg egy szöveget!: ");
            string szoveg = Console.ReadLine();
            bejegyzesekBeolvasas[1].SetTartalom(szoveg);
        }

        static void LegnepszerubbBejegyzes()
        {
            int max = bejegyzesekBeolvasas[0].Likeok;
            for (int i = 1; i < bejegyzesekBeolvasas.Count; i++)
            {
                if (bejegyzesekBeolvasas[i].Likeok > max)
                {
                    max = bejegyzesekBeolvasas[i].Likeok;
                }
            }
            Console.WriteLine($"A legnépszerűbb bejegyzésen {max} darab like van.");
        }
    }
}
