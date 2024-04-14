using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.ViewModels
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            //Регистрируем классы создающиеся при каждом запросе
            services.AddTransient<AuthorizationViewModel>();
            services.AddTransient<ConfirmEmailViewModel>();
            services.AddTransient<RegistrationViewModel>();
            services.AddTransient<ConnectionServerFailedViewModel>();
            services.AddTransient<DialogRequestRoleViewModel>();
            services.AddTransient<EquipmentPurchaseRequestViewModel>();
            services.AddTransient<EquipmentsServiceRequestViewModel>();
            services.AddTransient<AskQuestionViewModel>();
            services.AddTransient<DialogEditRequestStatusViewModel>();

            //Регистрируем классы создающиеся один раз при запуске
            services.AddSingleton<MainAuthViewModel>();
            services.AddSingleton<MainMenuViewModel>();

            return services;
        }
    }
}
