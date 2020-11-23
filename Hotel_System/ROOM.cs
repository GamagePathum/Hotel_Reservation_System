using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_System
{
    class ROOM
    {
        CONNECT conn = new CONNECT();

        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms_category`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable roomByType(int type)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms` WHERE `type`=@typ", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@typ", MySqlDbType.Int32).Value = type;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool addRooms(int number,int type,String phone,String free)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `rooms`(`roomNumber`, `type`, `phone`, `free`) VALUES (@num,@tp,@phn,@fr)";       
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

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

        public DataTable getRooms()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool editRooms(int number, int type, String phone, String free)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "UPDATE `rooms` SET `type`=@tp,`phone`=@phn,`free`=@fr WHERE `roomNumber`=@num";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

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

        public bool removeRoom(int number)
        {
            MySqlCommand command = new MySqlCommand();
            String deleteQuery = "DELETE FROM `rooms` WHERE `roomNumber`=@num";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

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
