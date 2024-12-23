using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLayer
{
    public class OyunDAL
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TiyatroDB.accdb";

        public class Oyun
        {
            public int PlayID { get; set; }
            public string PlayName { get; set; }
        }

        public List<Oyun> GetAllOyunlar()
        {
            List<Oyun> oyunlar = new List<Oyun>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT PlayID, PlayName FROM Plays";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Oyun oyun = new Oyun
                    {
                        PlayID = Convert.ToInt32(reader["PlayID"]),
                        PlayName = reader["PlayName"].ToString()
                    };
                    oyunlar.Add(oyun);
                }
            }

            return oyunlar;
        }

        public List<string> GetSeanslarByOyunId(int oyunId)
        {
            List<string> seanslar = new List<string>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT SessionDate FROM Sessions WHERE PlayID = @PlayID";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@PlayID", oyunId);
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    seanslar.Add(reader["SessionDate"].ToString());
                }
            }

            return seanslar;
        }
    }
}
