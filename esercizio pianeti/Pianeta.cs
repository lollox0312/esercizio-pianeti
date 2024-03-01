using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_pianeti
{
    internal class Pianeta
    {
        public double Massa { get; set; }
        public Vettore S { get; set;}
        public Vettore V { get; set; }

        public Pianeta(double m, Vettore ve,Vettore sp)
        {
            Massa = m;
            S = sp;
            V = ve;
        }
    }
}
