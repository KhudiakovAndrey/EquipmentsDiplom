using Equipments.AvaloniaUI.Factorys;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Factory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFactory(this IServiceCollection services)
        {
            services.AddTransient<ICreateServiceRequestViewModelFactory, CreateServiceRequestViewModelFactory>();

            return services;
        }
    }
}
