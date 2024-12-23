using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form3 : Form
    {
        private SatisManager _satisManager;
        private int _oyunID;
        private int _seansID;
        private Dictionary<int, decimal> koltukFiyatlari; // Koltuk başına fiyatlar
        private List<int> secilenKoltuklar = new List<int>(); // Seçilen koltuklar

        public Form3(int oyunID, int seansID)
        {
            InitializeComponent();
            _satisManager = new SatisManager();
            _oyunID = oyunID;
            _seansID = seansID;
            koltukFiyatlari = new Dictionary<int, decimal>();
            LoadKoltuklar();
        }

        private void LoadKoltuklar()
        {
            // Veritabanından dolu koltukları al
            var doluKoltuklar = _satisManager.GetDoluKoltuklar(_oyunID, _seansID);

            for (int i = 1; i <= 50; i++)
            {
                Button koltuk = new Button
                {
                    Text = i.ToString(),
                    Width = 50,
                    Height = 50,
                    BackColor = doluKoltuklar.Contains(i) ? Color.Red : Color.Green,
                    Enabled = !doluKoltuklar.Contains(i),
                    Tag = i
                };

                // Dinamik fiyat (örnek olarak 50-70 arasında değişken)
                decimal fiyat = 50 + (i % 10) * 2;
                koltukFiyatlari[i] = fiyat;

                koltuk.Click += Koltuk_Click;
                flowLayoutPanel1.Controls.Add(koltuk);
            }
        }

        private void Koltuk_Click(object sender, EventArgs e)
        {
            Button secilenKoltuk = sender as Button;
            int koltukNo = (int)secilenKoltuk.Tag;

            if (secilenKoltuk.BackColor == Color.Green)
            {
                secilenKoltuk.BackColor = Color.Yellow;
                secilenKoltuklar.Add(koltukNo);
            }
            else if (secilenKoltuk.BackColor == Color.Yellow)
            {
                secilenKoltuk.BackColor = Color.Green;
                secilenKoltuklar.Remove(koltukNo);
            }

            UpdateSelectedSeatsLabel();
        }
        private void UpdateSelectedSeatsLabel()
        {
            lblSecilenKoltuk.Text = secilenKoltuklar.Count > 0
                ? $"Seçilen Koltuklar: {string.Join(", ", secilenKoltuklar)}"
                : "Seçilen Koltuklar: Yok";

            decimal toplamFiyat = secilenKoltuklar.Sum(k => koltukFiyatlari[k]);
            lblFiyat.Text = $"Fiyat: {toplamFiyat:C}";
        }
        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            if (secilenKoltuklar.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir koltuk seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string musteriMail = txtMusteriMail.Text.Trim();
            if (string.IsNullOrEmpty(musteriMail) || !musteriMail.Contains("@"))
            {
                MessageBox.Show("Geçerli bir e-posta adresi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
                foreach (var koltukNo in secilenKoltuklar)
                {
                    Satis satis = new Satis
                    {
                        UserID = 1, // Sabit kullanıcı
                        PlayID = _oyunID,
                        SessionID = _seansID,
                        SeatNo = koltukNo.ToString(),
                        Price = koltukFiyatlari[koltukNo],
                        UserMail = musteriMail,
                        SaleDate = DateTime.Now
                    };

                    bool basarili = _satisManager.AddSatis(satis);
                    if (!basarili)
                    {
                        MessageBox.Show($"Koltuk {koltukNo} için satış yapılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                   
                    // PDF oluşturma
                    PDFHelper.CreatePDF(satis);

                    MessageBox.Show("Satış başarıyla yapıldı ve PDF kaydedildi.");

                    // Mail gönderme
                    string subject = "Tiyatro Bilet Satış Bilgileri";
                    string body = $"Sayın müşterimiz,\n\nTiyatro biletinizin bilgileri aşağıda yer almaktadır.\n\nOyun ID: {satis.PlayID}\nSeans ID: {satis.SessionID}\nKoltuk No: {satis.SeatNo}\nFiyat: {satis.Price:C}\n\nBizi tercih ettiğiniz için teşekkür ederiz!";
                    MailHelper.SendMail(musteriMail, subject, body);
                }

                MessageBox.Show("Satış başarıyla tamamlandı ve e-posta gönderildi!");
                Close();
            }
           
        

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(); 
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ZedGraph butonuna tıklandığında yeni formu açıyoruz
            Form5 zedGraphForm = new Form5();  // ZedGraph'ı gösterecek yeni form
            zedGraphForm.ShowDialog();
        }
    }
}
