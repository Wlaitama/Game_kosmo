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
    public partial class Gl_menu : Form
    {
        public Gl_menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MapGalactic z = new MapGalactic();
            z.Show();
            this.Visible = false;
            Gl_menu fr = new Gl_menu();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this,"SpaceTradersHelp.chm");
        }
    }
}
