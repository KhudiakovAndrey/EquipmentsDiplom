using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Equipments.AvaloniaUI.Data
{
    public class SettingsDbContext : DbContext
    {
        public DbSet<AppSettings> Settings { get; set; }
        public SettingsDbContext(DbContextOptions<SettingsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
