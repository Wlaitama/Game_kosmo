using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class MapGalactic : Form
    {
        public MapGalactic()
        {
            InitializeComponent();

            pictureBox1.Controls.Add(G);
            G.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(K);
            K.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(F);
            F.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(M);
            M.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(G_2);
            G_2.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(K_2);
            K_2.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(K_3);
            K_3.BackColor = Color.Transparent;

            // создаем экземпляр класса OleDbConnection
            SpaceTradersConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            SpaceTradersConnection.Open();

        }
        string s;
        string s1;
        string s2;
        public MapGalactic(string sq, string sq1, string sq2)
        {
            InitializeComponent();

            pictureBox1.Controls.Add(G);
            G.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(K);
            K.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(F);
            F.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(M);
            M.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(G_2);
            G_2.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(K_2);
            K_2.BackColor = Color.Transparent;
            pictureBox1.Controls.Add(K_3);
            K_3.BackColor = Color.Transparent;
            s = sq;
            s1 = sq1;
            s2 = sq2;
            // создаем экземпляр класса OleDbConnection
            SpaceTradersConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            SpaceTradersConnection.Open();

        }
        //Подключение к MS Access
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SpaceTradersDB.mdb;";


        //Ссылка для связи с БД
        private OleDbConnection SpaceTradersConnection;




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl1.Enabled = false;

        }

        private void K_2_Click(object sender, EventArgs e)
        {
            PictureBox planeta = (PictureBox)sender;
            switch (planeta.Name)
            {
                case "K":
                    K t = new K();
                    t.Owner = this;
                    t.ShowDialog();
                    
                    break;
                case "K_2":
                    K_2 form2 = new K_2();
                    form2.Owner = this;
                    form2.ShowDialog();
                    break;
                case "K_3":
                    K_3 q = new K_3();
                    q.Owner = this;
                    q.ShowDialog();
                    break;
                case "M":
                    M w = new M();
                    w.Owner = this;
                    w.ShowDialog();
                    break;
                case "G":
                    G c = new G();
                    c.Owner = this;
                    c.ShowDialog();
                    break;
                case "G_2":
                    G_2 r = new G_2();
                    r.Owner = this;
                    r.ShowDialog();
                    break;
                case "F":
                    F f = new F();
                    f.Owner = this;
                    f.ShowDialog();
                    break;

            }
        }

   
        public void Enabl()
        {
            tabControl1.SelectedIndex = 1;
          
            K.Enabled = false;
            K_2.Enabled = false;
            K_3.Enabled = false;
            M.Enabled = false;
            G.Enabled = false;
            F.Enabled = false;
            G_2.Enabled = false;
            pictureBox4.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0; i < 6; i++)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1[0, 0].Value = "Оружие";
            dataGridView1[0, 1].Value = "Минералы";
            dataGridView1[0, 2].Value = "Медикаменты";
            dataGridView1[0, 3].Value = "Техника";
            dataGridView1[0, 4].Value = "Роскошь";
            dataGridView1[0, 5].Value = "Продукты";

            int j = 0;
            for (int i = 1; i < 7; i++)
            {

                string sql = $"SELECT Price FROM Goods WHERE Goods_id = {i}";
                OleDbCommand command = new OleDbCommand(sql, SpaceTradersConnection);
                var buttons = BuyBox.Controls.OfType<Button>().ElementAt(j);
                buttons.Text = command.ExecuteScalar().ToString();

                j++;
            }
            j = 0;
            for (int i = 1; i < 7; i++)
            {

                string sql = $"SELECT SellPrice FROM Goods WHERE Goods_id = {i}";
                OleDbCommand command = new OleDbCommand(sql, SpaceTradersConnection);
                var buttons = SellBox.Controls.OfType<Button>().ElementAt(j);
                buttons.Text = command.ExecuteScalar().ToString();

                j++;
            }
            Count();
           
        }

        private void Count()
        {
            int j = 0;
            var selectedSells = StorageBox.Controls.OfType<Label>();
            for (int i = 1; i <= 6; i++)
            {
                string sql = $@"SELECT Count FROM Goods WHERE Goods_id = {i}";
                OleDbCommand command = new OleDbCommand(sql, SpaceTradersConnection);
                var labelName = selectedSells.Where(x => x.Name == $@"lab{i}");
               // var labelType = selectedSells.ElementAt(j);
                var q = labelName.OfType<Label>().ElementAt(0).Text = command.ExecuteScalar().ToString();
                j++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            MessageBox.Show("Вы улетели с планеты. Теперь вы можете перемещаться по карте галактики");
            K.Enabled = true;
            K_2.Enabled = true;
            K_3.Enabled = true;
            M.Enabled = true;
            G.Enabled = true;
            F.Enabled = true;
            G_2.Enabled = true;
            pictureBox4.Visible = true;
            button1.Visible = false;
        }


        private void WeaponsBuy_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 0].Value);
            dec+= numericUpDown7.Value;
            dataGridView1[1, 0].Value = dec;
            decimal money = Convert.ToInt32(label7.Text);
            label7.Text =( money - (numericUpDown7.Value * Convert.ToDecimal(WeaponsBuy.Text))).ToString();
            numericUpDown7.Value = 0;
        }

        private void WeaponsSell_Click(object sender, EventArgs e)
        {
            
            decimal dec = Convert.ToDecimal(dataGridView1[1, 0].Value);
            if ((dec - numericUpDown1.Value) >= 0)
            {
                dec -= numericUpDown1.Value;
                dataGridView1[1, 0].Value = dec;
                decimal money = Convert.ToInt32(label7.Text);
                label7.Text = (money + (numericUpDown1.Value * Convert.ToDecimal(WeaponsSell.Text))).ToString();
                numericUpDown1.Value = 0;
            }
            else
            {
                MessageBox.Show("Товара нет на борту");
            }
        }

        private void MineralsBuy_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 1].Value);
            dec += numericUpDown8.Value;
            dataGridView1[1, 1].Value = dec;
            decimal money = Convert.ToInt32(label7.Text);
            label7.Text = (money - (numericUpDown8.Value * Convert.ToDecimal(MineralsBuy.Text))).ToString();
            numericUpDown8.Value = 0;
        }

        private void MineralsSell_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 1].Value);
            if ((dec - numericUpDown2.Value) >= 0)
            {
                dec -= numericUpDown2.Value;
                dataGridView1[1, 1].Value = dec;
                decimal money = Convert.ToInt32(label7.Text);
                label7.Text = (money + (numericUpDown2.Value * Convert.ToDecimal(MineralsSell.Text))).ToString();
                numericUpDown2.Value = 0;
            }
            else
            {
                MessageBox.Show("Товара нет на борту");
            }
        }

        private void MedicamentsBuy_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 2].Value);
            dec += numericUpDown9.Value;
            dataGridView1[1, 2].Value = dec;
            decimal money = Convert.ToInt32(label7.Text);
            label7.Text = (money - (numericUpDown9.Value * Convert.ToDecimal(MedicamentsBuy.Text))).ToString();
            numericUpDown9.Value = 0;
        }

        private void MedicamentsSell_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 2].Value);
            if ((dec - numericUpDown3.Value) >= 0)
            {
                dec -= numericUpDown3.Value;
                dataGridView1[1, 2].Value = dec;
                decimal money = Convert.ToInt32(label7.Text);
                label7.Text = (money + (numericUpDown3.Value * Convert.ToDecimal(MedicamentsSell.Text))).ToString();
                numericUpDown3.Value = 0;
            }
            else
            {
                MessageBox.Show("Товара нет на борту");
            }
        }

        private void TechniqueBuy_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 3].Value);
            dec += numericUpDown10.Value;
            dataGridView1[1, 3].Value = dec;
            decimal money = Convert.ToInt32(label7.Text);
            label7.Text = (money - (numericUpDown10.Value * Convert.ToDecimal(TechniqueBuy.Text))).ToString();
            numericUpDown10.Value = 0;
        }

        private void TechniqueSell_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 3].Value);
            if ((dec - numericUpDown4.Value) >= 0)
            {
                dec -= numericUpDown4.Value;
                dataGridView1[1, 3].Value = dec;
                decimal money = Convert.ToInt32(label7.Text);
                label7.Text = (money + (numericUpDown4.Value * Convert.ToDecimal(TechniqueSell.Text))).ToString();
                numericUpDown4.Value = 0;
            }
            else
            {
                MessageBox.Show("Товара нет на борту");
            }
        }

        private void LuxuryBuy_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 4].Value);
            dec += numericUpDown11.Value;
            dataGridView1[1, 4].Value = dec;
            decimal money = Convert.ToInt32(label7.Text);
            label7.Text = (money - (numericUpDown11.Value * Convert.ToDecimal(LuxuryBuy.Text))).ToString();
            numericUpDown11.Value = 0;
        }

        private void LuxurySell_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 4].Value);
            if ((dec - numericUpDown5.Value) >= 0)
            {
                dec -= numericUpDown5.Value;
                dataGridView1[1, 4].Value = dec;
                decimal money = Convert.ToInt32(label7.Text);
                label7.Text = (money + (numericUpDown5.Value * Convert.ToDecimal(LuxurySell.Text))).ToString();
                numericUpDown5.Value = 0;
            }
            else
            {
                MessageBox.Show("Товара нет на борту");
            }
        }

        private void ProductsBuy_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 5].Value);
            dec += numericUpDown12.Value;
            dataGridView1[1, 5].Value = dec;
            decimal money = Convert.ToInt32(label7.Text);
            label7.Text = (money - (numericUpDown12.Value * Convert.ToDecimal(ProductsBuy.Text))).ToString();
            numericUpDown12.Value = 0;
        }

        private void ProductsSell_Click(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(dataGridView1[1, 5].Value);
            if ((dec - numericUpDown6.Value) >= 0)
            {
                dec -= numericUpDown6.Value;
                dataGridView1[1, 5].Value = dec;
                decimal money = Convert.ToInt32(label7.Text);
                label7.Text = (money + (numericUpDown6.Value * Convert.ToDecimal(ProductsSell.Text))).ToString();
                numericUpDown6.Value = 0;
            }
            else
            {
                MessageBox.Show("Товара нет на борту");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            new Gl_menu().Show();
            this.Close();
        }
        int index = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (index == 3)
            {
                index = 0;
            }
            index++;
            switch (index)
            {
                case 1:
                    pictureBox2.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBox2.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox2.Image = Properties.Resources._3;
                    break;
            }
   
                
        }

        private void MapGalactic_FormClosing(object sender, FormClosingEventArgs e)
        {
            SpaceTradersConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button4.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void FuelButton_Click(object sender, EventArgs e)
        {
            button1.Visible = true;

            decimal money = Convert.ToInt32(label7.Text);
            label7.Text = (money - (10)).ToString();
            numericUpDown7.Value = 0;


        }
    }
}
