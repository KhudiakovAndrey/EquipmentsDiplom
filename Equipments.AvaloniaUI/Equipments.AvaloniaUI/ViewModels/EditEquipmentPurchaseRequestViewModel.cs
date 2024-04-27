using Equipments.AvaloniaUI.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class EditEquipmentPurchaseRequestViewModel : RoutableViewModelBase
    {
        private readonly Guid _idRequest;
        private readonly EquipmentPurchaseRequestService _equipmentPurchaseRequestService;
        public EditEquipmentPurchaseRequestViewModel(
            Guid idRequest,
            EquipmentPurchaseRequestService equipmentPurchaseRequestService)
            : base(nameof(EditEquipmentPurchaseRequestViewModel).ToLowerInvariant())
        {
            _idRequest = idRequest;
            _equipmentPurchaseRequestService = equipmentPurchaseRequestService;
        }


    }
}
