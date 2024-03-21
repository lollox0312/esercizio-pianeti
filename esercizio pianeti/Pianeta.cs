using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_pianeti
{
    public class Pianeta
    {
        public double Massa { get; set; }
        public Vettore Posizione { get; set;}
        public Vettore V { get; set; }

        public double R { get; set; }
        public Color rr { get; set; }
        public string Nome { get; set; }
        public Pianeta(double m, Vettore ve,Vettore sp )
        {
            Massa = m;
            Posizione = sp;
            V = ve;
            
        }
        public override string ToString()
        {
            return string.Format(Nome);
        }


    }
}
