using SalesOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pomelo.Data.MySql;

namespace SalesOrderAPI.Connector
{   

    public class Conn
    {
        private string connstring;
        public Conn()
        {
            connstring = @"server=xx.xxx.xxx.x;userid=xxx-xxx;password=xxx-xxx;database=xx-db; old guids=true";
        }

        public List<User> UserList()
        {
            List<User> allUser = new List<User>();

            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {
                using (MySqlCommand commandMysql = connMysql.CreateCommand())
                {
                    commandMysql.CommandText = "SELECT * FROM cases LIMIT 5";
                    commandMysql.CommandType = System.Data.CommandType.Text;


                    commandMysql.Connection = connMysql;

                    connMysql.Open();

                    using (MySqlDataReader reader = commandMysql.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allUser.Add(new User { name = reader.GetString(reader.GetOrdinal("Name")), description = reader.GetString(reader.GetOrdinal("Description")) });
                        }
                    }
                }
                connMysql.Close();
            }
             
            return allUser;
        }
    }
}


