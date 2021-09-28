using AboneYonetim.WebUI.Areas.Admin.Controllers;
using AboneYonetim.WebUI.Middlewares;
//using DevExpress.AspNetCore;
//using DevExpress.AspNetCore.Reporting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(x => x.EnableEndpointRouting = false).AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true)
            //    .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver()).AddRazorRuntimeCompilation();

            services.AddMvc(x => x.EnableEndpointRouting = false).AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver()).AddRazorRuntimeCompilation();

            //services.AddDevExpressControls();
            //services.ConfigureReportingServices(configurator =>
            //{
            //    configurator.ConfigureWebDocumentViewer(viewerConfigurator =>
            //    {
            //        viewerConfigurator.UseCachedReportSourceBuilder();
            //    });
            //});

            services.AddCors();

            services.AddDistributedMemoryCache(); //Eklenmezse session çalýþmaz.
            services.AddSession(o => { o.IdleTimeout = TimeSpan.FromHours(10); o.IOTimeout = TimeSpan.FromHours(10); });
            services.AddMemoryCache();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseDevExpressControls();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());

            var suppertLang = new[]
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR"),
                SupportedCultures = suppertLang,
                SupportedUICultures = suppertLang
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSession();

            List<string> lstUrl = new List<string>()
            {
                "","/","/Home","/Home/Login","/Home/frmLoginPost","/favicon.ico"
            };

            // string str = "";

            app.UseWhen(cnt => !lstUrl.Contains(cnt.Request.Path.Value, StringComparer.OrdinalIgnoreCase), appBuilder =>
            {
                appBuilder.UseAboneYonetimSessionControl();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Login}/{id?}");
                routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
