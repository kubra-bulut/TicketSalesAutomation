using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SatisManager
    {
        private SatisDAL _satisDAL;
        private string _connectionString= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TiyatroDB.accdb";

        public SatisManager()
        {
            _satisDAL = new SatisDAL();
        }
        public List<int> GetDoluKoltuklar(int oyunID, int seansID)
        {
            return _satisDAL.GetDoluKoltuklar(oyunID, seansID);
        }
        public bool AddSatis(Satis satis)
        {
            // İş kuralları
            if (string.IsNullOrEmpty(satis.SeatNo) || satis.Price <= 0)
            {
                throw new ArgumentException("Geçersiz satış bilgisi.");
            }

            if (!satis.UserMail.Contains("@"))
            {
                throw new ArgumentException("Geçersiz e-posta adresi.");
            }


            return _satisDAL.AddSatis(satis);
        }
        public bool AddSatisAndNotify(Satis satis)
        {
            try
            {
                // Satışı ekleyin
                bool isAdded = _satisDAL.AddSatis(satis);

                if (isAdded)
                {
                    // Satış başarılıysa PDF oluştur
                    PDFHelper.CreatePDF(satis);

                    // Satış bilgileri ile e-posta gönder
                    MailHelper.SendMail(satis.UserMail, "Bilet Satışı Başarılı", $"Merhaba, bilet satışınız başarıyla tamamlandı.\nTarih: {satis.SaleDate}");

                    Console.WriteLine("Satış ve bildirim başarılı.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Satış işlemi başarısız.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Satış işlemi sırasında hata oluştu: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllSales()
        {
            return _satisDAL.GetAllSales();  // Veritabanındaki tüm satışları alıyoruz
        }
        public bool DeleteSale(int saleId)
        {
            return _satisDAL.DeleteSale(saleId);  // Veritabanından satış siliniyor
        }
        public bool UpdateSatis(Satis satis)
        {
            if (string.IsNullOrEmpty(satis.SeatNo) || satis.Price <= 0)
            {
                throw new ArgumentException("Geçersiz satış bilgisi.");
            }

            if (!satis.UserMail.Contains("@"))
            {
                throw new ArgumentException("Geçersiz e-posta adresi.");
            }

            try
            {
                // SatisDAL sınıfındaki UpdateSatis fonksiyonunu çağırıyoruz
                return _satisDAL.UpdateSatis(satis);
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapılabilir
                Console.WriteLine($"Satış güncellenirken bir hata oluştu: {ex.Message}");
                return false;
            }
        }

        public Dictionary<string, int> GetSalesByPlay(int oyunID)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            string query = "SELECT PlayName, COUNT(*) as SalesCount FROM Sales WHERE PlayID = @PlayID GROUP BY PlayName";

            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@PlayID", oyunID); // Oyun ID'si filtreleme için ekleniyor
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
}