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
            Vettore ve = Vettore.Parse(vettore.Text);
            Vettore sp = Vettore.Parse(spostamento.Text);
            Pianeta p = new Pianeta(m, ve, sp);
            listBox1.Items.Add(p);

        }
    }
}
