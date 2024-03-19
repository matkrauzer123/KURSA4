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
            string id = dataRowView.Row["IdTrash"].ToString();
            string name = dataRowView.Row["NameTrash"].ToString();
            string price = dataRowView.Row["PriceTrash"].ToString();
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
            int id = (int)dataRowView.Row["IdTrash"];
            string name = dataRowView.Row["NameTrash"].ToString();
            string price = dataRowView.Row["PriceTrash"].ToString();

            string maxid = $"Select Max(IdTrash) from Trash";
            SqlCommand sqlCommandd = new SqlCommand(maxid, dataBase.GetConnection());
            adapter.SelectCommand = sqlCommandd;
            int max = (int)sqlCommandd.ExecuteScalar();
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
                newRow["IdTrash"] = (max+1);
                newRow["NameTrash"] = name;
                newRow["PriceTrash"] = price;


                dt.Rows.Add(newRow);
            }
            
            dataBase.sqlClose();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter("Select IdTrash,NameTrash,PriceTrash from Trash", dataBase.GetConnection());
            dataBase.sqlOpen();
            adapter.Fill(dt);         
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
             
        }

        private void DGTrash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BBck_Click(object sender, RoutedEventArgs e)
        {
           WinOpen winOpen = new WinOpen();
            winOpen.ShowDialog();
            Close();
        }
    }
}
