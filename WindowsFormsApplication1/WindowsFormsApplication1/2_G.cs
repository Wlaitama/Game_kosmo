using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class G : Form
    {
        public G()
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
            G fr = new G();
        }

        private void F2_Load(object sender, EventArgs e)
        {

        }

        private void p3_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Невозможно посетить");MessageBox.Show("НЕЛЬЗЯ");
        }

        private void p5_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
        }

        private void p1_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label3.Text = "1";
            label4.Text = "1";
            label6.Text = "1";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MapGalactic f = (MapGalactic)Owner;
            f.Enabl();
            this.Close();
        
        }
    }
}
