using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace digits
{
    public static class DataBase
    {
        static string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
        static string path = Path.GetDirectoryName(location);
        static SqlConnection sqlCon = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Курсовые\\Digits\\digits\\bin\\Debug\\DataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public static void OpenConnection()
        {
            if (sqlCon.State == System.Data.ConnectionState.Closed)
                sqlCon.Open();
        }
        public static void CloseConnection()
        {
            if (sqlCon.State == System.Data.ConnectionState.Open)
                sqlCon.Close();
        }
        public static SqlConnection GetConnection() => sqlCon;

        public static string ReturnRequest(string q)
        {
            string s;
            OpenConnection();
            try
            {
                SqlCommand command = new SqlCommand(q, GetConnection());
                s = command.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

                s = "";
            }
            CloseConnection();
            return s;
        }
    }
}
