using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Collections;
using Microsoft.SqlServer.Server;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Xml.Linq;
using DocumentFormat.OpenXml.InkML;

namespace KURSA4.WinFolder
{
    /// <summary>
    /// Логика взаимодействия для Trash.xaml
    /// </summary>
    public partial class Trash : Window
    {
        public Trash()
        {
            InitializeComponent();

        }
      
        DataBase dataBase = new DataBase();
        DataTable dt = new DataTable();
        SqlDataAdapter adapter ;
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dataBase.sqlOpen();
            Button senderButton = sender as Button;
            DataRowView dataRowView = senderButton.DataContext as DataRowView;
            //update Tools set StockTools = 101 where NameTools = 'МАРКЕР СТРОИТ.ЧЕРНЫЙ'
            string id = dataRowView.Row["ID продукта"].ToString();
            string name = dataRowView.Row["Название"].ToString();
            string price = dataRowView.Row["Цена"].ToString();
            string query = $"Delete from Trash where IdTrash={Convert.ToInt32(id)}";
            SqlCommand sqlTrash = new SqlCommand(query, dataBase.GetConnection());
            adapter.SelectCommand = sqlTrash;
            sqlTrash.ExecuteNonQuery();
            string query1 = $"update PriceUser set PriceUsers=PriceUsers-{Convert.ToInt32(price)}";
            SqlCommand sqlTrash1 = new SqlCommand(query1, dataBase.GetConnection());
            adapter.SelectCommand = sqlTrash1;
            sqlTrash1.ExecuteNonQuery();

            string querys = $"Select StockTools  from Tools  where NameTools = '{name}'";
            SqlCommand sqlCommand = new SqlCommand(querys, dataBase.GetConnection());
            adapter.SelectCommand = sqlCommand;
            int stock1 = (int)sqlCommand.ExecuteScalar();

            string query3 = $"update Tools set StockTools = {stock1+1} where NameTools = '{name}'";
            SqlCommand sqlTrash3 = new SqlCommand(query3, dataBase.GetConnection());
            adapter.SelectCommand = sqlTrash3;
            sqlTrash3.ExecuteNonQuery();
            string query2 = $"SELECT PriceUsers FROM PriceUser";
            SqlCommand sqlTrash2 = new SqlCommand(query2, dataBase.GetConnection());
            adapter.SelectCommand = sqlTrash2;
            var a = sqlTrash2.ExecuteScalar();
            LPriceFinal.Content = a;
            dt.Rows.Remove(dataRowView.Row);
            dataBase.sqlClose();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            dataBase.sqlOpen();

            Button senderButton = sender as Button;
            DataRowView dataRowView = senderButton.DataContext as DataRowView;
            int id = (int)dataRowView.Row["ID продукта"];
            string name = dataRowView.Row["Название"].ToString();
            string price = dataRowView.Row["Цена"].ToString();

            string maxid = $"Select Max(IdTrash) from Trash";
            SqlCommand sqlCommandd = new SqlCommand(maxid, dataBase.GetConnection());
            adapter.SelectCommand = sqlCommandd;
            int max = Convert.ToInt32( sqlCommandd.ExecuteScalar());
            string querys = $"Select StockTools  from Tools  where NameTools = '{name}'";
            SqlCommand sqlCommand = new SqlCommand(querys, dataBase.GetConnection());
            adapter.SelectCommand = sqlCommand;
            int stock1 = (int)sqlCommand.ExecuteScalar();
            if (stock1==0)
            {
                MessageBox.Show("Больше нет в наличии", "Проблема!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string query1 = $"insert into Trash(NameTrash,PriceTrash)values('{name}',{price})";
                SqlCommand sqlTrash1 = new SqlCommand(query1, dataBase.GetConnection());
                adapter.SelectCommand = sqlTrash1;
                sqlTrash1.ExecuteNonQuery();
                string query2 = $"update PriceUser set PriceUsers=PriceUsers+{Convert.ToInt32(price)}";
                SqlCommand sqlTrash2 = new SqlCommand(query2, dataBase.GetConnection());
                adapter.SelectCommand = sqlTrash2;
                sqlTrash2.ExecuteNonQuery();



                string query4 = $"update Tools set StockTools = {stock1 - 1} where NameTools = '{name}'";
                SqlCommand sqlTrash4 = new SqlCommand(query4, dataBase.GetConnection());
                adapter.SelectCommand = sqlTrash4;
                sqlTrash4.ExecuteNonQuery();

                string query3 = $"SELECT PriceUsers FROM PriceUser";
                SqlCommand sqlTrash3 = new SqlCommand(query3, dataBase.GetConnection());
                adapter.SelectCommand = sqlTrash2;
                var a = sqlTrash3.ExecuteScalar();
                LPriceFinal.Content = a;
                DataRow newRow = dt.NewRow();
                newRow["ID продукта"] = (max+1);
                newRow["Название"] = name;
                newRow["Цена"] = price;


                dt.Rows.Add(newRow);
            }
            
            dataBase.sqlClose();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter("Select IdTrash,NameTrash,PriceTrash from Trash", dataBase.GetConnection());
            dataBase.sqlOpen();
            adapter.Fill(dt);
            dt.Columns[0].ColumnName = "ID продукта";
            dt.Columns[1].ColumnName = "Название";
            dt.Columns[2].ColumnName = "Цена";
            DGTrash.IsReadOnly = true;
            DGTrash.ItemsSource = dt.DefaultView;
            DataTable dataTable1 = new DataTable();
             string query = $"SELECT PriceUsers FROM PriceUser";
            SqlCommand sqlTrash = new SqlCommand(query, dataBase.GetConnection());
            adapter.SelectCommand = sqlTrash;
            var a = sqlTrash.ExecuteScalar();
            LPriceFinal.Content = a;
            dataBase.sqlClose();
        }

        private void BBuy_Click(object sender, RoutedEventArgs e)
        {
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("Вы ничего не заказали!!", "Проблема!",MessageBoxButton.OK,MessageBoxImage.Warning);

            }
            else
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
               nzakaza nzakaza = new nzakaza();
                int id = nzakaza.GetId();
         
                string filePath = System.IO.Path.Combine(desktopPath, $"заказ №{id}.txt");
                id++;
                nzakaza.Setid(id);


                
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Записываем текст в файл
                    foreach (DataRow row in dt.Rows)
                    {
                       
                        writer.WriteLine(row["Название"] + " - " + row["Цена"] + "р.");
                    }
                    writer.WriteLine($"\n\n\t\t Сумма: {LPriceFinal.Content}");
                }
                dataBase.sqlOpen();
                MessageBox.Show("Спасибо за покупку!!!", "Чек сделан!", MessageBoxButton.OK, MessageBoxImage.Information);
                string query = $"UPDATE [End]SET EndPrice= EndPrice+{(int)LPriceFinal.Content}WHERE IdEnd = (SELECT MAX(IdEnd) FROM [End])";
                SqlCommand sqlTrash = new SqlCommand(query, dataBase.GetConnection());
                adapter.SelectCommand = sqlTrash;
                sqlTrash.ExecuteNonQuery();
                string del = $"Delete from Trash";
                SqlCommand sqldel = new SqlCommand(del, dataBase.GetConnection());
                adapter.SelectCommand = sqldel;
                sqldel.ExecuteNonQuery();

                string query1 = $"update PriceUser set PriceUsers=0";
                SqlCommand sqlTrash1 = new SqlCommand(query1, dataBase.GetConnection());
                adapter.SelectCommand = sqlTrash1;
                sqlTrash1.ExecuteNonQuery();
                dataBase.sqlClose();
                dataBase.sqlClose();
                WinOpen winOpen = new WinOpen();
                winOpen.Show();
                Close();
            }
           

        }
        private void DGTrash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BBck_Click(object sender, RoutedEventArgs e)
        {
           WinOpen winOpen = new WinOpen();
            winOpen.ShowDialog();
            Hide();
           
          
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dataBase.sqlOpen() ;
           string query = $"update [End] set EndDate ='{DateTime.Today.Date}' WHERE IdEnd = (SELECT MAX(IdEnd) FROM [End])";
            SqlCommand sqlTrash = new SqlCommand(query, dataBase.GetConnection());
           adapter.SelectCommand = sqlTrash;
            sqlTrash.ExecuteNonQuery();
            string del = $"Delete from Trash";
            SqlCommand sqldel = new SqlCommand(del, dataBase.GetConnection());
            adapter.SelectCommand = sqldel;
            sqldel.ExecuteNonQuery();

            string query1 = $"update PriceUser set PriceUsers=0";
            SqlCommand sqlTrash1 = new SqlCommand(query1, dataBase.GetConnection());
            adapter.SelectCommand = sqlTrash1;
            sqlTrash1.ExecuteNonQuery();
            dataBase.sqlClose();
           
            

        }
    }
}
