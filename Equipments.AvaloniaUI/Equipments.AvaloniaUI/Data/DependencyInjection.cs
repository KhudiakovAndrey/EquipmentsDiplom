using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<SettingsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            return services;
        }
    }
}
