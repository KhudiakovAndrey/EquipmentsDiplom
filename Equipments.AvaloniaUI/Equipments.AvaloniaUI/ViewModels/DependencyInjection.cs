using Equipments.AvaloniaUI.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<AuthorizationViewModel>();
            services.AddTransient<ConfirmEmailViewModel>();
            services.AddTransient<RegistrationViewModel>();
            services.AddSingleton<MainAuthViewModel>();

            return services;
        }
    }
}
