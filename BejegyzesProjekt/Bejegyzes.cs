using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Bejegyzes
    {
        private string szerzo;
        private string tartalom;
        private int likeok;
        private DateTime letrejott;
        private DateTime szerkesztve;
        public Bejegyzes(string szerzo, string tartalom)
        {
            this.Szerzo = szerzo;
            this.Tartalom = tartalom;
            this.Likeok = 0;
            this.Letrejott = DateTime.Now;
            this.Szerkesztve = DateTime.Now;
        }

        public string Szerzo { get; }
        public string Tartalom { get; }
        public void SetTartalom(string tartalom)
        {
            szerkesztve = DateTime.Now;
            this.tartalom = tartalom;
        }
        public int Likeok { get; }
        public DateTime Letrejott { get; }
        public DateTime Szerkesztve { get; }

        public void Like()
        {
            this.likeok++;
        }
        public override string ToString()
        {
            if (this.szerkesztve != this.letrejott)
            {
                return $"{this.szerzo} - {this.likeok} - {this.letrejott}\nSzerkesztve: {this.szerkesztve}\n{this.tartalom}";
            }
            else
            {
                return $"{this.szerzo} - {this.likeok} - {this.letrejott}\n{this.tartalom}";
            }
        }

    }
}
