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
    public class KullaniciRolController : Controller
    {
        [HttpGet("Kullanici_Rol_Listele")]
        public IActionResult Kullanici_Rol_Listele(string kullaniciAd, string sifre)
        {
            clsKullanici_Rol_Islemler cls = new clsKullanici_Rol_Islemler();
            Mesajlar<KULLANICI_ROL> m = cls.Listele(0);

            return Json(m);
        }

        [HttpPost("Kullanici_Rol_Sil_Id")]
        public IActionResult Kullanici_Rol_Sil_Id(int _refID, string kullaniciAd, string sifre)
        {
            clsKullanici_Rol_Islemler cls = new clsKullanici_Rol_Islemler();
            Mesajlar<KULLANICI_ROL> m = cls.Sil_ID(_refID, 0);

            return Json(m);
        }

        [HttpPost("Kullanici_Rol_Duzelt")]
        public IActionResult Kullanici_Rol_Duzelt([FromBody] KULLANICI_ROL k, string kullaniciAd, string sifre)
        {
            clsKullanici_Rol_Islemler cls = new clsKullanici_Rol_Islemler();
            Mesajlar<KULLANICI_ROL> m = cls.Duzelt(k, 0);

            return Json(m);
        }

        [HttpGet("Kullanici_Rol_Getir")]
        public IActionResult Kullanici_Rol_Getir(int _refID, string kullaniciAd, string sifre)
        {
            clsKullanici_Rol_Islemler cls = new clsKullanici_Rol_Islemler();
            Mesajlar<KULLANICI_ROL> m = cls.Getir(_refID, 0);

            return Json(m);
        }

        [HttpPost("Kullanici_Rol_Ekle")]
        public IActionResult Kullanici_Rol_Ekle([FromBody] KULLANICI_ROL k, string kullaniciAd, string sifre)
        {
            clsKullanici_Rol_Islemler cls = new clsKullanici_Rol_Islemler();
            Mesajlar<KULLANICI_ROL> m = cls.Ekle(k, 0);

            return Json(m);
        }
    }
}
