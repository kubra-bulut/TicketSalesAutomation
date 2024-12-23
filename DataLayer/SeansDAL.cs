using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLayer
{
    public class SeansDAL
    {
        private readonly string _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TiyatroDB.accdb;";

        public List<Seans> GetSeanslarByOyunID(int oyunID)
        {
            List<Seans> seanslar = new List<Seans>();

            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                // Veritabanı sorgusunda doğru sütunları kullanıyoruz.
                string query = "SELECT SessionID, SessionDate FROM Sessions WHERE PlayID = @PlayID";

                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@PlayID", oyunID); // Parametre adı sorgu ile eşleşiyor.

                try
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader(); // OleDbDataReader kullanılıyor.

                    while (reader.Read())
                    {
                        seanslar.Add(new Seans
                        {
                            SessionID = Convert.ToInt32(reader["SessionID"]), // SeansID sütununu alıyoruz.
                            SessionDate = Convert.ToDateTime(reader["SessionDate"]) // SeansTarihi'ni alıyoruz.
                        });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seans verileri alınırken bir hata oluştu: " + ex.Message);
                }
            }

            return seanslar;
        }
    }
    public class Seans
    {
        public int SessionID { get; set; }
        public System.DateTime SessionDate { get; set; }
    }
}
