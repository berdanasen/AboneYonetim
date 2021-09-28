using AboneYonetim.Entities.Concrete;
using AboneYonetim.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using AboneYonetim.WebAPI.Data;
using AboneYonetim.Entities.Genel;

namespace AboneYonetim.WebUI.Controllers
{
    public class HomeController : Controller
    {

        IConfiguration _cfg;
        string WebApiUrl = "";

        public HomeController(IConfiguration cfg)
        {
            _cfg = cfg;

            WebApiUrl = cfg.GetValue<string>("WebApiLoginUrl");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult frmLoginPost(KULLANICI_LOGIN k)
        {
            string pass = k.Sifre; // .Remove(k.Sifre.Length-1,1).Remove(0, 1);

            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();

            if (ModelState.IsValid)
            {
                try
                {
                    using (HttpClientHandler handler = new HttpClientHandler())
                    {
                        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                        using (HttpClient c = new HttpClient(handler))
                        {
                            string url = WebApiUrl + "Kullanici/Kullanici_Kontrol";

                            StringContent content = new StringContent(JsonConvert.SerializeObject(k), System.Text.Encoding.UTF8, "application/json");

                            using (var response = c.PostAsync(url, content))
                            {
                                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    var sonuc = response.Result.Content.ReadAsStringAsync();
                                    sonuc.Wait();

                                    Mesajlar<KULLANICI> mesaj = JsonConvert.DeserializeObject<Mesajlar<KULLANICI>>(sonuc.Result);

                                    if (mesaj != null && mesaj.Durum && mesaj.Nesne != null)
                                    {
                                        HttpContext.Session.SetObject("user", mesaj.Nesne);
                                        HttpContext.Session.SetString("pass", pass);

                                        m.Durum = true;
                                        m.Mesaj = "İşlem başarılı";
                                        m.Nesne = mesaj.Nesne;
                                    }
                                    else
                                    {
                                        m.Durum = false;
                                        m.Mesaj = "Kullanıcı bilgileriniz doğrulanamadı. Lütfen bilgilerinizi kontrol ediniz!";
                                    }

                                }
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    m.Durum = false;
                    m.Mesaj = ex.Message + System.Environment.NewLine + ex.StackTrace;
                }
            }

            return Json(m);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("/Home/Login");
        }
    }
}
