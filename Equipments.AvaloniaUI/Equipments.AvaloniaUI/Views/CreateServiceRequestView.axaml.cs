using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Equipments.AvaloniaUI.ViewModels;

namespace Equipments.AvaloniaUI.Views
{
    public partial class CreateServiceRequestView : ReactiveUserControl<CreateServiceRequestViewModel>
    {
        public CreateServiceRequestView()
        {
            InitializeComponent();
        }
    }
}
