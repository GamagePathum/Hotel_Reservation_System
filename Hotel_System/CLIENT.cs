using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_System
{
    class CLIENT
    {
        CONNECT conn = new CONNECT();

        public bool insertClient(String fName,String lName,String phone,String country)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `clients`(`fName`, `lName`, `phone`, `country`) VALUES (@fn,@ln,@phn,@cnt)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fName;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lName;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }

        public DataTable getClients()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool editClients(int id, String fName, String lName, String phone, String country)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `clients` SET `fName`=@fn,`lName`=@ln,`phone`=@phn,`country`=@cnt WHERE `id`=@cid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fName;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lName;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }

        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "DELETE FROM `clients` WHERE `id`=@cid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
    }
}
