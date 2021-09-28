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
    public class DonemController : Controller
    {
        [HttpGet("Donem_Getir")]
        public IActionResult Donem_Getir(int refId, string kulAd, string sifre)
        {
            clsDonem_Islemler cls = new clsDonem_Islemler();
            Mesajlar<DONEM> m = cls.Getir(refId, 0);
            return Json(m);
        }
        [HttpGet("Donem_Liste")]
        public IActionResult Donem_Liste(string kulAd, string sifre)
        {
            clsDonem_Islemler cls = new clsDonem_Islemler();
            Mesajlar<DONEM> m = cls.Listele(0);
            return Json(m);
        }
        [HttpPost("Donem_Duzelt")]
        public IActionResult Donem_Duzelt([FromBody] DONEM d, string kulAd, string sifre)
        {
            clsDonem_Islemler cls = new clsDonem_Islemler();
            Mesajlar<DONEM> m = cls.Duzelt(d, 0);
            return Json(m);
        }
        [HttpPost("Donem_Ekle")]
        public IActionResult Donem_Ekle([FromBody] DONEM d, string kulAd, string sifre)
        {
            clsDonem_Islemler cls = new clsDonem_Islemler();
            Mesajlar<DONEM> m = cls.Ekle(d, 0);
            return Json(m);
        }
        [HttpPost("Donem_Sil")]
        public IActionResult Donem_Sil([FromBody] DONEM d, string kulAd, string sifre)
        {
            clsDonem_Islemler cls = new clsDonem_Islemler();
            Mesajlar<DONEM> m = cls.Sil(d, 0);
            return Json(m);
        }
        [HttpPost("Donem_Sil_Id")]
        public IActionResult Donem_Sil_Id(int refID, string kulAd, string sifre)
        {
            clsDonem_Islemler cls = new clsDonem_Islemler();
            Mesajlar<DONEM> m = cls.Sil_Id(refID, 0);
            return Json(m);
        }
    }
}
