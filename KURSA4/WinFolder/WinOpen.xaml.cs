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
        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIStroitOtdelInstrument.Header;
        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            string  query = $"select  PriceUser FROM PriceUsers ";
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
            LSelect.Content = string.Empty;
            database.sqlClose();
        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MISverlInstrument.Header;
            WinSverlInstrument winSverlInstrument = new WinSverlInstrument();
            winSverlInstrument.ShowDialog();
            Close();
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
                DataTable dt = new DataTable();
                query = $"update  PriceUsers set PriceUser =PriceUser+8319";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUser FROM PriceUsers";
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
                query = $"insert into Trash(NameTrash,PriceTrash,StockTrash) values('Буры SDS MAX 40X600','5664','{stock1}')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUsers set PriceUser =PriceUser+5664";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUser FROM PriceUsers";
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
                query = $"insert into Trash(NameTrash,PriceTrash,StockTrash) values('РУЛЕТКА VERTEXTOOLS ','471','{stock1}')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUsers set PriceUser =PriceUser+471";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUser FROM PriceUsers";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
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
