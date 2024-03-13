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
            Button senderButton = sender as Button;
            DataRowView dataRowView = senderButton.DataContext as DataRowView;
            dt.Rows.Remove(dataRowView.Row);
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dt.NewRow();
            // Заполните новую строку данными на ваш выбор
            dt.Rows.Add(newRow);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter("Select NameTrash,PriceTrash from Trash", dataBase.GetConnection());

            adapter.Fill(dt);         
            DGTrash.ItemsSource = dt.DefaultView;
              
        }

     
    }
}
