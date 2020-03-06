using System;
using MySql.Data.MySqlClient;
using SQLTest.domain;
using SQLTest.util;

namespace SQLTest.dao.impl {
    public class IUserDAOImpl : IUserDAO {
        public bool Register(Users users) {
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;
            try {
                conn = MySQLConnectUtil.GetConnection("nettest");
                conn.Open();
                transaction = conn.BeginTransaction();
                string sql =
                    $"insert into t_users (username, password) values ('{users.Username}','{MD5Util.GetSaltMD5(users.Password)}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int effectNum = cmd.ExecuteNonQuery();
                if (effectNum != 1) {
                    transaction.Rollback();
                    return false;
                }
                else {
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception e) {
                if (transaction != null) {
                    transaction.Rollback();
                }

                Console.WriteLine(e);
                return false;
            }
            finally {
                MySQLConnectUtil.CloseConnection(conn);
            }
        }

        public bool Verify(Users users) {
            MySqlConnection conn = null;
            MySqlDataReader reader = null;
            try {
                conn = MySQLConnectUtil.GetConnection("nettest");
                conn.Open();
                string sql = $"select * from t_users where username = '{users.Username}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    string password = reader.GetString("password");
                    if (MD5Util.VerifyPassword(users.Password, password)) {
                        users.Id = long.Parse(reader.GetString("id"));
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
            finally {
                MySQLConnectUtil.CloseConnection(conn, reader);
            }
        }
    }
}