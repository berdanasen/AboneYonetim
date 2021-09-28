using AboneYonetim.Entities.Concrete;
using AboneYonetim.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebUI.Controllers
{
    public class BaseController : Controller
    {
        IHttpContextAccessor cnt;
        IConfiguration cfg;

        public KULLANICI _baseUser { get; }
        public string _basePassword { get; }

        // bu tablolar bulunmadığı için yorum satırına aldım.

        //public List<KULLANICI_ROL_YETKI> _basePerms { get; }

        //public SISTEM_PARAMETRE _baseSistemParametreler { get; }

        public string _WebApiUrl { get; }

        public BaseController(IHttpContextAccessor _cnt, IConfiguration _cfg)
        {
            cnt = _cnt;
            cfg = _cfg;

            _baseUser = _cnt.HttpContext.Session.GetObject<KULLANICI>("user");
            _basePassword = _cnt.HttpContext.Session.GetString("pass");

            //_basePerms = _cnt.HttpContext.Session.GetObject<List<KULLANICI_ROL_YETKI>>("perm");
            //_baseSistemParametreler = _cnt.HttpContext.Session.GetObject<SISTEM_PARAMETRE>("sysParams");

            _WebApiUrl = _cfg.GetValue<string>("WebApiUrl");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Controller c = context.Controller as Controller;
            if (_baseUser != null)
            c.ViewData.Add("user", _baseUser.AdSoyad);
            //c.ViewData.Add("prms", _basePerms);

            base.OnActionExecuting(context);
        }
    }
}
