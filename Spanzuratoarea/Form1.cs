using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Spanzuratoarea
{
    public partial class Form1 : Form
    {  
        public string [,] sirCuvant = {{"CANGUR", "MAIMUTA","IEPURE","UNICORN","CAINE" },
                                      {"PAINE", "PIZZA", "PASTE", "CIORBA", "PASTRAMA"}};
        public string cuvant, cuvaf;
        public int lg, nrg; public int[] v;
        
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int i; cuvaf = "";
            cuvant = "AMERICA"; nrg = 0;
             Random rr = new Random();
            if (animaleToolStripMenuItem.Checked && mancareToolStripMenuItem.Checked)
            {
                cuvant = sirCuvant[rr.Next(2), rr.Next(5)];
            }
            else if (animaleToolStripMenuItem.Checked)
            {
                cuvant = sirCuvant[0, rr.Next(5)];
            }
            else
                cuvant = sirCuvant[1, rr.Next(5)];
            lg = cuvant.Length;
            pictureBox1.Image = null;
            foreach(object ob in panel1.Controls)
            ((Button)ob).Enabled = true;
            v = new int[lg]; for (i = 1; i < lg - 1; i++) v[i] = 0; v[0] = v[lg - 1] = 1;
            for (i = 0; i < lg; i++) if (v[i] == 0) cuvaf += "- ";
                else cuvaf += cuvant[i] + " ";
            label1.Text = cuvaf;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            char lit; int i, gr = 0, gr1 = 0; cuvaf=""; Button b = sender as Button;
            lit = b.Text[0]; b.Enabled = false;
            for (i = 0; i < lg; i++) if (cuvant[i] == lit) { gr = 1; v[i] = 1; }
            for (i = 0; i < lg; i++) if (v[i] == 0) { cuvaf += "- "; gr1 = 1; }
                else cuvaf += cuvant[i] + " ";
            label1.Text = cuvaf;
            if (gr == 0) { nrg++; pictureBox1.Load("sp" + nrg + ".png"); }
            if (nrg == 6 || gr1 == 0) {foreach(object ob in panel1.Controls)
                               ((Button)ob).Enabled = false;
                if (gr1 == 0) MessageBox.Show("Ai ghicit!");
                else MessageBox.Show("Ai murit! ");
                       }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

		

		private void timerToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este cel mai bun joc pe care l-ati vazut vreodata!");
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dati click pe cate o litera.");
        }
    }
}