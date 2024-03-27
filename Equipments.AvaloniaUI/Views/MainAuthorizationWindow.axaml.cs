using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainAuthorizationWindow : Window
    {
        public MainAuthorizationWindow()
        {
            InitializeComponent();
            var viewModel = App.ServiceProvider!.GetRequiredService<MainAuthorizationViewModel>();
            DataContext = viewModel;
        }
    }
}
