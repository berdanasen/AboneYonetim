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
    public class KULLANICI_LOGIN
    {
        [Display(Name = "Kullanıcı Adı / E-Posta Adresi")]
        [Required(ErrorMessage = "* Doldurulması zorunlu alandır!")]
        public string KullaniciAd { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "* Doldurulması zorunlu alandır!")]
        public string Sifre { get; set; }

        public string WebApiUrl { get; set; }
    }

    public class KULLANICI : BaseEntity
    {
        [Display(Name = "Rol Adı")]
        [ForeignKey("KullaniciRol")]
        public int? RolID { get; set; }

        public virtual KULLANICI_ROL KullaniciRol { get; set; }

        [Display(Name = "T.C Kimlik Numarası")]
        [MaxLength(11)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        [RegularExpression(@"(\d{11})$", ErrorMessage = "Girilen değer doğru formatta değildir.")]
        public string TcNo { get; set; }

        [Display(Name = "Adı Soyadı")]
        [MaxLength(150)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string AdSoyad { get; set; }

        [Display(Name = "E Posta Adresi")]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        [MaxLength(100)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Girilen değer doğru formatta değildir!")]
        public string Eposta { get; set; }

        [Display(Name = "Gsm No")]
        [MaxLength(25)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string GsmNo { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string Kulad { get; set; }

        [Display(Name = "Şifre")]
        [MaxLength(50)]
        public string Sifre { get; set; }

    }

    public class KULLANICI_ROL : BaseEntity
    {
        [Display(Name = "Rol Adı")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string RolAd { get; set; }
        //public virtual List<KULLANICI> lstKullanicilar { get; set; } = new List<KULLANICI>();

    }
}
