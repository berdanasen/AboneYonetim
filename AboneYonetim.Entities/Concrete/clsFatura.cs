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
    public class FATURA : BaseEntity
    {
        [Display(Name = "Fatura Numarası")]
        public string FaturaNo { get; set; }
        [ForeignKey("Abone")]
        public int? AboneID { get; set; }
        public virtual ABONE Abone { get; set; }
        [Display(Name = "Fatura Ödendi Mi ")]
        public bool FaturaOdendiMi { get; set; }

        [Display(Name = "Fatura Düzenelenme  Tarihi")]
        public DateTime? FaturaDuzenlenmeTarih { get; set; }
        [Display(Name = "Fatura Son Ödeme Tarihi")]
        public DateTime? FaturaSonOdemeTarih { get; set; }

        [Display(Name = "Fatura Tutarı")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal FaturaTutari { get; set; }

        [ForeignKey("Tahsilat")]
        public int? TahsilatID { get; set; }
        public virtual TAHSILAT Tahsilat { get; set; }

        [ForeignKey("Donem")]
        public int? DonemID { get; set; }
        public virtual DONEM Donem { get; set; }
    }
}
