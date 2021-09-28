using AboneYonetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboneYonetim.Entities.ViewModel
{
    public class FATURA_VIEW_MODEL
    {
        public int ObjectID { get; set; }

        public string FaturaNo { get; set; }

        public int AboneId { get; set; }

        public string FaturaDonemi { get; set; }

        public DateTime FaturaTarihi { get; set; }

        public DateTime SonOdemeTarihi { get; set; }

        public bool Odendi { get; set; }

        public decimal Tutar { get; set; }
    }
}
