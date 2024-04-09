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
using static KURSA4.WinFolder.WinOpen;

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
        static int first = 0;
        private void BCurrect_Click(object sender, RoutedEventArgs e)
        {
            dataBase.sqlOpen();
            var passUser = PBPassword.Password;
            var N = TBNumber.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string query = $"select   PasswordEmployee from Employee where   PasswordEmployee = '{passUser}' AND NumberEmployee = '{N}'";
            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            sqlDataAdapter.SelectCommand = command;


            try
            {



                sqlDataAdapter.Fill(dt);
                int a = dt.Rows.Count;
                if (a == 1)
                {
                    string query2 = $"select   IdEmployee from Employee where   PasswordEmployee = '{passUser}' AND NumberEmployee = '{N}'";
                    SqlCommand sqlTrashs = new SqlCommand(query2, dataBase.GetConnection());
                    sqlDataAdapter.SelectCommand = sqlTrashs;
                    var id = (int)sqlTrashs.ExecuteScalar();
                    string query1 = $"select   NameEmployee from Employee where   PasswordEmployee = '{passUser}' AND NumberEmployee = '{N}'";
                    SqlCommand command1 = new SqlCommand(query1, dataBase.GetConnection());
                    sqlDataAdapter.SelectCommand = command1;
                    string name = (string)command1.ExecuteScalar();
                    query = $"insert into [End](NameEnd,SumEnd,IdEmployee) values('{name}',0,{id})";
                    SqlCommand sqlTrash = new SqlCommand(query, dataBase.GetConnection());
                    sqlDataAdapter.SelectCommand = sqlTrash;
                    sqlTrash.ExecuteNonQuery();

                    MessageBox.Show("Начало", "Смена открыта", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (first == 0)
                    {
                        Close();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Close();
                        WinOpen winOpen = new WinOpen();
                        winOpen.Show();
                        first++;
                    }
                    else
                    {
                        Close();
                    }


                }

                else
                {
                    MessageBox.Show("Неверный номер или пароль!!", "Проблема!!", MessageBoxButton.OK, MessageBoxImage.Error);


                }
                dataBase.sqlClose();
            }
            catch (Exception)
            {

                MessageBox.Show("В номере только цифры", "Проблема!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }






        }
    }
}
