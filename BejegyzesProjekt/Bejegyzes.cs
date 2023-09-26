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
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            this.letrejott = DateTime.Now;
            this.szerkesztve = DateTime.Now;
        }
    }
}
