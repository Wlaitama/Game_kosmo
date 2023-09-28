using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TestBDSpaceTraders
{
    public partial class testFormST : Form
    {
        public testFormST()
        {
            InitializeComponent();

            // создаем экземпляр класса OleDbConnection
            SpaceTradersConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            SpaceTradersConnection.Open();
            

        }
        //Подключение к MS Access
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SpaceTradersDB.mdb;";


        //Ссылка для связи с БД
        private OleDbConnection SpaceTradersConnection;




        private void SpaceTradersTEST_Load(object sender, EventArgs e)
        {

            //№1
            //Модуль кнопок цен покупок на товары
            //Запрос на выборку цены покупок из товаров
            string buttonPriceProducts = "SELECT Price FROM Goods WHERE Goods_id = 1";
            string buttonPriceMinerals = "SELECT Price FROM Goods WHERE Goods_id = 2";
            string buttonPriceMedicaments = "SELECT Price FROM Goods WHERE Goods_id = 3";
            string buttonPriceTechnique = "SELECT Price FROM Goods WHERE Goods_id = 4";
            string buttonPriceLuxury = "SELECT Price FROM Goods WHERE Goods_id = 5";
            string buttonPriceWeapon = "SELECT Price FROM Goods WHERE Goods_id = 6";


            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand SetPriceProduct = new OleDbCommand(buttonPriceProducts, SpaceTradersConnection);
            OleDbCommand SetPriceMinerals = new OleDbCommand(buttonPriceMinerals, SpaceTradersConnection);
            OleDbCommand SetPriceMedicaments = new OleDbCommand(buttonPriceMedicaments, SpaceTradersConnection);
            OleDbCommand SetPriceTechnique = new OleDbCommand(buttonPriceTechnique, SpaceTradersConnection);
            OleDbCommand SetPriceLuxury = new OleDbCommand(buttonPriceLuxury, SpaceTradersConnection);
            OleDbCommand SetPriceWeapon = new OleDbCommand(buttonPriceWeapon, SpaceTradersConnection);


            //Вывод из БД
            PriceProducts.Text = SetPriceProduct.ExecuteScalar().ToString();
            PriceMinerals.Text = SetPriceMinerals.ExecuteScalar().ToString();
            PriceMedicaments.Text = SetPriceMedicaments.ExecuteScalar().ToString();
            PriceTechnique.Text = SetPriceTechnique.ExecuteScalar().ToString();
            PriceLuxury.Text = SetPriceLuxury.ExecuteScalar().ToString();
            PriceWeapon.Text = SetPriceWeapon.ExecuteScalar().ToString();


            //№2
            //Модуль кнопок цен продажи на товары
            //Запрос на выборку цены продажи из товаров
            string buttonSellPriceProducts = "SELECT SellPrice FROM Goods WHERE Goods_id = 1";
            string buttonSellPriceMinerals = "SELECT SellPrice FROM Goods WHERE Goods_id = 2";
            string buttonSellPriceMedicaments = "SELECT SellPrice FROM Goods WHERE Goods_id = 3";
            string buttonSellPriceTechnique = "SELECT SellPrice FROM Goods WHERE Goods_id = 4";
            string buttonSellPriceLuxury = "SELECT SellPrice FROM Goods WHERE Goods_id = 5";
            string buttonSellPriceWeapon = "SELECT SellPrice FROM Goods WHERE Goods_id = 6";


            // создаем объект OleDbCommand для выполнения запроса к БД MS   // SellPriceMinerals
            // 
            this.SellPriceMinerals.Location = new System.Drawing.Point(193, 72);
            this.SellPriceMinerals.Name = "SellPriceMinerals";
            this.SellPriceMinerals.Size = new System.Drawing.Size(75, 23);
            this.SellPriceMinerals.TabIndex = 20;
            this.SellPriceMinerals.Text = "0";
            this.SellPriceMinerals.UseVisualStyleBackColor = true;
            // 
            // SellPriceMedicaments
            // 
            this.SellPriceMedicaments.Location = new System.Drawing.Point(193, 114);
            this.SellPriceMedicaments.Name = "SellPriceMedicaments";
            this.SellPriceMedicaments.Size = new System.Drawing.Size(75, 23);
            this.SellPriceMedicaments.TabIndex = 19;
            this.SellPriceMedicaments.Text = "0";
            this.SellPriceMedicaments.UseVisualStyleBackColor = true;
            // 
            // SellPriceTechnique
            // 
            this.SellPriceTechnique.Location = new System.Drawing.Point(193, 151);
            this.SellPriceTechnique.Name = "SellPriceTechnique";
            this.SellPriceTechnique.Size = new System.Drawing.Size(75, 23);
            this.SellPriceTechnique.TabIndex = 22;
            this.SellPriceTechnique.Text = "0";
            this.SellPriceTechnique.UseVisualStyleBackColor = true;
            this.SellPriceTechnique.Click += new System.EventHandler(this.SellPriceTechnique_Click);
            // 
            // SellPriceLuxury
            // 
            this.SellPriceLuxury.Location = new System.Drawing.Point(193, 190);
            this.SellPriceLuxury.Name = "SellPriceLuxury";
            this.SellPriceLuxury.Size = new System.Drawing.Size(75, 23);
            this.SellPriceLuxury.TabIndex = 21;
            this.SellPriceLuxury.Text = "0";
            this.SellPriceLuxury.UseVisualStyleBackColor = true;
            // 
            // Storage
            // 
            this.Storage.Controls.Add(this.CountWeapon);
            this.Storage.Controls.Add(this.CountLuxury);
            this.Storage.Controls.Add(this.CountTechnique);
            this.Storage.Controls.Add(this.CountMedicaments);
            this.Storage.Controls.Add(this.CountMinerals);
            this.Storage.Controls.Add(this.CountProducts);
            this.Storage.Controls.Add(this.StorageWeapon);
            this.Storage.Controls.Add(this.StorageLuxury);
            this.Storage.Controls.Add(this.StorageTechnique);
            this.Storage.Controls.Add(this.StorageMedicaments);
            this.Storage.Controls.Add(this.StorageMinerals);
            this.Storage.Controls.Add(this.StorageProducts);
            this.Storage.Location = new System.Drawing.Point(8, 36);
            this.Storage.Name = "Storage";
            this.Storage.Size = new System.Drawing.Size(200, 265);
            this.Storage.TabIndex = 25;
            this.Storage.TabStop = false;
            this.Storage.Text = "Склад";
            // 
            // CountWeapon
            // 
            this.CountWeapon.AutoSize = true;
            this.CountWeapon.Location = new System.Drawing.Point(110, 192);
            this.CountWeapon.Name = "CountWeapon";
            this.CountWeapon.Size = new System.Drawing.Size(13, 13);
            this.CountWeapon.TabIndex = 11;
            this.CountWeapon.Text = "0";
            // 
            // CountLuxury
            // 
            this.CountLuxury.AutoSize = true;
            this.CountLuxury.Location = new System.Drawing.Point(110, 161);
            this.CountLuxury.Name = "CountLuxury";
            this.CountLuxury.Size = new System.Drawing.Size(13, 13);
            this.CountLuxury.TabIndex = 10;
            this.CountLuxury.Text = "0";
            // 
            // CountTechnique
            // 
            this.CountTechnique.AutoSize = true;
            this.CountTechnique.Location = new System.Drawing.Point(110, 132);
            this.CountTechnique.Name = "CountTechnique";
            this.CountTechnique.Size = new System.Drawing.Size(13, 13);
            this.CountTechnique.TabIndex = 9;
            this.CountTechnique.Text = "0";
            // 
            // CountMedicaments
            // 
            this.CountMedicaments.AutoSize = true;
            this.CountMedicaments;
        }
    }
}