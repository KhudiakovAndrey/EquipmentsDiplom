using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Views
{
    public partial class ConfirmEmailView : UserControl
    {
        public ConfirmEmailView()
        {
            var vm = App.ServiceProvider!.GetRequiredService<ConfirmEmailViewModel>();
            DataContext = vm;
            InitializeComponent();
        }

        public ConfirmEmailView(string email)
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<ConfirmEmailViewModel>();
            vm.Email = email;
            DataContext = vm;
            vm.SendEmailCode();
        }
    }
}
