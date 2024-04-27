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
using System.Reactive;
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
                .Sort(SortExpressionComparer<PurchaseRequestModel>.Descending(r => r.CreationDate))
                .Filter(Filtered)
                .Bind(out _purchases)
                .DisposeMany()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe();

            Notify = NotifyTaskCompletion.Create(Initialize);

            this.WhenAnyValue(vm => vm.SelectedDateFilter,
                vm => vm.SelectedEmploye).Subscribe(_ => _source.Refresh());

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
            bool isSysAdminValid = SelectedEmploye?.ID == Guid.Empty ? true : model.SystemAdministration.ID == SelectedEmploye?.ID;
            bool isCreationDateValid = SelectedDateFilter == null ? true : model.CreationDate == SelectedDateFilter.Value;

            return isSysAdminValid && isCreationDateValid;
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
            var employees = response.Data.Items.Select(x => x.SystemAdministration).OrderByDescending(x => x.ID).ToList();
            EmployeesFilterList.Clear();
            EmployeesFilterList.Add(new EmployeModel
            {
                ID = Guid.Empty,
                FullName = "Все"
            });
            EmployeesFilterList.Add(employees);
            SelectedEmploye = EmployeesFilterList.First();
        }
        #region Properties
        [Reactive] public DateTime? SelectedDateFilter { get; set; }
        [Reactive] public ObservableCollection<EmployeModel> EmployeesFilterList { get; set; } = new();
        [Reactive] public EmployeModel? SelectedEmploye { get; set; }

        private ReadOnlyObservableCollection<PurchaseRequestModel> _purchases;
        public ReadOnlyObservableCollection<PurchaseRequestModel> Purchases
        {
            get => _purchases;
            set => this.RaiseAndSetIfChanged(ref _purchases, value);
        }

        private SourceCache<PurchaseRequestModel, Guid> _source = new(x => x.ID);

        #endregion
    }
}
