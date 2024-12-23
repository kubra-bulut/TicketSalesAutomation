using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form4 : Form
    {
        SatisManager _satisManager = new SatisManager();
        public Form4()
        {
            InitializeComponent();
             
            LoadData();
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            // SaleManager'dan satış verilerini alıyoruz
            var salesData = _satisManager.GetAllSales();
            dataGridView1.DataSource = salesData;  // DataGridView'e bağlıyoruz
        }
        private void LoadData()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TiyatroDB.accdb;";
            string query = "SELECT * FROM Sales";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private Satis GetSelectedSatisFromGrid()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0]; // İlk seçilen satırı al
                return new Satis
                {
                    SaleID = Convert.ToInt32(row.Cells["SaleID"].Value),
                    SeatNo = row.Cells["SeatNo"].Value.ToString(),
                    Price = Convert.ToDecimal(row.Cells["Price"].Value),
                    UserMail = row.Cells["UserMail"].Value.ToString(),
                    SaleDate = Convert.ToDateTime(row.Cells["SaleDate"].Value)
                };
            }
            else
            {
                throw new Exception("Lütfen bir satır seçin.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Geçerli bir satır seçildiyse
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Seçilen satırdaki değerleri TextBox'lara aktaralım,
                txtSeatNo.Text = selectedRow.Cells["SeatNo"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["Price"].Value.ToString();
                txtUserMail.Text = selectedRow.Cells["UserMail"].Value.ToString();
                dtpSaleDate.Text = selectedRow.Cells["SaleDate"].Value.ToString();
            }
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            // Seçilen satırın SaleID'sini alıyoruz
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedSaleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SaleID"].Value);

                // SatisManager'dan silme işlemi yapıyoruz
                SatisManager satisManager = new SatisManager();
                bool isDeleted = satisManager.DeleteSale(selectedSaleID);

                if (isDeleted)
                {
                    MessageBox.Show("Satış başarıyla silindi.");
                    LoadData();  // Veritabanındaki değişiklikleri yansıtmak için DataGridView'i tekrar yükle
                }
                else
                {
                    MessageBox.Show("Satış silinirken bir hata oluştu.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen satırdan Satis nesnesini oluştur
                Satis satis = GetSelectedSatisFromGrid();

                // Gerekli güncellemeleri kullanıcıdan alabilirsiniz
                satis.SeatNo = txtSeatNo.Text;
                satis.Price = Convert.ToDecimal(txtPrice.Text);
                satis.UserMail = txtUserMail.Text;
                satis.SaleDate = dtpSaleDate.Value; // DateTimePicker kullanımı

                // Güncelleme işlemini gerçekleştir
                SatisManager satisManager = new SatisManager();
                bool isUpdated = satisManager.UpdateSatis(satis);

                if (isUpdated)
                {
                    MessageBox.Show("Satış başarıyla güncellendi.");
                    LoadData(); // DataGridView'i yeniler
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız oldu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
