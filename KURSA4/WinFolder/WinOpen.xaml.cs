using System;
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
        static double price;
        DataBase database = new DataBase();
        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIStroitOtdelInstrument.Header;
        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            MIStroitOtdelInstrument.Header = "Строительно-отделочный \n инструмент";
            LSelect.Content = string.Empty;
        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MISverlInstrument.Header;
        }

        private void MIRuchInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIRuchInstrument.Header;
        }

        private void MIMaliarInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIMaliarInstrument.Header;
        }

        private void MISlesarInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MISlesarInstrument.Header;
        }

        private void MISvarOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MISvarOborudovanie.Header;
        }

        private void MIRashodMaterial_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIRashodMaterial.Header;
        }

        private void MIOsnastka_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIOsnastka.Header;
        }

        private void MIAbrazMaterial_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIAbrazMaterial.Header;
        }

        private void MISadInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MISadInstrument.Header;
        }

        private void MIZashita_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIZashita.Header;
        }

        private void MIOther_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIOther.Header;
        }

        private void MIReshInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIReshInstrument.Header;
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
                query = $"insert into Trash(NameTrash,PriceTrash,StockTrash) values('Буры SDS MAX 40X1000','8319','{stock1}')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);

                price += 8319;
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
                query = $"insert into Trash(NameTrash,PriceTrash,StockTrash) values('Буры SDS MAX 40X600','5664','{stock1}')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);

                price += 5664;
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
                query = $"insert into Trash(NameTrash,PriceTrash,StockTrash) values('РУЛЕТКА VERTEXTOOLS ','471','{stock1}')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);

                price += 471;
                LPrice.Content = price;
            }
        }

        private void BCheck_Click(object sender, RoutedEventArgs e)
        {
            Trash trash = new Trash();
            trash.Show();
            Close();
        }

        
        
    }
}
