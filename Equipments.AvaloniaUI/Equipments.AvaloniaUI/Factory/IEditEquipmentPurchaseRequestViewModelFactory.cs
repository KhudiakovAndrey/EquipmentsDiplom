using Equipments.AvaloniaUI.ViewModels;
using System;

namespace Equipments.AvaloniaUI.Factory
{
    public interface IEditEquipmentPurchaseRequestViewModelFactory
    {
        EditEquipmentPurchaseRequestViewModel Create(Guid id);
    }
}
