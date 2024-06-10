using Avalonia.Controls.Documents;
using DynamicData;
using DynamicData.Binding;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Microsoft.Extensions.DependencyInjection;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class EquipmentPurchaseRequestViewModel : RoutableViewModelBase
    {
        private readonly EquipmentPurchaseRequestService _equipmentPurchaseRequestService;
        public EquipmentPurchaseRequestViewModel(EquipmentPurchaseRequestService equipmentPurchaseRequestService)
            : base(nameof(EquipmentPurchaseRequestViewModel).ToLowerInvariant())
        {
            _equipmentPurchaseRequestService = equipmentPurchaseRequestService;

            InitializeNotify = NotifyTaskCompletion.Create(Initialize);
        }
        private ReactiveCommand<Guid?, Unit>? _showEditRequestCommand;
        public ReactiveCommand<Guid?, Unit> ShowEditRequestCommand =>
            _showEditRequestCommand ??= ReactiveCommand.Create<Guid?>(ShowEditRequest);
        private void ShowEditRequest(Guid? idPurchase)
        {
            App.ServiceProvider!.GetService<MainMenuViewModel>()!.ShowEditEquipmentPurchaseRequestView(idPurchase);
        }

        private ReactiveCommand<Unit, Unit>? _clearFilterCommand;
        public ReactiveCommand<Unit, Unit> ClearFilterCommand => _clearFilterCommand ??= ReactiveCommand.Create(ClearFilter);
        private void ClearFilter()
        {
            SelectedEmploye = EmployeesFilterList.First();
            SelectedDateFilter = null;
        }
        private bool Filtered(PurchaseRequestModel model)
        {
            return true;
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
            Purchases = new ObservableCollection<PurchaseRequestModel>(response.Data.Items);
        }
        #region Properties
        [Reactive] public DateTime? SelectedDateFilter { get; set; }
        [Reactive] public ObservableCollection<EmployeModel> EmployeesFilterList { get; set; } = new();
        [Reactive] public EmployeModel? SelectedEmploye { get; set; }


        [Reactive] public ObservableCollection<PurchaseRequestModel> Purchases { get; set; }

        private SourceCache<PurchaseRequestModel, Guid> _source = new(x => x.ID);

        #endregion
    }
}
