using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> bejegyzesek = new List<Bejegyzes>();
        static void Main(string[] args)
        {
            //Halasi-Czalbert Tibor

            BekertListaFeltoltese();
            BeolvasottListaFeltoltese();
            LikeokKiosztasa();
            TartalomModositasa();
            Console.WriteLine("\n---------------------------------------------\n");
            BejegyzesekKiiratas();
            Console.WriteLine("\n---------------------------------------------\n");
            LegnepszerubbBejegyzes();
            TobbLikeMint35();
            KevesebbMint15();
            ListaRendezese();
            Console.WriteLine("\n---------------------------------------------\n");
            BejegyzesekKiiratas();

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
                bejegyzesek.Add(bejegyzes);
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
                bejegyzesek.Add(bejegyzes);
            }
            sr.Close();
        }

        static void BejegyzesekKiiratas()
        {
            foreach (var item in bejegyzesek)
            {
                Console.WriteLine(item);
            }
        }

        static void LikeokKiosztasa()
        {
            Random rand = new Random();
            for (int i = 0; i < bejegyzesek.Count*20; i++)
            {
                int randomNumber = rand.Next(0,bejegyzesek.Count);
                bejegyzesek[randomNumber].Like();
            }
        }

        static void TartalomModositasa()
        {
            Console.Write("Adjon meg egy szöveget!: ");
            string szoveg = Console.ReadLine();
            bejegyzesek[1].SetTartalom(szoveg);
        }

        static void LegnepszerubbBejegyzes()
        {
            int max = bejegyzesek[0].Likeok;
            for (int i = 1; i < bejegyzesek.Count; i++)
            {
                if (bejegyzesek[i].Likeok > max)
                {
                    max = bejegyzesek[i].Likeok;
                }
            }
            Console.WriteLine($"A legnépszerűbb bejegyzésen {max} darab like van.");
        }

        static void TobbLikeMint35()
        {
            bool vanE = false;
            for (int i = 0; i < bejegyzesek.Count; i++)
            {
                if (bejegyzesek[i].Likeok > 35)
                {
                    vanE = true;
                }
            }
            if (vanE == true)
            {
                Console.WriteLine("Van olyan bejegyzés, amely 35-nél több likeot kapott.");
            }
            else
            {
                Console.WriteLine("Nincs olyan bejegyzés, amely 35-nél több likeot kapott.");
            }
        }

        static void KevesebbMint15()
        {
            int szamlalo = 0;
            for (int i = 0; i < bejegyzesek.Count; i++)
            {
                if (bejegyzesek[i].Likeok < 15)
                {
                    szamlalo++;
                }
            }
            Console.WriteLine($"{szamlalo} darab 15-nél kevesebb likeot kapott bejegyzés van.");
        }

        static void ListaRendezese()
        {
            bejegyzesek.Sort(
            delegate (Bejegyzes p1, Bejegyzes p2)
               {
                    return p1.Likeok.CompareTo(p2.Likeok);
               }
            );
            bejegyzesek.Reverse();
        }
    }
}
