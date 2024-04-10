using Equipments.AvaloniaUI.ViewModels;
using Equipments.AvaloniaUI.Views;
using ReactiveUI;
using System;

namespace Equipments.AvaloniaUI
{
    public class AppViewLocator : ReactiveUI.IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            EquipmentsServiceRequestViewModel => new EquipmentsServiceRequestView(),
            EquipmentPurchaseRequestViewModel => new EquipmentPurchaseRequestView(),
            CreateServiceRequestViewModel => new CreateServiceRequestView(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}
