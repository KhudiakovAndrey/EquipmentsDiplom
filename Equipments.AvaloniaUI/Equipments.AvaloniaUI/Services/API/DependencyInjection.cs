using Equipments.AvaloniaUI.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Services.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<ProblemTypeService>();
            services.AddTransient<ServiceRequestService>();
            services.AddTransient<EmployeesService>();
            services.AddTransient<RequestStatusChangesService>();
            services.AddTransient<RequestStatusesService>();
            services.AddTransient<EquipmentPurchaseRequestService>();
            services.AddTransient<ReportService>();

            return services;
        }
    }
}
