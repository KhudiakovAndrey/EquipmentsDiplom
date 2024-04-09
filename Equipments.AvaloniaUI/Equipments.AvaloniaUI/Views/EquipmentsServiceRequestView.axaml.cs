using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Views
{
    public partial class EquipmentsServiceRequestView : ReactiveUserControl<EquipmentsServiceRequestViewModel>
    {
        public EquipmentsServiceRequestView()
        {
            InitializeComponent();
            //var vm = App.ServiceProvider!.GetService<EquipmentsServiceRequestViewModel>();
            //DataContext = vm;
        }
    }
}
