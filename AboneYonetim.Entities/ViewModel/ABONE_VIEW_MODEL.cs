using AboneYonetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboneYonetim.Entities.ViewModel
{
    public class ABONE_VIEW_MODEL
    {
        public int ObjectID { get; set; }

        public KULLANICI Abone_Kullanici { get; set; }


        public string AboneNo { get; set; }


        public ABONE_VIEW_MODEL()
        {
            Abone_Kullanici = new KULLANICI();
        }
    }
}
