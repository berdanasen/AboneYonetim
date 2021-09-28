using AboneYonetim.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebAPI.Data
{
    public class AboneYonetimContext : DbContext
    {
        public AboneYonetimContext()
        {

        }

        public AboneYonetimContext(DbContextOptions<AboneYonetimContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("AboneYonetimConnection"));
        }

        public DbSet<KULLANICI> KULLANICILAR { get; set; }
        public DbSet<KULLANICI_ROL> KULLANICI_ROLLER { get; set; }
        public DbSet<ABONE> ABONELER { get; set; }
        public DbSet<FATURA> FATURALAR { get; set; }
        public DbSet<TAHSILAT> TAHSILATLAR { get; set; }
        public DbSet<DONEM> DONEMLER { get; set; }

    }
    public static class ContextExtensions
    {
        public static string GetTableName<T>(this DbContext context) where T : class
        {
            string snc = "";

            var models = context.Model;
            var entityTypes = models.GetEntityTypes();

            var tip = entityTypes.First(x => x.ClrType == typeof(T));

            snc = tip.GetTableName();

            return snc;
        }
    }

}
