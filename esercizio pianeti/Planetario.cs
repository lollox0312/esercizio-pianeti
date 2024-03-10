using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_pianeti
{
    internal class Planetario
    {
        public List<Pianeta> Pianeti { get; set; }
        public Vettore forza(Pianeta p)
        {
            foreach (Pianeta p1 in Pianeti) {
                Vettore d = p.S.distanza(p1.S);
            double f = (6.67 * Math.Pow(10, -6)) * ((p.Massa*p1.Massa) / (d * d).Modulo());
                Vettore F = new Vettore();
                return F * (d.versore());
            }
            return new Vettore(0, 1);
        }
       
    }
}
