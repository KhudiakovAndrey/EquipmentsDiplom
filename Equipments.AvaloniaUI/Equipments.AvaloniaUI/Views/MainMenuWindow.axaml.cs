using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<MainMenuViewModel>();
            DataContext = vm;
        }
    }
}
