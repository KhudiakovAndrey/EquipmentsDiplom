using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainAuthView : UserControl
    {
        public MainAuthView()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetService<MainAuthViewModel>();
            DataContext = vm;
        }
    }
}
