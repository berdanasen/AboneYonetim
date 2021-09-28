using AboneYonetim.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboneYonetim.Entities.ViewModel
{
    public class KULLANICI_VIEW_MODEL
    {
        public int ObjectID { get; set; }

        [Display(Name = "Rol Adı")]
        public string RolAd { get; set; }

        [Display(Name = "T.C Kimlik Numarası")]
        public string TcNo { get; set; }

        [Display(Name = "Adı Soyadı")]
        public string AdSoyad { get; set; }

        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Display(Name = "E Posta Adresi")]
        public string Eposta { get; set; }

        [Display(Name = "Gsm No")]
        public string GsmNo { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string Kulad { get; set; }
    }
}
