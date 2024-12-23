using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SeansManager
    {
        private SeansDAL _seansDAL;

        public SeansManager()
        {
            _seansDAL = new SeansDAL();
        }

        public List<Seans> GetSeanslarByOyunID(int oyunID)
        {
            // İş kuralları burada uygulanabilir
            if (oyunID <= 0)
            {
                throw new ArgumentException("Geçersiz Oyun ID.");
            }

            return _seansDAL.GetSeanslarByOyunID(oyunID);
        }
    }
}
