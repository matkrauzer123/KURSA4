using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Логика взаимодействия для WinSverlInstrument.xaml
    /// </summary>
    public partial class WinSverlInstrument : Window
    {
        public WinSverlInstrument()
        {
            InitializeComponent();
        }
        DataBase database = new DataBase();
        static int price;

        private void B40X1000_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIKatalog_Click(object sender, RoutedEventArgs e)
        {
            WinOpen winOpen= new WinOpen();
            winOpen.ShowDialog();
            Close();
        }

        private void MIReshInstrument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIRuchInstrument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIMaliarInstrument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MISlesarInstrument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MISvarOborudovanie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIRashodMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIOsnastka_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIAbrazMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MISadInstrument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIZashita_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIOther_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            string query = $"select  PriceUser FROM PriceUsers ";
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

        private void BCheck_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
