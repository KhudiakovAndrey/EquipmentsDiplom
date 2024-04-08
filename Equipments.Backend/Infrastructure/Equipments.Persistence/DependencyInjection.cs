using Equipments.Application.Interfaces;
using Equipments.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration["DbDevKPKConnection"];
            services.AddDbContext<EquipmentsBusinessContext>(options =>
            {
                options.UseNpgsql(connectionsString);
            });
            services.AddScoped<IEquipmentsDbContext>(provider => provider.GetService<EquipmentsBusinessContext>()!);
            return services;
        }
    }
}
