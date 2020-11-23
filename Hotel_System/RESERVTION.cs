using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_System
{
    class RESERVTION
    {
        CONNECT conn = new CONNECT();

        public DataTable getAllReserve()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `reservations`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool addReservation(int number,int clientId,DateTime dateIn,DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `reservations`(`roomNumber`, `clientId`, `dateIn`, `dateOut`) VALUES (@num,@cid,@din,@dout)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;

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

        public bool editReservation(int reserveId, int number, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `reservations` SET `roomNumber`=@num,`clientId`=@cid,`dateIn`=@din,`dateOut`=@dout WHERE `reserveId`=@rid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@rid", MySqlDbType.Int32).Value = reserveId;
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;

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

        public bool removeReservation(int reserveId)
        {
            MySqlCommand command = new MySqlCommand();
            String deleteQuery = "DELETE FROM `reservations` WHERE `reserveId`=@rid";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@rid", MySqlDbType.Int32).Value = reserveId;

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
