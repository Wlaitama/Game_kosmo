using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class K_2 : Form
    {
        public K_2()
        {
            InitializeComponent();


            pB1.Controls.Add(p1);
            p1.BackColor = Color.Transparent;
            pB1.Controls.Add(p2);
            p2.BackColor = Color.Transparent;
            pB1.Controls.Add(p3);
            p3.BackColor = Color.Transparent;
            pB1.Controls.Add(p4);
            p4.BackColor = Color.Transparent;
            pB1.Controls.Add(p5);
            p5.BackColor = Color.Transparent;
            
                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MapGalactic f = new MapGalactic();
            f.Show();

            this.Visible = false;
            K_2 fr = new K_2();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MapGalactic f = new MapGalactic();
            f.Show();

            this.Visible = false;
            K_2 fr = new K_2();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void p5_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
        }

        private void p1_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            panel1.Visible = true;

            label3.Text = "2";
            label4.Text = "2";
            label6.Text = "2";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            panel1.Visible = true;
            label3.Text = "1";
            label4.Text = "1";
            label6.Text = "1";

        }

        private void p3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Невозможно посетить");
        }

        private void p2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Невозможно посетить");
        }

        private void p4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Невозможно посетить");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MapGalactic f = (MapGalactic)Owner;
            f.Enabl();
            this.Close();
     
        }


    }
}
