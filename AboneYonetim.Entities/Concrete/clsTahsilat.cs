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
    public class TAHSILAT : BaseEntity
    {
        [ForeignKey("Abone")]
        public int AboneID { get; set; }
        public virtual ABONE Abone { get; set; }

        [ForeignKey("Fatura")]
        public int FaturaID { get; set; }
        public virtual FATURA Fatura { get; set; }

        [ForeignKey("Donem")]
        public int? DonemID { get; set; }
        public virtual DONEM Donem { get; set; }

        [Display(Name = "Tahsilat Tarihi")]
        public DateTime? TahTarhi { get; set; }
        [Display(Name = "Tahsilat Tutarı")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? TahTutar { get; set; }
    }
}
