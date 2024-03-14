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
        Planetario P = new Planetario();
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
        {
            foreach(Pianeta p in listBox1.Items)
            {
                P.Pianeti.Add(p);
            }

            timer2.Enabled = true;

           

            

        }

        private void spostamento_TextChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
     
        }
        
        
        Vettore s1 = Vettore.Parse("300;40");

        Vettore s2 = new Vettore(500, 40);
        private void timer2_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            // s = s0 + v0 * t + 1 / 2 * (F / m) * t * t
            //t = 0,01 s

            Vettore d = new Vettore();
            d = s1.distanza(s2);
            Double f = (6.67 * Math.Pow(10, -6)) * ((1 * 1000000) / (d * d).Modulo());

            Vettore F = new Vettore();
            F = f * (d.versore());
            Vettore v = new Vettore(0, 1000);
            Vettore s = s1 + (v * 0.01) + (1 / 2 * (F / 1) * (0.01 * 0.01));
            s1 = s;
            g.FillEllipse(Brushes.Black, 500, 40, 110, 110);
            g.FillEllipse(Brushes.Black, (float)s.X, (float)s.Y, 10, 10);

            

        }
    }
}
