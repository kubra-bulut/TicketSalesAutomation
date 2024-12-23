using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static DataLayer.OyunDAL;

namespace PresentationLayer
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            // ZedGraphControl'ü Form5'e ekle
            zedGraphControl1 = new ZedGraphControl();
            zedGraphControl1.Dock = DockStyle.Fill;
            this.Controls.Add(zedGraphControl1);
            //this.Load += Form5_Load;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Listeleri burada tanımlıyoruz
            var seatData = new System.Collections.Generic.List<string>();
            var soldSeats = new System.Collections.Generic.List<int>();

            // Access veritabanı bağlantısı
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TiyatroDB.accdb";
            string query = "SELECT SeatNo, COUNT(*) AS SoldSeats FROM Sales GROUP BY SeatNo"; // SeatNo'ya göre satışları grupla

            OleDbConnection connection = new OleDbConnection(connString);
            OleDbCommand command = new OleDbCommand(query, connection);

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                // Veriyi almak için liste kullanıyoruz
                while (reader.Read())
                {
                    seatData.Add(reader["SeatNo"].ToString());
                    soldSeats.Add(Convert.ToInt32(reader["SoldSeats"]));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantısı sırasında hata oluştu: {ex.Message}");
                return;
            }
            finally
            {
                connection.Close();
            }

            // Grafik oluşturma
            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.Title.Text = "Satılan Koltuklar";
            graphPane.XAxis.Title.Text = "Koltuk Numarası";
            graphPane.YAxis.Title.Text = "Satılan Adet";

            // Veriyi grafiğe ekle
            PointPairList seatPairList = new PointPairList();
            for (int i = 0; i < seatData.Count; i++)
            {
                seatPairList.Add(i, soldSeats[i]); // X değeri olarak indeks, Y değeri olarak satılan koltuk sayısı
            }

            // Çizgi grafik ekle
            LineItem myCurve = graphPane.AddCurve("Koltuk Satışı", seatPairList, System.Drawing.Color.Blue, SymbolType.Circle);

            // Grafiği güncelle
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }

}


