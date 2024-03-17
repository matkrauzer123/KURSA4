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
            dt.Rows.Remove(dataRowView.Row);
            string deletedName = dataRowView["NameTrash"] as string;
            int deletedPrice = Convert.ToInt32(dataRowView["PriceTrash"]);
            dataBase.sqlClose();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            dataBase.sqlOpen();
            DataRow newRow = dt.NewRow();
            // Заполните новую строку данными на ваш выбор
            dt.Rows.Add(newRow);
            dataBase.sqlClose();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter("Select NameTrash,PriceTrash from Trash", dataBase.GetConnection());
            dataBase.sqlOpen();
            adapter.Fill(dt);         
            DGTrash.ItemsSource = dt.DefaultView;
            DataTable dataTable1 = new DataTable();
             string query = $"SELECT PriceUser FROM PriceUsers";
            SqlCommand sqlTrash = new SqlCommand(query, dataBase.GetConnection());
            adapter.SelectCommand = sqlTrash;
            var a = sqlTrash.ExecuteScalar();
            LPriceFinal.Content = a;
            dataBase.sqlClose();
        }

        private void BBuy_Click(object sender, RoutedEventArgs e)
        {
             
        }

       
    }
}
