using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace SQLTest.util {
    public class MySQLConnectUtil {
        private MySQLConnectUtil() { }

        public static MySqlConnection GetConnection(string database, string user = "root", string password = "",
            string server = "127.0.0.1", string port = "3306") {
            string connectConfig = $"server={server};port={port};database={database};user={user};password={password}";
            return new MySqlConnection(connectConfig);
        }

        public static void CloseConnection(MySqlConnection conn) {
            try {
                if (conn != null) {
                    conn.Close();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}