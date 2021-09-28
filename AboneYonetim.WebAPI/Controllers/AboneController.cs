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
    public class AboneController : Controller
    {
        [HttpGet("Abone_Getir")]
        public IActionResult Abone_Getir(int refId, string kulAd, string sifre)
        {
            clsAbone_Islemler abone = new clsAbone_Islemler();
            Mesajlar<ABONE> m = abone.Getir(refId, 0);
            return Json(m);
        }

        [HttpGet("Abone_Getir_Iliskisel")]
        public IActionResult Abone_Getir_Iliskisel(int refId, string kulAd, string sifre)
        {
            clsAbone_Islemler abone = new clsAbone_Islemler();
            Mesajlar<ABONE> m = abone.Getir_Iliskisel(refId, 0);
            return Json(m);
        }
        [HttpGet("Abone_Liste")]
        public IActionResult Abone_Liste(string kulAd, string sifre)
        {
            clsAbone_Islemler abone = new clsAbone_Islemler();
            Mesajlar<ABONE> m = abone.Listele(0);
            return Json(m);
        }
        [HttpGet("Abone_Listele_Iliskisel")]
        public IActionResult Abone_Listele_Iliskisel(string kulAd, string sifre)
        {
            clsAbone_Islemler abone = new clsAbone_Islemler();
            Mesajlar<ABONE> m = abone.Listele_Iliskisel(0);
            return Json(m);
        }
        [HttpPost("Abone_Duzelt")]
        public IActionResult Abone_Duzelt([FromBody] ABONE abone, string kulAd, string sifre)
        {
            clsAbone_Islemler cls = new clsAbone_Islemler();
            Mesajlar<ABONE> m = cls.Duzelt(abone, 0);
            return Json(m);
        }
        [HttpPost("Abone_Ekle")]
        public IActionResult Abone_Ekle([FromBody] ABONE abone, string kulAd, string sifre)
        {
            clsAbone_Islemler cls = new clsAbone_Islemler();
            Mesajlar<ABONE> m = cls.Ekle(abone, 0);
            return Json(m);
        }
        [HttpPost("Abone_Sil")]
        public IActionResult Abone_Sil([FromBody] ABONE abone, string kulAd, string sifre)
        {
            clsAbone_Islemler cls = new clsAbone_Islemler();
            Mesajlar<ABONE> m = cls.Sil(abone, 0);
            return Json(m);
        }
        [HttpPost("Abone_Sil_Id")]
        public IActionResult Abone_Sil_Id(int _refID, string kulAd, string sifre)
        {
            clsAbone_Islemler cls = new clsAbone_Islemler();
            Mesajlar<ABONE> m = cls.Sil_Id(_refID, 0);
            return Json(m);
        }
    }
}
