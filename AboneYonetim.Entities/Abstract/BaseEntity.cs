using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboneYonetim.Entities.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectID { get; set; }

        [DisplayName("Aktif")]
        public bool Aktif { get; set; }

        [BindNever]
        //[Column(TypeName="datetime")]
        public DateTime? KayitTarih { get; set; }

        [BindNever]
        public int? Ka_KullaniciID { get; set; }

        [BindNever]
        // [Column(TypeName = "datetime")]
        public DateTime? DuzeltmeTarih { get; set; }

        [BindNever]
        public int? Du_KullaniciID { get; set; }

        [BindNever]
        //[Column(TypeName = "datetime")]
        public DateTime? SilmeTarih { get; set; }

        [BindNever]
        public int? Sil_KullaniciID { get; set; }

        [BindNever]
        public bool Durum { get; set; }
    }
}
