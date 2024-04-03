﻿using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TopCar;

namespace KURSA4.WinFolder
{
    /// <summary>
    /// Логика взаимодействия для WinOpen.xaml
    /// </summary>
    public partial class WinOpen : Window
    {
        public WinOpen()
        {
            InitializeComponent();
        }
        static int price;
        DataBase database = new DataBase();
        DataTable dt = new DataTable();
        SqlDataAdapter adapter;
        public class ItemModel
        {
            public Image ImagePath { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {
           WinStroitOtdelInstrument winStroitOtdelInstrument = new WinStroitOtdelInstrument();
          
            Close();
            winStroitOtdelInstrument.ShowDialog();
        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            string  query = $"select  PriceUsers FROM PriceUser ";
            SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
           SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();    
            sqlDataAdapter.SelectCommand = sqlprice;
           var a = sqlprice.ExecuteScalar();
           price = Convert.ToInt32(a);  
            if (price!=0)
            {
                LPrice.Content = price;
            }
            MIStroitOtdelInstrument.Header = "Строительно-отделочный \n инструмент";
         
            database.sqlClose();
        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {
           
            WinSverlInstrument winSverlInstrument = new WinSverlInstrument();
           
            Close();
            winSverlInstrument.ShowDialog();
        }

        private void MIRuchInstrument_Click(object sender, RoutedEventArgs e)
        {
            
            WinRuchInstrument winRuchInstrument = new WinRuchInstrument();
            Close();
            winRuchInstrument.ShowDialog();
           
        }

        private void MIMaliarInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinMaliarInstrument winMaliarInstrument = new WinMaliarInstrument();
          
            Close();
            winMaliarInstrument.ShowDialog();
        }

        private void MISlesarInstrument_Click(object sender, RoutedEventArgs e)
        {
          WinSlesarInstrument winSlesarInstrument = new WinSlesarInstrument();
           
            Close();
            winSlesarInstrument.ShowDialog();
        }

        private void MISvarOborudovanie_Click(object sender, RoutedEventArgs e)
        {
          WinSvarOborudovanie  winSvarOborudovanie = new WinSvarOborudovanie();
           
            Close();
            winSvarOborudovanie.ShowDialog();
        }

        private void MIRashodMaterial_Click(object sender, RoutedEventArgs e)
        {
           WinRashodMaterial winRashodMaterial = new WinRashodMaterial();
            
            Close();
            winRashodMaterial.ShowDialog();
        }

        private void MIOsnastka_Click(object sender, RoutedEventArgs e)
        {
            WinOsnastka winOsnastka = new WinOsnastka();
             
            Close();
            winOsnastka.ShowDialog();
        }

        private void MIAbrazMaterial_Click(object sender, RoutedEventArgs e)
        {
           WinAbrazMaterial winAbrazMaterial = new WinAbrazMaterial();
          
            Close();
            winAbrazMaterial.ShowDialog();
        }

        private void MISadInstrument_Click(object sender, RoutedEventArgs e)
        {
           WinSadInstrument winSadInstrument = new WinSadInstrument();  
          
            Close();
            winSadInstrument.ShowDialog();
        }

        private void MIZashita_Click(object sender, RoutedEventArgs e)
        {
           WinZashita winZashita = new WinZashita();
          
            Close();
            winZashita.ShowDialog();
        }

        private void MIOther_Click(object sender, RoutedEventArgs e)
        {
           WinOther winOther = new WinOther();
           
            Close();
            winOther.ShowDialog();
        }

        private void MIReshInstrument_Click(object sender, RoutedEventArgs e)
        {
           WinReshInstrument winReshInstrument = new WinReshInstrument();
            
            Close();
            winReshInstrument.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B40X1000_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "Select StockTools  from Tools  where IdTools='1'";
            SqlCommand sqlCommand = new SqlCommand(query, database.GetConnection());
            sqlDataAdapter.SelectCommand = sqlCommand;
            int stock1 = (int)sqlCommand.ExecuteScalar();

            if (stock1 == 0)
            {
                MessageBox.Show("Больше нет в наличии", "Проблема!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                stock1--;
                DataTable dataTable = new DataTable();
                query = $"update  Tools set StockTools ='{stock1}' where IdTools='1'";
                SqlCommand sqlCommandd = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlCommandd;
                sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                query = $"insert into Trash(NameTrash,PriceTrash) values('Буры SDS MAX 40X1000','8319')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
             
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+8319";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);

                query = $"select  PriceUsers FROM PriceUser";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
                LPrice.Content = price;

            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void B40X1000_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void B40X600_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "Select StockTools  from Tools  where IdTools='2'";
            SqlCommand sqlCommand = new SqlCommand(query, database.GetConnection());
            sqlDataAdapter.SelectCommand = sqlCommand;
            int stock1 = (int)sqlCommand.ExecuteScalar();

            if (stock1 == 0)
            {
                MessageBox.Show("Больше нет в наличии", "Проблема!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                stock1--;
                DataTable dataTable = new DataTable();
                query = $"update  Tools set StockTools ='{stock1}' where IdTools='2'";
                SqlCommand sqlCommandd = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlCommandd;
                sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                query = $"insert into Trash(NameTrash,PriceTrash) values('Буры SDS MAX 40Х600','5664')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+5664";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUsers FROM PriceUser";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
                LPrice.Content = price;
            }
        }

        private void BRulet_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "Select StockTools  from Tools  where IdTools='3'";
            SqlCommand sqlCommand = new SqlCommand(query, database.GetConnection());
            sqlDataAdapter.SelectCommand = sqlCommand;
            int stock1 = (int)sqlCommand.ExecuteScalar();

            if (stock1 == 0)
            {
                MessageBox.Show("Больше нет в наличии", "Проблема!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                stock1--;
                DataTable dataTable = new DataTable();
                query = $"update  Tools set StockTools ='{stock1}' where IdTools='3'";
                SqlCommand sqlCommandd = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlCommandd;
                sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                query = $"insert into Trash(NameTrash,PriceTrash) values('РУЛЕТКА VERTEXTOOLS ','471')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+471";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUsers FROM PriceUser";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
                LPrice.Content = price;
            }
        }

        private void BCheck_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            string query = $"select  PriceUsers FROM PriceUser";
            SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlprices;

            var a = sqlprices.ExecuteScalar();
            price = Convert.ToInt32(a);

            switch (a)
            {
                case 0 :
                    MessageBox.Show("Корзина пуста!", "Проблема!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                default:
                    Trash trash = new Trash();
                   
                    Close();
                    trash.Show();
                    break;
            }
           database.sqlClose();
           
        }

        private void WinOpen1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void TBPrice1_Копировать_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DGTrash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter("Select IdTrash,NameTrash from Trash", database.GetConnection());
            database.sqlOpen();
            adapter.Fill(dt);
            dt.Columns[0].ColumnName = "ID продукта";
            dt.Columns[1].ColumnName = "Название";
            dt.Columns[2].ColumnName = "Цена";
            listView1.ItemsSource = dt.DefaultView;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
