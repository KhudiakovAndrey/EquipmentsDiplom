using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace Equipments.AvaloniaUI.Views
{
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<RegistrationViewModel>();
            DataContext = vm;
        }
    }
}
