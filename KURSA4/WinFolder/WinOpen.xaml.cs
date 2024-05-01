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
            public int IdTools { get; set; }
            public BitmapImage ImagePath { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Amount { get; set; } 
        }

        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {
            LLabel.Content = "Строительно-отделочный инструмент";
            ShowList("Строительно-отделочный инструмент");
        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter("Select * from Trash", database.GetConnection());
            database.sqlOpen();
            adapter.Fill(dt);
            dt.Columns[0].ColumnName = "ID продукта";
            dt.Columns[1].ColumnName = "Название";
            dt.Columns[2].ColumnName = "Цена";
            dt.Columns[3].ColumnName = "Количество";
            dt.Columns[4].ColumnName = "ID товара";
            DGTrash.IsReadOnly = true;
            DGTrash.ItemsSource = dt.DefaultView;
            MIStroitOtdelInstrument.Header = "Строительно-отделочный \n инструмент";


        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {

            LLabel.Content = "Сверлильный инструмент";
            ShowList("Сверлильный инструмент");

            
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
        private void BCheck_Click(object sender, RoutedEventArgs e)
        {
            if (Stattiki.price==0)
            {
                MessageBox.Show("Корзина пуста!!", "Проблема!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {


                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Stattiki nzakaza = new Stattiki();
                int id = nzakaza.zzz;
                string trash1 = "";

                string folderPath = System.IO.Path.Combine(desktopPath, $"Чеки");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string folder1Path = System.IO.Path.Combine(desktopPath, $@"Чеки\{DateTime.Now.ToShortDateString()} заказы");

                if (!Directory.Exists(folder1Path))
                {
                    Directory.CreateDirectory(folder1Path);
                }
                string filePath = System.IO.Path.Combine(folder1Path, $"заказ №{id}.txt");
                id++;
                nzakaza.zzz = id;
                while (File.Exists(filePath))
                {
                   
                    filePath = System.IO.Path.Combine(folder1Path, $"заказ №{id}.txt");
                    id++;
                }
               
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Записываем текст в файл
                    foreach (DataRow row in dt.Rows)
                    {

                        writer.WriteLine(row["Название"] + " - " + row["Количество"] + " шт." + " - " + row["Цена"] + "р.");
                    }
                    writer.WriteLine($"\n\n\t\t Сумма: {LPrice.Content}");
                }
                database.sqlOpen();
                try
                {
                    int a = Convert.ToInt32(LPrice.Content);
                    MessageBox.Show("Заказ обработан!!!", "Чек сделан!", MessageBoxButton.OK, MessageBoxImage.Information);
                    string query = $"UPDATE [End]SET SumEnd= SumEnd+{a}WHERE IdEnd = (SELECT MAX(IdEnd) FROM [End])";
                    SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                    adapter.SelectCommand = sqlTrash;
                    sqlTrash.ExecuteNonQuery();
                    string idtrash = $"Select MAX(IdBought) from Bought";
                    SqlCommand sqlTrash11 = new SqlCommand(idtrash, database.GetConnection());
                    adapter.SelectCommand = sqlTrash11;
                    var idbought = sqlTrash11.ExecuteScalar();
                    string idtrassh = $"Select IdEmployee from [End] WHERE IdEnd = (SELECT MAX(IdEnd) FROM [End]) ";
                    SqlCommand sqlTrash111 = new SqlCommand(idtrassh, database.GetConnection());
                    adapter.SelectCommand = sqlTrash111;
                    var t1 = sqlTrash111.ExecuteScalar();

                    if (idbought != DBNull.Value)
                    {
                        int s = (int)idbought;
                        s++;
                        trash1 = $"INSERT INTO Bought (NameBought, PriceBought, AmountBought, IdTools, NumberBought,IdEmployee) SELECT NameTrash, PriceTrash, AmountTrash, IdTools,{s},{t1} FROM trash";
                    }
                    else
                    {
                        trash1 = $"INSERT INTO Bought (NameBought, PriceBought, AmountBought, IdTools, NumberBought,IdEmployee) SELECT NameTrash, PriceTrash, AmountTrash, IdTools, 1,{t1} FROM trash";
                    }

                    SqlCommand sqlTrash2 = new SqlCommand(trash1, database.GetConnection());
                    adapter.SelectCommand = sqlTrash2;
                    sqlTrash2.ExecuteNonQuery();
                    string del = $"Delete from Trash";
                    SqlCommand sqldel = new SqlCommand(del, database.GetConnection());
                    adapter.SelectCommand = sqldel;
                    sqldel.ExecuteNonQuery();
                    string trash = $"Select * from Trash";
                    SqlCommand sqlTrash1 = new SqlCommand(trash, database.GetConnection());
                    adapter.SelectCommand = sqlTrash1;

                    LPrice.Content = "0";
                    Stattiki.price = 0;
                    dataTable.Columns.Clear();
                    adapter.Fill(dataTable);
                    dataTable.Columns[0].ColumnName = dt.Columns[0].ColumnName;
                    dataTable.Columns[1].ColumnName = dt.Columns[1].ColumnName;
                    dataTable.Columns[2].ColumnName = dt.Columns[2].ColumnName;
                    dataTable.Columns[3].ColumnName = dt.Columns[3].ColumnName;
                    dataTable.Columns[4].ColumnName = dt.Columns[4].ColumnName;


                    DGTrash.ItemsSource = dataTable.DefaultView;
                
                    dt.Rows.Clear();
                    database.sqlClose();
                }
                catch (Exception)
                {

                    MessageBox.Show("Корзина пуста!!", "Проблема!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
           

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

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ShowList();
        }     
        private void ShowList(string katalog)
        {
            listView1.ItemsSource = null;
            items.Clear();
            database.sqlOpen();
            string q = $"Select IdTools, ImageTools,NameTools,PriceTools, AmountTools from Tools where CategoryTools='{katalog}'";
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
                        IdTools = Convert.ToInt32(row["IdTools"]),
                        ImagePath = image,
                        Name = row["NameTools"].ToString(),
                        Price = Convert.ToInt32(row["PriceTools"]),
                        Amount = Convert.ToInt32(row["AmountTools"])

                    };
                    items.Add(vid);


                }

            }
            listView1.ItemsSource = items;

            database.sqlClose();
        }
        private void ShowList()
        {
            listView1.ItemsSource = null;
            items.Clear();
            database.sqlOpen();
            string q = $"Select  IdTools,ImageTools,NameTools,PriceTools, AmountTools from Tools ";
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
                        IdTools = Convert.ToInt32(row["IdTools"]),
                        ImagePath = image,
                        Name = row["NameTools"].ToString(),
                        Price = Convert.ToInt32(row["PriceTools"]),
                        Amount = Convert.ToInt32(row["AmountTools"])
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
            ShowList();
        }

        private void listView1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            DataTable dataTable = new DataTable();
            bool povtor = false;       
            var vid = (Vid)listView1.SelectedItem;
            database.sqlOpen();
            if (vid == null)
            {

            }
            else
            {
                string query22 = $"select AmountTools from Tools where NameTools='{vid.Name}'";
                SqlCommand sqlTrashss = new SqlCommand(query22, database.GetConnection());
                adapter.SelectCommand = sqlTrashss;
                var ss = (int)sqlTrashss.ExecuteScalar();
                if (ss == 0)
                {
                    MessageBox.Show("Ошибка","Товара нет в наличии!!",MessageBoxButton.OK, MessageBoxImage.Error);  
                }
                else
                {


                    string query2 = $"select IdTools from Tools where NameTools='{vid.Name}'";
                    SqlCommand sqlTrashs = new SqlCommand(query2, database.GetConnection());
                    adapter.SelectCommand = sqlTrashs;
                    var s = (int)sqlTrashs.ExecuteScalar();
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
                        string query1 = $"insert into Trash(NameTrash,PriceTrash,AmountTrash,IdTools)values('{vid.Name}',{vid.Price},1,{s})";
                        SqlCommand sqlTrash = new SqlCommand(query1, database.GetConnection());
                        adapter.SelectCommand = sqlTrash;
                        sqlTrash.ExecuteNonQuery();

                    }
                    string qaddd = $"update Tools set AmountTools=AmountTools-1 where NameTools='{vid.Name}'";
                    SqlCommand sqladdd = new SqlCommand(qaddd, database.GetConnection());
                    adapter.SelectCommand = sqladdd;
                    sqladdd.ExecuteNonQuery();
                    vid.Amount--;
                   listView1.SelectedItem = vid;
                    
                     
                    Stattiki.price += (int)vid.Price;
                    LPrice.Content = Stattiki.price.ToString();
                    string trash = $"Select * from Trash";
                    SqlCommand sqlTrash1 = new SqlCommand(trash, database.GetConnection());
                    adapter.SelectCommand = sqlTrash1;
                    adapter.Fill(dataTable);
                    dataTable.Columns[0].ColumnName = dt.Columns[0].ColumnName;
                    dataTable.Columns[1].ColumnName = dt.Columns[1].ColumnName;
                    dataTable.Columns[2].ColumnName = dt.Columns[2].ColumnName;
                    dataTable.Columns[3].ColumnName = dt.Columns[3].ColumnName;
                    dataTable.Columns[4].ColumnName = dt.Columns[4].ColumnName;


                    DGTrash.ItemsSource = dataTable.DefaultView;
                    dt.Rows.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["ID продукта"] = row["ID продукта"];
                        newRow["Название"] = row["Название"];
                        newRow["Цена"] = row["Цена"];
                        newRow["Количество"] = row["Количество"];
                        newRow["ID товара"] = row["ID товара"];

                        dt.Rows.Add(newRow);
                    }
                    database.sqlClose();
                    ShowList();
                }
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            database.sqlOpen();
            Button senderButton = sender as Button;
            DataRowView dataRowView = senderButton.DataContext as DataRowView;
            price += (int)dataRowView["Цена"];
            LPrice.Content = price;
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
            dataTable.Columns[4].ColumnName = dt.Columns[4].ColumnName;

            DGTrash.ItemsSource = dataTable.DefaultView;
            dt.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["ID продукта"] = row["ID продукта"];
                newRow["Название"] = row["Название"];
                newRow["Цена"] = row["Цена"];
                newRow["Количество"] = row["Количество"];
                newRow["ID товара"] = row["ID товара"];


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
                Stattiki.price -= (int)dataRowView["Цена"];
                LPrice.Content = Stattiki.price;
            }
            else
            {
                string query = $"Delete from Trash where IdTrash={Convert.ToInt32(id)}";
                SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
                adapter.SelectCommand = sqlTrash;
                sqlTrash.ExecuteNonQuery();
                Stattiki.price -= (int)dataRowView["Цена"];
                LPrice.Content = Stattiki.price;

            }
            string trash = $"Select * from Trash";
            SqlCommand sqlTrash1 = new SqlCommand(trash, database.GetConnection());
            adapter.SelectCommand = sqlTrash1;
            adapter.Fill(dataTable);
            dataTable.Columns[0].ColumnName = dt.Columns[0].ColumnName;
            dataTable.Columns[1].ColumnName = dt.Columns[1].ColumnName;
            dataTable.Columns[2].ColumnName = dt.Columns[2].ColumnName;
            dataTable.Columns[3].ColumnName = dt.Columns[3].ColumnName;
            dataTable.Columns[4].ColumnName = dt.Columns[4].ColumnName;


            DGTrash.ItemsSource = dataTable.DefaultView;
            dt.Rows.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["ID продукта"] = row["ID продукта"];
                newRow["Название"] = row["Название"];
                newRow["Цена"] = row["Цена"];
                newRow["Количество"] = row["Количество"];
                newRow["ID товара"] = row["ID товара"];
                dt.Rows.Add(newRow);
            }


            database.sqlClose();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();      
            string queryy = $"update [End] set DateEnd ='{DateTime.Today.Date.ToShortDateString()} ' WHERE IdEnd = (SELECT MAX(IdEnd) FROM [End])";
            SqlCommand sqlTrashh = new SqlCommand(queryy, database.GetConnection());
            adapter.SelectCommand = sqlTrashh;
            sqlTrashh.ExecuteNonQuery();
            string del = $"Delete from Trash";
            SqlCommand sqldel = new SqlCommand(del, database.GetConnection());
            adapter.SelectCommand = sqldel;
            sqldel.ExecuteNonQuery();
            Stattiki.price = 0;
            LPrice.Content = Stattiki.price;
            string query = $"Delete from Trash";
            DGTrash.ItemsSource = null;
            SqlCommand sqlTrash = new SqlCommand(query, database.GetConnection());
            adapter.SelectCommand = sqlTrash;
            sqlTrash.ExecuteNonQuery();
            adapter = new SqlDataAdapter("Select IdTrash,NameTrash,PriceTrash,AmountTrash,IdTools from Trash", database.GetConnection());
            database.sqlOpen();
            dt.Columns.Clear();
            dt.Rows.Clear();
            adapter.Fill(dt);
            dt.Columns[0].ColumnName = "ID продукта";
            dt.Columns[1].ColumnName = "Название";
            dt.Columns[2].ColumnName = "Цена";
            dt.Columns[3].ColumnName = "Количество";
            dt.Columns[4].ColumnName = "ID товара";
            DGTrash.IsReadOnly = true;
            DGTrash.ItemsSource = dt.DefaultView;          
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            
            database.sqlClose();
        }

        private void DGTrash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BTrash_Click(object sender, RoutedEventArgs e)
        {
            if (Stattiki.price == 0)
            {
                MessageBox.Show("Проблема", "Корзина пуста", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                dt.Columns.Clear();

                dt.Rows.Clear();

               
                WinTrash winTrash = new WinTrash();
                winTrash.ShowDialog();
               
            }
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView1.ItemsSource = null;
            items.Clear();
            database.sqlOpen();
            string qadd = $"select IdTools, ImageTools,NameTools,PriceTools, AmountTools from Tools where NameTools like '%{TBSearch.Text}%'";
            SqlCommand command = new SqlCommand(qadd, database.GetConnection());
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
                        IdTools = Convert.ToInt32( row["IdTools"]),
                        ImagePath = image,
                        Name = row["NameTools"].ToString(),
                        Price = Convert.ToInt32( row["PriceTools"]),
                        Amount= Convert.ToInt32(row["AmountTools"])
                    };
                    items.Add(vid);


                }

            }
            listView1.ItemsSource = items;

            database.sqlClose();
        }

        private void TBSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TBSearch.Text = null;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            database.sqlOpen();
            // Получить выбранный элемент
            var selectedItem = (Vid)listView1.SelectedItem;

            string queryy = $"Select InfoTools  from Tools Where NameTools ='{selectedItem.Name}'";
            SqlCommand sqlTrashh = new SqlCommand(queryy, database.GetConnection());
            adapter.SelectCommand = sqlTrashh;
            var info = sqlTrashh.ExecuteScalar();
            MessageBox.Show($"{info}", "Информация!", MessageBoxButton.OK,MessageBoxImage.Information);
            // Присвоить переменным значения строк
            string name = selectedItem.Name;
           
            database.sqlClose();
            // Выполнить необходимые действия с этими переменными
        }

    }
}
