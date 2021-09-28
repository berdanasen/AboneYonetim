using AboneYonetim.Entities.Concrete;
using AboneYonetim.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebUI.Middlewares
{
    public class AboneYonetimSessionControl
    {
        RequestDelegate _next;

        public AboneYonetimSessionControl(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext cnt)
        {
            if (cnt.Session != null)
            {
                KULLANICI k = cnt.Session.GetObject<KULLANICI>("user");

                if (k == null)
                {
                    cnt.Response.Redirect("/Home");
                }
            }
            else
            {
                cnt.Response.Redirect("/Home");
            }

            return _next.Invoke(cnt);
        }
    }

    public static class AboneYonetimSessionControlExtensions
    {
        public static IApplicationBuilder UseAboneYonetimSessionControl(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AboneYonetimSessionControl>();
        }
    }
}
