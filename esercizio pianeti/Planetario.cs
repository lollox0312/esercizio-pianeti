using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_pianeti
{
    internal class Planetario
    {
        internal const double G = 6.67e-6;

        public List<Pianeta> Pianeti { get; set; }
        
        public Vettore Forza(Pianeta p)
        {

            foreach (Pianeta altroPianeta in Pianeti) {
                Vettore d = p.S.distanza(altroPianeta.S);
                double f = G * ((p.Massa*altroPianeta.Massa) / (d * d));
            }
            return new Vettore(0, 1);
        }
       
    }
}
