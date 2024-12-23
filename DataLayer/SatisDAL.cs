using iText.StyledXmlParser.Jsoup.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SatisDAL
    {
        private readonly string _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TiyatroDB.accdb;";

        public bool AddSatis(Satis satis)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                string query = "INSERT INTO Sales ( UserID, PlayID, SessionID, SeatNo, Price, UserMail, SaleDate) " +
                               "VALUES ( @UserID, @PlayID, @SessionID, @SeatNo, @Price, @UserMail, @SaleDate)";

                OleDbCommand cmd = new OleDbCommand(query, conn); cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = satis.UserID;
                cmd.Parameters.Add("@PlayID", OleDbType.Integer).Value = satis.PlayID;
                cmd.Parameters.Add("@SessionID", OleDbType.Integer).Value = satis.SessionID;
                cmd.Parameters.Add("@SeatNo", OleDbType.VarChar).Value = satis.SeatNo;
                cmd.Parameters.Add("@Price", OleDbType.Currency).Value = satis.Price == 0 ? (object)DBNull.Value : (object)satis.Price;
                cmd.Parameters.Add("@UserMail", OleDbType.VarChar).Value = satis.UserMail;
                cmd.Parameters.Add("@SaleDate", OleDbType.Date).Value = satis.SaleDate;


                try
                {
                    conn.Open();
                    foreach(OleDbParameter param in cmd.Parameters)
{
                        Console.WriteLine($"Param: {param.ParameterName}, Value: {param.Value}, DbType: {param.DbType}");
                    }
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Satış verisi eklenirken bir hata oluştu: {ex.Message}");
                    Debug.WriteLine($"Hata Detayları: {ex.StackTrace}");
                    throw;
                }
            }
        }
        public List<int> GetDoluKoltuklar(int oyunID, int seansID)
        {
            List<int> doluKoltuklar = new List<int>();

            string query = "SELECT SeatNo FROM Sales WHERE PlayID = @PlayID AND SessionID = @SessionID";

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("@PlayID", oyunID);
                cmd.Parameters.AddWithValue("@SessionID", seansID);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // SeatNo'nun integer olduğunu varsayıyoruz.
                        doluKoltuklar.Add(Convert.ToInt32(reader["SeatNo"]));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Satış verisi eklenirken bir hata oluştu: {ex.Message}"); 
                    Debug.WriteLine($"Hata Detayları: {ex.StackTrace}"); 
                }
            }

            return doluKoltuklar;
        }

        public DataTable GetAllSales()
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))  // Bağlantı nesnesini oluşturuyoruz
            {
                string query = "SELECT * FROM Sales";  // Sales tablosundaki tüm verileri alıyoruz

                // Sorguyu çalıştırmak için SqlCommand oluşturuyoruz
                OleDbCommand cmd = new OleDbCommand(query, conn);

                // DataTable nesnesi oluşturuyoruz
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();  // Bağlantıyı açıyoruz

                    // SqlDataAdapter ile veriyi alıyoruz ve DataTable'a dolduruyoruz
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);

                    return dataTable;  // DataTable'ı döndürüyoruz
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Veri alınırken bir hata oluştu: {ex.Message}");
                    Debug.WriteLine($"Hata Detayları: {ex.StackTrace}");
                    throw;
                }
            }
        }

        public bool DeleteSale(int saleId)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                string query = "DELETE FROM Sales WHERE SaleID = @SaleID";  // SaleID'ye göre silme işlemi

                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.Add("@SaleID", OleDbType.Integer).Value = saleId;  // Satış ID'sini parametre olarak ekliyoruz

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();  // Sorguyu çalıştırıyoruz
                    return result > 0;  // Silme başarılıysa true döndür
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Satış silinirken bir hata oluştu: {ex.Message}");
                    Debug.WriteLine($"Hata Detayları: {ex.StackTrace}");
                    throw;
                }
            }
        }

        public bool UpdateSatis(Satis satis)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                string query = "UPDATE Sales SET SeatNo = @SeatNo, Price = @Price, UserMail = @UserMail, SaleDate = @SaleDate WHERE SaleID = @SaleID";

                OleDbCommand cmd = new OleDbCommand(query, conn);

                // Parametreler
                cmd.Parameters.Add("@SeatNo", OleDbType.VarChar).Value = satis.SeatNo;
                cmd.Parameters.Add("@Price", OleDbType.Currency).Value = satis.Price == 0 ? (object)DBNull.Value : (object)satis.Price;
                cmd.Parameters.Add("@UserMail", OleDbType.VarChar).Value = satis.UserMail;
                cmd.Parameters.Add("@SaleDate", OleDbType.Date).Value = satis.SaleDate;
                cmd.Parameters.Add("@SaleID", OleDbType.Integer).Value = satis.SaleID; // Belirli satırı güncellemek için kullanılıyor

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();  // Sorguyu çalıştırıyoruz
                    return result > 0;  // Güncelleme başarılıysa true döndür
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Satış güncellenirken bir hata oluştu: {ex.Message}");
                    Debug.WriteLine($"Hata Detayları: {ex.StackTrace}");
                    throw;
                }
            }
        }

        public Dictionary<string, int> GetSalesByPlay()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            // Veritabanından satış verilerini alalım
            // Burada "Oyun adı" -> "Satış sayısı" şeklinde bir yapı olacak
            string query = "SELECT PlayName, COUNT(*) as SalesCount FROM Sales GROUP BY PlayName";

            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[reader["PlayName"].ToString()] = Convert.ToInt32(reader["SalesCount"]);
                    }
                }
            }
            return result;
        }
    }
    public class Satis
    {
        public int SaleID { get; set; }
        public int UserID { get; set; }
        public int PlayID { get; set; }
        public int SessionID { get; set; }
        public string SeatNo { get; set; }
        public decimal Price { get; set; }
        public string UserMail { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
