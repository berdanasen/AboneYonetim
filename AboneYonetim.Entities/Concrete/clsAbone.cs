using AboneYonetim.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboneYonetim.Entities.Concrete
{
    public class ABONE : BaseEntity
    {
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string TelefonNo { get; set; }
        [Display(Name = "E Posta")]
        public string Eposta { get; set; }
        [Display(Name = "TC Kimlik No")]
        public string TcKimlikNO { get; set; }
        [Display(Name = "Abone No")]
        public string AboneNo { get; set; }

        [ForeignKey("Kullanici")]
        public int KulID { get; set; }
        public virtual KULLANICI Kullanici { get; set; }

        //public virtual List<FATURA> lstFaturalar { get; set; } = new List<FATURA>();
        //public virtual List<TAHSILAT> lstTahsilatlar { get; set; }
    }
}
