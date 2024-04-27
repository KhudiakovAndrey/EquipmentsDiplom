using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.ViewModels;
using System;

namespace Equipments.AvaloniaUI.Factory
{
    public class EditEquipmentPurchaseRequestViewModelFactory : IEditEquipmentPurchaseRequestViewModelFactory
    {
        private readonly EquipmentPurchaseRequestService _equipmentPurchaseRequestService;
        public EditEquipmentPurchaseRequestViewModelFactory(EquipmentPurchaseRequestService equipmentPurchaseRequestService)
        {
            _equipmentPurchaseRequestService = equipmentPurchaseRequestService;
        }
        public EditEquipmentPurchaseRequestViewModel Create(Guid id)
        {
            return new EditEquipmentPurchaseRequestViewModel(
                id,
                _equipmentPurchaseRequestService);
        }
    }
}
