using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Views
{
    public partial class ConfirmEmailView : UserControl
    {
        public ConfirmEmailView()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<ConfirmEmailViewModel>();
            DataContext = vm;
        }
    }
}
