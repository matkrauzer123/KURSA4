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
    /// Логика взаимодействия для WinAdmin.xaml
    /// </summary>
    public partial class WinAdmin : Window
    {
        public WinAdmin()
        {
            InitializeComponent();
        }
        DataBase dataBase = new DataBase(); 
        private void BCurrect_Click(object sender, RoutedEventArgs e)
        {
            var passUser = PBPassword.Password;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string query = $"select   password from Admin where  password = '{passUser}'";
            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(dt);
            MessageBox.Show("Начало", "Смена открыта");
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
            WinOpen winOpen = new WinOpen();
            winOpen.Show();
        }
    }
}
