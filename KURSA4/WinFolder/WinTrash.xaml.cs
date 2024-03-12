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

        private void DGTrash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select NameTrash,PriceTrash from Trash", dataBase.GetConnection());

            
            adapter.Fill(dt);         
            DGTrash.ItemsSource = dt.DefaultView;
        }
    }
}
