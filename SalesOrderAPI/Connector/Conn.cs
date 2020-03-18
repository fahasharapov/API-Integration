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
                    commandMysql.CommandText = "SELECT so.date_entered as date, so.id AS order_id, so.name AS customer_po, ocs.type_c AS TYPE,  ac.name AS 'name', ocs.note_c AS note, ocs.shipping_method_c AS shipping_method, ocs.shipping_carrier_c AS shipping_carrier, ac.shipping_address_street AS street, ac.shipping_address_city AS city, ac.shipping_address_state AS state, ac.shipping_address_postalcode AS zip_code, accs.country_code_c AS country, ac.phone_office AS phone FROM sm_salesorder so INNER JOIN sm_salesorder_cstm ocs ON ocs.id_c = so.id INNER JOIN accounts ac ON ac.id = account_id_c INNER JOIN accounts_cstm accs ON accs.id_c = ac.id LIMIT 5";
                    commandMysql.CommandType = System.Data.CommandType.Text;


                    commandMysql.Connection = connMysql;

                    connMysql.Open();

                    using (MySqlDataReader reader = commandMysql.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allUser.Add(new User {
                                date = reader.GetString(reader.GetOrdinal("date")),
                                order_id = reader.GetString(reader.GetOrdinal("order_id")),
                                customer_po = reader.GetString(reader.GetOrdinal("customer_po")),
                                TYPE = reader.GetString(reader.GetOrdinal("Type")),
                                name = reader.GetString(reader.GetOrdinal("Name")),
                                note = reader.GetString(reader.GetOrdinal("Note")),
                                shipping_method = reader.GetString(reader.GetOrdinal("shipping_method")),
                                shipping_carrier = reader.GetString(reader.GetOrdinal("shipping_carrier")),
                                street = reader.GetString(reader.GetOrdinal("Street")),
                                city = reader.GetString(reader.GetOrdinal("City")),
                                state = reader.GetString(reader.GetOrdinal("State")),
                                zip_code = reader.GetString(reader.GetOrdinal("zip_code")),
                                country = reader.GetString(reader.GetOrdinal("Country")),
                                phone = reader.GetString(reader.GetOrdinal("Phone"))
                            });
                        }
                    }
                }
                connMysql.Close();
            }
             
            return allUser;
        }
    }
}


