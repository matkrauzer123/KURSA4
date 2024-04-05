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
            dataBase.sqlOpen();
            var passUser = PBPassword.Password;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string query = $"select   PasswordEmployee from Employee where   PasswordEmployee = '{passUser}'";
            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            sqlDataAdapter.SelectCommand = command;

            

            sqlDataAdapter.Fill(dt);
            int a = dt.Rows.Count;
            if (a==1)
            {
                string query1 = $"select   NameEmployee from Employee where   PasswordEmployee = '{passUser}'";
                SqlCommand command1 = new SqlCommand(query1, dataBase.GetConnection());
                sqlDataAdapter.SelectCommand = command1;
                string name = (string)command1.ExecuteScalar();
                query = $"insert into [End](NameEnd,SumEnd) values('{name}',0)";
                SqlCommand sqlTrash = new SqlCommand(query, dataBase.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlTrash.ExecuteNonQuery();
               
                MessageBox.Show("Начало", "Смена открыта",MessageBoxButton.OK,MessageBoxImage.Information);
                Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Close();
                WinOpen winOpen = new WinOpen();
                winOpen.Show();

            }
            else
            {
                MessageBox.Show("Пароль неверный!!", "Проблема!!",MessageBoxButton.OK,MessageBoxImage.Error);

               
            }
            dataBase.sqlClose();







        }
    }
}
