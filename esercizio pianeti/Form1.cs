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
    {  public void Form1_Load(object sender, EventArgs e)
        {
     
        }
        Planetario P;
        
        public Form1()
        {
            InitializeComponent();
            P = new Planetario();
            P.Pianeti = new List<Pianeta>();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            double m; 
            if(!double.TryParse(massa.Text,out  m))
            {
             MessageBox.Show("ERRORE","ERRORE");
                return;
            }
            if(!Vettore.TryParse(velocità.Text,out Vettore ve))
            {
                MessageBox.Show("ERRORE", "ERRORE");
                return;
            }
            if (!Vettore.TryParse(Posizione.Text, out Vettore posizione))
            {
                MessageBox.Show("ERRORE", "ERRORE");
                return;
            }
        
            Pianeta p = new Pianeta(m, ve, posizione);
            listBox1.Items.Add(p);
            massa.Clear();
            velocità.Clear();
            Posizione.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);

        }

        //private Planetario GetP()
        //{
        //    return P;
        //}

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

      
        
        
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            DisegnoPianeti();
            P.Move();
            Refresh();

        }
        private void DisegnoPianeti()
        {
            ;
            Graphics g=this.CreateGraphics();
            foreach(Pianeta p in P.Pianeti)
            {
                g.FillEllipse(Brushes.Black, (float)p.Posizione.X, (float)p.Posizione.Y, 10, 10);
            }
        }
    }
}
