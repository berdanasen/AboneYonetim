using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboneYonetim.Entities.ViewModel
{
    public class TAHSILAT_VIEW_MODEL
    {
        public int ObjectID { get; set; }

        public string AboneNo { get; set; }

        public string FaturaNo { get; set; }

        public DateTime TahsilatTarihi { get; set; }

        public string AdSoyad { get; set; }

        public DateTime SonOdemeTarihi { get; set; }
    }
}
