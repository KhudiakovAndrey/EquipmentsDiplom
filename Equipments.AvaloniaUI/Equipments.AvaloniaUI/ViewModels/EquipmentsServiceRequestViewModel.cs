using DynamicData;
using Equipments.AvaloniaUI.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class EquipmentsServiceRequestViewModel : RoutableViewModelBase
    {
        public EquipmentsServiceRequestViewModel(IScreen screen)
            : base(screen, nameof(EquipmentPurchaseRequestViewModel).ToLowerInvariant())
        {
            Page = new PaginationEquipmentsServiceRequestVM();

        }
        public string Test => "test";
        [Reactive] PaginationEquipmentsServiceRequestVM Page { get; set; }

        [Reactive] public Guid? IDResponsible { get; set; }
        [Reactive] public DateTime? CreationDate { get; set; }
    }
}
