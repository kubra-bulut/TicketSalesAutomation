using BusinessLayer;
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
    public partial class Form1 : Form
    {
    
        private KullaniciManager _kullaniciManager;

        public Form1()
        {
            InitializeComponent();
           

            _kullaniciManager = new KullaniciManager();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            try
            {
                bool girisBasarili = _kullaniciManager.KullaniciGiris(kullaniciAdi, sifre);
                if (girisBasarili)
                {
                    MessageBox.Show("Giriş başarılı!");
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }
    }
}
