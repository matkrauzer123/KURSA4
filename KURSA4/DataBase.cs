using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCar
{
    internal class DataBase
    {
        SqlConnection sql = new SqlConnection(@"Data Source =DESKTOP-8GPA8FA;Initial Catalog=zzz; Integrated Security=True");
        public void sqlOpen()
        {
            if (sql.State == System.Data.ConnectionState.Closed)
            {
                sql.Open();
            }
        }
        public string Lg(ref string login)
        {
            string v = login;
            return v;
        }
        public void sqlClose()
        {
            if (sql.State == System.Data.ConnectionState.Open)
            {
                sql.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return sql;
        }
    }
}