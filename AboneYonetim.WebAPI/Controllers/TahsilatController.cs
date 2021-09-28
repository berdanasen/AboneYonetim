using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using AboneYonetim.Entities.ViewModel;
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
    public class TahsilatController : Controller
    {
        [HttpGet("Tahsilat_Getir")]
        public IActionResult Tahsilat_Getir(int _refID, string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Getir(_refID, 0);

            return Json(m);
        }
        [HttpGet("Tahsilat_Getir_Iliskisel")]
        public IActionResult Tahsilat_Getir_Iliskisel(int _refID, string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Getir_Iliskisel(_refID, 0);
            return Json(m);
        }
        [HttpPost("Tahsilat_Ekle")]
        public IActionResult Tahsilat_Ekle([FromBody] TAHSILAT tahsilat, string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Ekle(tahsilat, 0);
            return Json(m);
        }
        [HttpPost("Tahsilat_Duzenle")]
        public IActionResult Tahsilat_Duzenle([FromBody] TAHSILAT tahsilat, string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Duzelt(tahsilat, 0);
            return Json(m);
        }
        [HttpPost("Tahsilat_Sil")]
        public IActionResult Tahsilat_Sil([FromBody] TAHSILAT tahsilat, string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Sil(tahsilat, 0);
            return Json(m);
        }
        [HttpPost("Tahsilat_Ode")]
        public IActionResult Tahsilat_Ode([FromBody] TAHSILAT tahsilat, string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Ode(tahsilat, 0);
            return Json(m);
        }
        [HttpPost("Tahsilat_Ekle_Ode")]
        public IActionResult Tahsilat_Ekle_Ode([FromBody] TAHSILAT tahsilat, string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Ekle_Ode(tahsilat, 0);
            return Json(m);
        }
        [HttpGet("Tahsilat_Listele")]
        public IActionResult Tahsilat_Listele(string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Listele(0);

            return Json(m);
        }
        [HttpGet("Tahsilat_Listele_Iliskisel")]
        public IActionResult Tahsilat_Listele_Iliskisel(string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Listele_Iliskisel(0);

            return Json(m);
        }
        [HttpGet("Tahsilat_Kisi_Listele_Iliskisel")]
        public IActionResult Tahsilat_Kisi_Listele_Iliskisel(string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Kisi_Listele_Iliskisel(kullaniciAd, 0);

            return Json(m);
        }
        [HttpGet("Tahsilat_Kisi_Odenmis_Listele_Iliskisel")]
        public IActionResult Tahsilat_Kisi_Odenmis_Listele_Iliskisel(string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Kisi_Odenmis_Listele_Iliskisel(kullaniciAd, 0);

            return Json(m);
        }
        [HttpGet("Tahsilat_Kisi_Odenmemis_Listele_Iliskisel")]
        public IActionResult Tahsilat_Kisi_Odenmemis_Listele_Iliskisel(string kullaniciAd, string sifre)
        {
            clsTahsilat_Islemler cls = new clsTahsilat_Islemler();
            Mesajlar<TAHSILAT> m = cls.Kisi_Odenmemis_Listele_Iliskisel(kullaniciAd, 0);

            return Json(m);
        }
    }
}
