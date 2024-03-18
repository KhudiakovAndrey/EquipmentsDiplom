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
            var connectionsString = configuration["DbDevConnection"];
            services.AddDbContext<EquipmentsDbContext>(options =>
            {
                options.UseNpgsql(connectionsString);
            });
            services.AddScoped<IEquipmentsDbContext>(provider => provider.GetService<EquipmentsDbContext>());
            return services;
        }
    }
}
