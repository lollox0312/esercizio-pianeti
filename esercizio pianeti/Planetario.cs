using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_pianeti
{
    internal class Planetario
    {
        internal const double G = 6.67e-20;
        internal const double DeltaT = .00001;

        public List<Pianeta> Pianeti { get; set; }
        
        public Vettore Forza(Pianeta p)
        {
            Vettore forzaTotale = new Vettore(0, 0);

            foreach (Pianeta altroPianeta in Pianeti) {
                if (altroPianeta == p)
                    continue;

                Vettore d = altroPianeta.Posizione - p.Posizione;
                double moduloForza = G * ((p.Massa*altroPianeta.Massa) / (d * d));
                Vettore f = moduloForza * d.versore();
                forzaTotale = forzaTotale + f;

            }
            return forzaTotale;
        }

        public void Move()
        {
            foreach(Pianeta p in Pianeti)
            {
                p.Posizione = p.Posizione + (p.V * DeltaT) + 0.5*((Forza(p) * p.Massa) * Math.Pow(DeltaT, 2));
                p.V = (Forza(p) / p.Massa) * DeltaT;
            }
            
        }
       
    }
}
