using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Equipments.AvaloniaUI.ViewModels;

namespace Equipments.AvaloniaUI.Views
{
    public partial class EquipmentPurchaseRequestView : ReactiveUserControl<EquipmentPurchaseRequestViewModel>
    {
        public EquipmentPurchaseRequestView()
        {
            InitializeComponent();
        }
    }
}
