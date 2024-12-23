using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static DataLayer.OyunDAL;

namespace PresentationLayer
{
    public partial class Form2 : Form
    {
        private OyunManager _oyunManager;
        private SeansManager _seansManager;

        public Form2()
        {
            InitializeComponent();
            _oyunManager = new OyunManager();
            _seansManager = new SeansManager();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Oyunları ComboBox'a yükle
            var oyunlar = _oyunManager.GetAllOyunlar();  // Veritabanından oyunları al

            cmbOyunlar.DataSource = oyunlar;
            cmbOyunlar.DisplayMember = "PlayName";  // Görünen isim
            cmbOyunlar.ValueMember = "PlayID";     // Oyun ID'si, arka planda tutulacak

            // Seansları yükleme (başlangıçta boş olabilir veya oyun seçildiğinde dolacak)
            cmbSeanslar.DataSource = new List<string>(); // Seanslar boş başlasın
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.LightBlue, Color.White, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }


        // Oyun değiştikçe Seansları yükle
        private void cmbOyunlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOyunlar.SelectedItem != null)
            {
                // Seçilen oyun ID'sini alıyoruz
                Oyun selectedOyun = (Oyun)cmbOyunlar.SelectedItem;
                int oyunId = selectedOyun.PlayID;

                // Seansları yüklemek için LoadSeanslar fonksiyonunu çağırıyoruz
                LoadSeanslar(oyunId);
            }
           
        }
    

        // Seansları ComboBox'a yükle
        private void LoadSeanslar(int oyunId)
        {
            List<Seans> seanslar = _seansManager.GetSeanslarByOyunID(oyunId);
            cmbSeanslar.DataSource = seanslar;
            cmbSeanslar.DisplayMember = "SessionDate";   // Seansın saati gibi bir özelliği gösterin

            // Seans ID'sini arka planda tutun
            cmbSeanslar.ValueMember = "SessionID";     // Seans ID'si arka planda tutulacak// Seans ID'si arka planda tutulacak
        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            if (cmbOyunlar.SelectedItem != null && cmbSeanslar.SelectedItem != null)
            {
                // Nesneye erişim
                Oyun secilenOyun = cmbOyunlar.SelectedItem as Oyun;
                Seans secilenSeans = cmbSeanslar.SelectedItem as Seans;

                if (secilenOyun != null && secilenSeans != null)
                {
                    int secilenOyunID = secilenOyun.PlayID;
                    int secilenSeansID = secilenSeans.SessionID;

                    // Form3'ü aç
                    Form3 form3 = new Form3(secilenOyunID, secilenSeansID);
                    form3.Show();  // Form3'ü göster
                    this.Hide();  // Form2'yi gizle
                }
                else
                {
                    MessageBox.Show("Geçersiz oyun veya seans seçimi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir oyun ve seans seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbSeanslar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
