using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Equipments.AvaloniaUI.ViewModels;
using HanumanInstitute.MvvmDialogs;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace Equipments.AvaloniaUI.Views
{
    public partial class AuthorizationView : UserControl
    {
        public AuthorizationView()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<AuthorizationViewModel>();
            DataContext = vm;

            vm.OnAuthorizationSuccess += AuthorizationViewModel_OnAuthorizationSuccess;
        }

        private void AuthorizationViewModel_OnAuthorizationSuccess(object? sender, System.EventArgs e)
        {
            if (VisualRoot is MainAuthView root)
            {
                root.Close(/* Здесь будет пользователь */);
            }
        }
    }
}
