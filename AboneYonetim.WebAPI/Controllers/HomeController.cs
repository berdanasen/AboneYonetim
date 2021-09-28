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
    public class HomeController : Controller
    {
        [HttpGet("Bar_Chart")]
        public IActionResult Bar_Chart()
        {
            List<DASHBOARD_VIEW_MODEL> vm = new List<DASHBOARD_VIEW_MODEL>();

            Mesajlar<ABONE> m = new clsAbone_Islemler().Listele_Iliskisel(0);
            int index = 0;

            foreach (var item in m.Liste)
            {
                index += 1;
                int deger = 0;

                Mesajlar<FATURA> m1 = new clsFatura_Islemler().Listele_Abone(item.ObjectID, 0);

                if (m1.Liste != null)
                    deger = m1.Liste.Where(x => x.AboneID == item.ObjectID && x.Durum == true).Count();

                if (deger != 0)
                {
                    vm.Add(new DASHBOARD_VIEW_MODEL()
                    {
                        Adi = item.AdSoyad,
                        Deger = deger
                    });
                }
                else
                {
                    index -= 1;
                }
            }
            return Json(vm.OrderByDescending(x => x.Deger));
        }

        [HttpGet("Pie_Chart")]
        public IActionResult Pie_Chart()
        {
            List<DASHBOARD_VIEW_MODEL> vm = new List<DASHBOARD_VIEW_MODEL>();
            Mesajlar<ABONE> m = new clsAbone_Islemler().Listele_Iliskisel(0);

            foreach (var item in m.Liste)
            {
                int deger = 0;

                Mesajlar<FATURA> m1 = new clsFatura_Islemler().Listele_Abone(item.ObjectID, 0);

                if (m1.Liste != null)
                    deger = m1.Liste.Where(x => x.AboneID == item.ObjectID && x.Durum == true).Count();

                vm.Add(new DASHBOARD_VIEW_MODEL()
                {
                    Adi = item.AdSoyad,
                    Deger = deger
                });
            }
            return Json(vm.OrderByDescending(x => x.Deger));
        }
    }
}
