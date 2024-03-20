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
    /// Логика взаимодействия для WinOsnastka.xaml
    /// </summary>
    public partial class WinOsnastka : Window
    {
        public WinOsnastka()
        {
            InitializeComponent();
        }

        static int price;
        DataBase database = new DataBase();
        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            string query = $"select  PriceUsers FROM PriceUser ";
            SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlprice;
            var a = sqlprice.ExecuteScalar();
            price = Convert.ToInt32(a);
            if (price != 0)
            {
                LPrice.Content = price;
            }
            MIStroitOtdelInstrument.Header = "Строительно-отделочный \n инструмент";

            database.sqlClose();
        }

        private void MIKatalog_Click(object sender, RoutedEventArgs e)
        {
            WinOpen winOpen = new WinOpen();
            winOpen.ShowDialog();
            Close();
        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinSverlInstrument winSverlInstrument = new WinSverlInstrument();
            winSverlInstrument.ShowDialog();
            Close();
        }

        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinStroitOtdelInstrument winStroitOtdelInstrument = new WinStroitOtdelInstrument();
            winStroitOtdelInstrument.ShowDialog();
            Close();
        }

        private void MIReshInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinReshInstrument winReshInstrument = new WinReshInstrument();
            winReshInstrument.ShowDialog();
            Close();
        }

        private void MIRuchInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinRuchInstrument winRuchInstrument = new WinRuchInstrument();
            winRuchInstrument.ShowDialog();
            Close();
        }

        private void MISlesarInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinSlesarInstrument winSlesarInstrument = new WinSlesarInstrument();
            winSlesarInstrument.ShowDialog();
            Close();
        }

        private void MISvarOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            WinSvarOborudovanie winSvarOborudovanie = new WinSvarOborudovanie();
            winSvarOborudovanie.ShowDialog();
            Close();
        }

        private void MIRashodMaterial_Click(object sender, RoutedEventArgs e)
        {
            WinRashodMaterial winRashodMaterial = new WinRashodMaterial();
            winRashodMaterial.ShowDialog();
            Close();
        }

        private void MIOsnastka_Click(object sender, RoutedEventArgs e)
        {
          //
        }

        private void MIAbrazMaterial_Click(object sender, RoutedEventArgs e)
        {
            WinAbrazMaterial winAbrazMaterial = new WinAbrazMaterial();
            winAbrazMaterial.ShowDialog();
            Close();
        }

        private void MISadInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinSadInstrument winSadInstrument = new WinSadInstrument();
            winSadInstrument.ShowDialog();
            Close();
        }

        private void MIZashita_Click(object sender, RoutedEventArgs e)
        {
            WinZashita winZashita = new WinZashita();
            winZashita.ShowDialog();
            Close();
        }

        private void MIOther_Click(object sender, RoutedEventArgs e)
        {
            WinOther winOther = new WinOther();
            winOther.ShowDialog();
            Close();
        }

        private void MIMaliarInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinMaliarInstrument winMaliarInstrument = new WinMaliarInstrument();
            winMaliarInstrument.ShowDialog();
            Close();
        }

        private void BCheck_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            string query = $"select  PriceUsers FROM PriceUser";
            SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlprices;

            var a = sqlprices.ExecuteScalar();
            price = Convert.ToInt32(a);

            switch (a)
            {
                case 0:
                    MessageBox.Show("Корзина пуста!", "Проблема!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                default:
                    Trash trash = new Trash();
                    trash.Show();
                    Close();
                    break;
            }
            database.sqlClose();
        }

        private void BSds_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "Select StockTools  from Tools  where IdTools='12'";
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
                query = $"update  Tools set StockTools ='{stock1}' where IdTools='12'";
                SqlCommand sqlCommandd = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlCommandd;
                sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                query = $"insert into Trash(NameTrash,PriceTrash) values('ПЕРЕХОДНИК НА SDS+','1235')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+1235";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUsers FROM PriceUser";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
                LPrice.Content = price;
            }
        }

        private void B14X400X20_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "Select StockTools  from Tools  where IdTools='13'";
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
                query = $"update  Tools set StockTools ='{stock1}' where IdTools='13'";
                SqlCommand sqlCommandd = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlCommandd;
                sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                query = $"insert into Trash(NameTrash,PriceTrash) values('ЗУБИЛО SDS 14Х400Х20','424')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+424";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUsers FROM PriceUser";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
                LPrice.Content = price;
            }
        }

        private void BBit_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "Select StockTools  from Tools  where IdTools='14'";
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
                query = $"update  Tools set StockTools ='{stock1}' where IdTools='14'";
                SqlCommand sqlCommandd = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlCommandd;
                sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                query = $"insert into Trash(NameTrash,PriceTrash) values('АДАПТЕР ДЛЯ БИТ 150мм','599')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+599";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUsers FROM PriceUser";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
                LPrice.Content = price;
            }
        }

        private void B14X250X20_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "Select StockTools  from Tools  where IdTools='15'";
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
                query = $"update  Tools set StockTools ='{stock1}' where IdTools='15'";
                SqlCommand sqlCommandd = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlCommandd;
                sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                query = $"insert into Trash(NameTrash,PriceTrash) values('ЗУБИЛО SDS 14Х250Х20 ','265')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+265";
                SqlCommand sqlprice = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprice;
                sqlDataAdapter.Fill(dt);
                query = $"select  PriceUsers FROM PriceUser";
                SqlCommand sqlprices = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlprices;

                var a = sqlprices.ExecuteScalar();
                price = Convert.ToInt32(a);
                LPrice.Content = price;
            }
        }
    }
}
