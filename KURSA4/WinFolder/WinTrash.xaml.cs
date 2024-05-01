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
    /// Логика взаимодействия для WinTrash.xaml
    /// </summary>
    public partial class WinTrash : Window
    {
        public WinTrash()
        {
            InitializeComponent();
        }
        DataBase database = new DataBase();
        DataTable dt = new DataTable();
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();

        private void DGTrash_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            dt.Columns[4].ColumnName = "ID";
            DGTrash.IsReadOnly = true;
            DGTrash.ItemsSource = dt.DefaultView;

            LPrice.Content = Stattiki.price;

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
                if ((string)row["Название"] == (string)dataRowView["Название"] && (int)row["Количество"] != 1)
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
            string qaddd = $"update Tools set AmountTools=AmountTools+1 where NameTools='{dataRowView.Row["Название"]}'";
            SqlCommand sqladdd = new SqlCommand(qaddd, database.GetConnection());
            adapter.SelectCommand = sqladdd;
            sqladdd.ExecuteNonQuery();

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
                newRow["ID"] = row["ID"];
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
            string query22 = $"select AmountTools from Tools where NameTools='{dataRowView.Row["Название"]}'";
            SqlCommand sqlTrashss = new SqlCommand(query22, database.GetConnection());
            adapter.SelectCommand = sqlTrashss;
            var ss = (int)sqlTrashss.ExecuteScalar();
            if (ss == 0)
            {
                MessageBox.Show("Ошибка", "Товара нет в наличии!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {


                Stattiki.price += (int)dataRowView["Цена"];
                LPrice.Content = Stattiki.price;
                int id = Convert.ToInt32(dataRowView.Row["ID продукта"].ToString());
                int amount = Convert.ToInt32(dataRowView.Row["Количество"].ToString());
                string qadd = $"update Trash set AmountTrash={amount}+1 where IdTrash={id}";
                SqlCommand sqladd = new SqlCommand(qadd, database.GetConnection());
                adapter.SelectCommand = sqladd;
                sqladd.ExecuteNonQuery();
                string qaddd = $"update Tools set AmountTools=AmountTools-1 where NameTools='{dataRowView.Row["Название"]}'";
                SqlCommand sqladdd = new SqlCommand(qaddd, database.GetConnection());
                adapter.SelectCommand = sqladdd;
                sqladdd.ExecuteNonQuery();
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
                    newRow["ID"] = row["ID"];


                    dt.Rows.Add(newRow);
                }
                database.sqlClose();
            }
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
          
           
            Close();
            
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            Stattiki.price = 0;
            string trash = $"Delete from Trash";
            SqlCommand sqlTrash1 = new SqlCommand(trash, database.GetConnection());
            adapter.SelectCommand = sqlTrash1;
            sqlTrash1.ExecuteNonQuery();
            string trash1 = $"Select * from Trash";
            SqlCommand sqlTrash11 = new SqlCommand(trash1, database.GetConnection());
            adapter.SelectCommand = sqlTrash11;
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
                newRow["ID"] = row["ID"];


                dt.Rows.Add(newRow);
            }
            database.sqlClose();
        

    }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
          
        }
    }
}
