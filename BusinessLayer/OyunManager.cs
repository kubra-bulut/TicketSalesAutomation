using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.OyunDAL;

namespace BusinessLayer
{
    public class OyunManager
    {
        private OyunDAL _oyunDAL;

        public OyunManager()
        {
            _oyunDAL = new OyunDAL();
        }

        public List<OyunDAL.Oyun> GetAllOyunlar()
        {
            // İş kuralları burada uygulanabilir
            return _oyunDAL.GetAllOyunlar();
        }

      
    }
}
