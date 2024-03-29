using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainAuthView : Window
    {
        public MainAuthView()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<MainAuthViewModel>();
            DataContext = vm;
        }
    }
}
