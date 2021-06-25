using System;
using System.Data.SqlClient;
using System.Configuration;

namespace GetCountryInfo
{

    class DataBase
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        static SqlConnection connection = new SqlConnection(connectionString);
        public static void OpenConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
        }
        public static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
        }
        public static SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
