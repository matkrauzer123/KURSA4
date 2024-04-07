using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

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
        List<Vid> items = new List<Vid>();
        static int price;
        DataBase database = new DataBase();
        DataTable dt = new DataTable();
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();
        public class Vid
        {
            public BitmapImage ImagePath { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Строительно-отделочный инструмент";
            ShowList("Строительно-отделочный инструмент");
        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter("Select IdTrash,NameTrash,PriceTrash,AmountTrash from Trash", database.GetConnection());
            database.sqlOpen();
            adapter.Fill(dt);
            dt.Columns[0].ColumnName = "ID продукта";
            dt.Columns[1].ColumnName = "Название";
            dt.Columns[2].ColumnName = "Цена";
            dt.Columns[3].ColumnName = "Количество";
            DGTrash.IsReadOnly = true;
            DGTrash.ItemsSource = dt.DefaultView;
            MIStroitOtdelInstrument.Header = "Строительно-отделочный \n инструмент";


        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {

            LLabel.Content = "Сверлильный инструмент";
            ShowList("Сверлильный инструмент");

            // Close();
            //  winSverlInstrument.ShowDialog();
        }

        private void MIRuchInstrument_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Ручной инструмент";
            ShowList("Ручной инструмент");

        }

        private void MIMaliarInstrument_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Малярный инструмент";
            ShowList("Малярный инструмент");
        }

        private void MISlesarInstrument_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Слесарный инструмент";
            ShowList("Слесарный инструмент");
        }

        private void MISvarOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Сварочное оборудование";
            ShowList("Сварочное оборудование");
        }

        private void MIRashodMaterial_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Расходные материалы";
            ShowList("Расходные материалы");
        }

        private void MIOsnastka_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Оснастка";
            ShowList("Оснастка");
        }

        private void MIAbrazMaterial_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Абразивный материал";
            ShowList("Абразивный материал");
        }

        private void MISadInstrument_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Садовый инструмент";
            ShowList("Садовый инструмент");
        }

        private void MIZashita_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Защита";
            ShowList("Защита");
        }

        private void MIOther_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Прочие инструменты";
            ShowList("Прочие инструменты");
        }

        private void MIReshInstrument_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Режущий инструмент";
            ShowList("Режущий инструмент");
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
                query = $"insert into Trash(NameTrash,PriceTrash) values('Буры SDS MAX 40X1000','8319')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;

                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+8319";
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
                query = $"insert into Trash(NameTrash,PriceTrash) values('Буры SDS MAX 40Х600','5664')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+5664";
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
                query = $"insert into Trash(NameTrash,PriceTrash) values('РУЛЕТКА VERTEXTOOLS ','471')";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                sqlDataAdapter.SelectCommand = sqlTrash;
                sqlDataAdapter.Fill(dataTable1);
                DataTable dt = new DataTable();
                query = $"update  PriceUser set PriceUsers =PriceUsers+471";
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

                    Close();
                    trash.Show();
                    break;
            }
            database.sqlClose();

        }

        private void WinOpen1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            database.sqlOpen();
            string query = $"update [End] set DateEnd ='{DateTime.Today.Date.ToShortDateString()} ' WHERE IdEnd = (SELECT MAX(IdEnd) FROM [End])";
            SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
            adapter.SelectCommand = sqlTrash;
            sqlTrash.ExecuteNonQuery();
            string del = $"Delete from Trash";
            SqlCommand sqldel = new SqlCommand(del, database.GetConnection());
            adapter.SelectCommand = sqldel;
            sqldel.ExecuteNonQuery();

          
        }

        private void TBPrice1_Копировать_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DGTrash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ShowList("Каталог");
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ShowList(string katalog)
        {
            listView1.ItemsSource = null;
            items.Clear();
            database.sqlOpen();
            string q = $"Select ImageTools,NameTools,PriceTools from Tools where CategoryTools='{katalog}'";
            SqlCommand command = new SqlCommand(q, database.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                byte[] imageData = (byte[])row["ImageTools"];

                // Преобразование массива байтов в изображение
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();

                    // Создание элемента управления Image для отображения изображения
                    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                    img.Source = image;


                    Vid vid = new Vid
                    {
                        ImagePath = image,
                        Name = (string)row["NameTools"],
                        Price = (int)row["PriceTools"]
                    };
                    items.Add(vid);


                }

            }
            listView1.ItemsSource = items;

            database.sqlClose();
        }

        private void MIKatalog_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Хиты продаж";
            ShowList("Каталог");
        }

        private void listView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void listView1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataTable dataTable = new DataTable();
            bool povtor = false;
            database.sqlOpen();
           
            var vid = (Vid)listView1.SelectedItem;
            foreach (DataRow row in dt.Rows)
            {
                // Предполагаем, что ваш элемент имеет свойство Name для сравнения
                if ((string)row["Название"] == vid.Name)
                {
                    povtor = true;
                    break; // Нашли совпадение, выходим из цикла
                }
            }
            if (povtor)
            {
                string qadd = $"update Trash set AmountTrash=AmountTrash+1 where NameTrash='{vid.Name}'";
                SqlCommand sqladd = new SqlCommand(qadd, database.GetConnection());
                adapter.SelectCommand = sqladd;
                sqladd.ExecuteNonQuery();

            }
            else
            {
                string query1 = $"insert into Trash(NameTrash,PriceTrash,AmountTrash)values('{vid.Name}',{vid.Price},1)";
                SqlCommand sqlTrash = new SqlCommand(query1, database.GetConnection());
                adapter.SelectCommand = sqlTrash;
                sqlTrash.ExecuteNonQuery();
               
            }
            price += (int)vid.Price;
            LPrice.Content = price.ToString();
            string trash = $"Select * from Trash";
            SqlCommand sqlTrash1 = new SqlCommand(trash, database.GetConnection());
            adapter.SelectCommand = sqlTrash1;
            adapter.Fill(dataTable);
            dataTable.Columns[0].ColumnName = dt.Columns[0].ColumnName;
            dataTable.Columns[1].ColumnName = dt.Columns[1].ColumnName;
            dataTable.Columns[2].ColumnName = dt.Columns[2].ColumnName;
            dataTable.Columns[3].ColumnName = dt.Columns[3].ColumnName;


            DGTrash.ItemsSource = dataTable.DefaultView;
            dt.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["ID продукта"] = row["ID продукта"];
                newRow["Название"] = row["Название"];
                newRow["Цена"] = row["Цена"];
                newRow["Количество"] = row["Количество"];

                dt.Rows.Add(newRow);
            }
            database.sqlClose();

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            database.sqlOpen();
            Button senderButton = sender as Button;
            DataRowView dataRowView = senderButton.DataContext as DataRowView;
            int id = Convert.ToInt32( dataRowView.Row["ID продукта"].ToString());
            int amount = Convert.ToInt32(dataRowView.Row["Количество"].ToString());
            string qadd = $"update Trash set AmountTrash={amount}+1 where IdTrash={id}";
            SqlCommand sqladd = new SqlCommand(qadd, database.GetConnection());
            adapter.SelectCommand = sqladd;
            sqladd.ExecuteNonQuery();
            string trash = $"Select * from Trash";
            SqlCommand sqlTrash1 = new SqlCommand(trash, database.GetConnection());
            adapter.SelectCommand = sqlTrash1;

            adapter.Fill(dataTable);
            dataTable.Columns[0].ColumnName = dt.Columns[0].ColumnName;
            dataTable.Columns[1].ColumnName = dt.Columns[1].ColumnName;
            dataTable.Columns[2].ColumnName = dt.Columns[2].ColumnName;
            dataTable.Columns[3].ColumnName = dt.Columns[3].ColumnName;

            DGTrash.ItemsSource = dataTable.DefaultView;
            dt.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["ID продукта"] = row["ID продукта"];
                newRow["Название"] = row["Название"];
                newRow["Цена"] = row["Цена"];
                newRow["Количество"] = row["Количество"];
                price += (int)newRow["Цена"];
                LPrice.Content = price;

                dt.Rows.Add(newRow);
            }
            database.sqlClose();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            Button senderButton = sender as Button;
            DataRowView dataRowView = senderButton.DataContext as DataRowView;
            int id = Convert.ToInt32(dataRowView.Row["ID продукта"].ToString());
            DataTable dataTable = new DataTable();
            bool povtor = false;
            database.sqlOpen();

           
            foreach (DataRow row in dt.Rows)
            {
                // Предполагаем, что ваш элемент имеет свойство Name для сравнения
                if ((string)row["Название"] == (string)dataRowView["Название"] && (int)row["Количество"]!=1)
                {
                    povtor = true;
                    break; // Нашли совпадение, выходим из цикла
                }
            }
            if (povtor)
            {
                string qadd = $"update Trash set AmountTrash=AmountTrash-1 where NameTrash='{dataRowView["Название"]}'";
                SqlCommand sqladd = new SqlCommand(qadd, database.GetConnection());
                adapter.SelectCommand = sqladd;
                sqladd.ExecuteNonQuery();
                price -= (int)dataRowView["Цена"];
                LPrice.Content = price;
            }
            else
            {
                string query = $"Delete from Trash where IdTrash={Convert.ToInt32(id)}";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                adapter.SelectCommand = sqlTrash;
                sqlTrash.ExecuteNonQuery();
                price -= (int)dataRowView["Цена"];
                LPrice.Content = price;

            }
            string trash = $"Select * from Trash";
            SqlCommand sqlTrash1 = new SqlCommand(trash, database.GetConnection());
            adapter.SelectCommand = sqlTrash1;
            adapter.Fill(dataTable);
            dataTable.Columns[0].ColumnName = dt.Columns[0].ColumnName;
            dataTable.Columns[1].ColumnName = dt.Columns[1].ColumnName;
            dataTable.Columns[2].ColumnName = dt.Columns[2].ColumnName;
            dataTable.Columns[3].ColumnName = dt.Columns[3].ColumnName;
            

            DGTrash.ItemsSource = dataTable.DefaultView;
            dt.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["ID продукта"] = row["ID продукта"];
                newRow["Название"] = row["Название"];
                newRow["Цена"] = row["Цена"];
                newRow["Количество"] = row["Количество"];             
                dt.Rows.Add(newRow);
            }


            database.sqlClose();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("праверка");
        }
    }
}
