using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Db
{
    public class WeatherDatabaseContext : DbContext
    {
        public WeatherDatabaseContext(DbContextOptions options) : base(options) { }

        public WeatherDatabaseContext() { }

       public DbSet<WeatherForeCast> WeatherForecasts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}