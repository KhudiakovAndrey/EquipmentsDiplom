using DynamicData;
using DynamicData.Binding;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Nito.AsyncEx;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class EquipmentPurchaseRequestViewModel : RoutableViewModelBase
    {
        private readonly EquipmentPurchaseRequestService _equipmentPurchaseRequestService;
        public EquipmentPurchaseRequestViewModel(
            EquipmentPurchaseRequestService equipmentPurchaseRequestService
            )

            : base(nameof(EquipmentPurchaseRequestViewModel).ToLowerInvariant())
        {
            _equipmentPurchaseRequestService = equipmentPurchaseRequestService;

            var cancellation = _source.Connect()
                .Sort(SortExpressionComparer<PurchaseRequestModel>.Ascending(r => r.CreationDate))
                //.Filter(request => Filtered(request))
                .Bind(out _purchases)
                .DisposeMany()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe();


            Notify = NotifyTaskCompletion.Create(Initialize);
        }

        private async Task Initialize()
        {
            await InitializePurchaseRequests();
        }
        private async Task InitializePurchaseRequests()
        {
            var response = await _equipmentPurchaseRequestService.GetAllAsync();
            if (!response.IsSucces)
                return;
            _source.Edit(source =>
            {
                source.Clear();
                source.AddOrUpdate(response.Data.Items);
            });
        }
        #region Properties

        private ReadOnlyObservableCollection<PurchaseRequestModel> _purchases;
        public ReadOnlyObservableCollection<PurchaseRequestModel> Purchases
        {
            get => _purchases;
            set => this.RaiseAndSetIfChanged(ref _purchases, value);
        }
        private SourceCache<PurchaseRequestModel, Guid> _source => new(x => x.ID);

        #endregion
    }
}
