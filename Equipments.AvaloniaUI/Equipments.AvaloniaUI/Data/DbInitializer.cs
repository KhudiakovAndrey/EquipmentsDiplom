using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Data
{
    public class DbInitializer
    {
        public static void Initialize(SettingsDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Settings.Any())
            {
                context.Settings.AddAsync(new AppSettings());
                context.SaveChangesAsync();
            }

        }
    }
}
