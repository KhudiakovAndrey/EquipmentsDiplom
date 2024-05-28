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
            services.AddTransient<DialogUploadFileViewModel>();
            services.AddTransient<MainAuthViewModel>();
            services.AddTransient<MainMenuViewModel>();
            services.AddTransient<UserProfileViewModel>();
            services.AddTransient<UserProfileInfoViewModel>();
            services.AddTransient<UserProfileDashboardViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<ReportsViewModel>();

            //Регистрируем классы создающиеся один раз при запуске
            services.AddSingleton<MainMenuWindowViewModel>();

            return services;
        }
    }
}
