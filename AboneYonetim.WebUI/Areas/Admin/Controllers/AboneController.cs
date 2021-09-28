using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.ViewModel;
using AboneYonetim.WebUI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboneController : BaseController
    {
        public AboneController(IHttpContextAccessor cnt, IConfiguration configuration) : base(cnt, configuration)
        {

        }

        public IActionResult Index()
        {
            @ViewBag.userName = _baseUser.Kulad;
            @ViewBag.passWord = _basePassword;
            @ViewBag.webUrl = _WebApiUrl;
            return View();
        }

        public IActionResult Ekle()
        {
            @ViewBag.userName = _baseUser.Kulad;
            @ViewBag.passWord = _basePassword;
            @ViewBag.webUrl = _WebApiUrl;
            @ViewBag.RefID = 0;
            return View(new ABONE());
        }
    }
}
