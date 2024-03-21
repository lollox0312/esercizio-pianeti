using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace esercizio_pianeti
{
    public partial class Form1 : Form
    {
        public void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 0, 64);
            label1.ForeColor = Color.White; label3.ForeColor = Color.White;
            label4.ForeColor = Color.White; label5.ForeColor = Color.White;

            
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
            
            if(!double.TryParse(massa.Text,out double  m))
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
          
            Random random = new Random();
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(0));
            Pianeta p = new Pianeta(m, ve, posizione);
            p.rr = randomColor;
            listBox1.Items.Add(p.ToString());
            P.Pianeti.Add(p);
            massa.Clear();
            velocità.Clear();
            Posizione.Clear();
            Nome.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            P.Pianeti.RemoveAt(listBox1.SelectedIndex);

        }

        //private Planetario GetP()
        //{
        //    return P;
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            
            


            Random r = new Random();
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 20; i++)
            {
                g.FillEllipse(Brushes.White, r.Next(this.ClientSize.Width), r.Next(this.ClientSize.Height), 5, 5);
            }
            

            timer2.Enabled = true;

            
            

        }

        private void spostamento_TextChanged(object sender, EventArgs e)
        {

        }

      
        
        
        
        private void timer2_Tick(object sender, EventArgs e)
        { 
            // Refresh();
            DisegnoPianeti();

            for (int i = 0; i < 1000; i++)
            {
                P.Move();
            }

            DisegnoPianeti();



        }
        
       
        private void DisegnoPianeti()
        {
            
            
            Graphics g=this.CreateGraphics();
            foreach(Pianeta p in P.Pianeti)
            {
                p.R =20 * Math.Pow(p.Massa, 1 / 3);
                Brush b = new SolidBrush(p.rr);
                g.FillEllipse(b, (float)p.Posizione.X, (float)p.Posizione.Y, (float)p.R, (float)p.R);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Planetario));
        private void btnSalva_Click(object sender, EventArgs e)
        {
            TextWriter textWriter = new StreamWriter("C:\\TEMP\\MyXmlFile.txt");
            xmlSerializer.Serialize(textWriter, P);
            textWriter.Close();
        }

        private void btnRecupera_Click(object sender, EventArgs e)
        {
            TextReader textReader = new StreamReader("C:\\TEMP\\MyXmlFile.txt");
            Planetario planetario = (Planetario)xmlSerializer.Deserialize(textReader);
            textReader.Close();
        }
    }
}
