using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esercizio_pianeti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double m = double.Parse(massa.Text);
            Vettore ve = Vettore.Parse(velocità.Text);
            Vettore sp = Vettore.Parse(spostamento.Text);
            Pianeta p = new Pianeta(m, ve, sp);
            listBox1.Items.Add(p);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {   Vettore s1 = new Vettore(3000,400);
            Vettore v1 = new Vettore(0, 0);
            Pianeta p1 = new Pianeta(1000,s1,v1);
            Vettore s2 = new Vettore(5000, 400);
            Vettore v2 = new Vettore(0, 100);
            Pianeta p2 = new Pianeta(1, s1, v1);

            Graphics g = this.CreateGraphics();
            g.FillEllipse(Brushes.Black, 100, 100, (float)s1.X, (float)s1.Y);
            g.FillEllipse(Brushes.Black, 10, 10, (float)s2.X, (float)s2.Y);

            // s = s0 + v0 * t + 1 / 2 * (F / m) * t * t
            //t = 0,01 s

            Vettore d= new Vettore();
            d = s1.distanza(s2);
            Double f = (6.67 * Math.Pow(-11,10))*((p1.Massa*p2.Massa)/(d*d).Modulo());            

            Vettore F = new Vettore();
            F = f * d.versore();

            Double s = s1.Modulo()+ v1.Modulo() * 0.01 + 1 / 2 * (F.Modulo()/ p1.Massa) * 0.01 * 0.01;
            Vettore ss= new Vettore();

        }
    }
}
