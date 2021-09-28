using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using AboneYonetim.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KullaniciController : Controller
    {
        [HttpPost("Kullanici_Kontrol")]
        public IActionResult Kullanici_Kontrol([FromBody] KULLANICI_LOGIN kullanici)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Kullanici_Kontrol(kullanici.KullaniciAd, kullanici.Sifre);
            return Json(m);
        }
        [HttpGet("Kullanici_Getir")]
        public IActionResult Kullanici_Getir(int _refID, string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Getir(_refID, 0);

            return Json(m);
        }
        [HttpGet("Kullanici_Getir_Iliskisel")]
        public IActionResult Kullanici_Getir_Iliskisel(int _refID, string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Getir_Iliskisel(_refID, 0);

            return Json(m);
        }
        [HttpPost("Kullanici_Ekle")]
        public IActionResult Kullanici_Ekle([FromBody] KULLANICI _k, string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Ekle(_k, 0);

            return Json(m);
        }
        [HttpPost("Kullanici_Duzelt")]
        public IActionResult Kullanici_Duzelt([FromBody] KULLANICI _k, string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Duzelt(_k, 0);
            return Json(m);
        }
        [HttpPost("Kullanici_Sil")]
        public IActionResult Kullanici_Sil([FromBody] KULLANICI _k, string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Sil(_k, 0);
            return Json(m);
        }
        [HttpPost("Kullanici_Sil_Id")]
        public IActionResult Kullanici_Sil_Id(int _refID, string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Sil_Id(_refID, 0);
            return Json(m);
        }
        [HttpGet("Kullanici_Listele")]
        public IActionResult Kullanici_Listele(string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Listele(0);

            return Json(m);
        }
        [HttpGet("Kullanici_Listele_Iliskisel")]
        public IActionResult Kullanici_Listele_Iliskisel(string kullaniciAd, string sifre)
        {
            clsKullanici_Islemler cls = new clsKullanici_Islemler();
            Mesajlar<KULLANICI> m = cls.Listele_Iliskisel(0);

            return Json(m);
        }
    }
}
