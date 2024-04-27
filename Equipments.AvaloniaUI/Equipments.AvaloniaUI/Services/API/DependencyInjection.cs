using Equipments.AvaloniaUI.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Services.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, AppConfiguration apiConfiguration)
        {
            services.AddSingleton(new UserService(apiConfiguration));
            services.AddSingleton(new ProblemTypeService(apiConfiguration));
            services.AddSingleton(new ServiceRequestService(apiConfiguration));
            services.AddSingleton(new EmployeesService(apiConfiguration));
            services.AddSingleton(new RequestStatusChangesService(apiConfiguration));
            services.AddSingleton(new RequestStatusesService(apiConfiguration));
            services.AddSingleton(new EquipmentPurchaseRequestService(apiConfiguration));

            return services;
        }
    }
}
