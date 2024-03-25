using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Data
{
    public class AppSettingsContext : DbContext
    {
        public DbSet<AppSettings> Settings { get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=settings.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Database.EnsureCreated();
            if (!Settings.Any())
            {
                Settings.Add(new AppSettings());
                SaveChanges();
            }
        }
    }
}
