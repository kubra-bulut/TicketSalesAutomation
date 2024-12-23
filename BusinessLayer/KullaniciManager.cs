using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KullaniciManager
    {
        private KullaniciDAL _kullaniciDAL;

        public KullaniciManager()
        {
            _kullaniciDAL = new KullaniciDAL();
        }

        public bool KullaniciGiris(string kullaniciAdi, string sifre)
        {
            // İş kuralları burada tanımlanabilir
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                throw new ArgumentException("Kullanıcı adı ve şifre boş bırakılamaz.");
            }

            return _kullaniciDAL.KullaniciGiris(kullaniciAdi, sifre);
        }
    }
}
