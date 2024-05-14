using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<MainMenuViewModel>();
            DataContext = vm;

        }
    }
}
