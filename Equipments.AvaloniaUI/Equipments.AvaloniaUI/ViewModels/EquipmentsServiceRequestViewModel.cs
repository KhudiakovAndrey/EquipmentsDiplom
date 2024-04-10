using Avalonia.Diagnostics;
using DynamicData;
using DynamicData.Binding;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class EquipmentsServiceRequestViewModel : RoutableViewModelBase
    {
        private readonly ServiceRequestService _serviceRequestService;
        private readonly EmployeesService _employeesService;

        public EquipmentsServiceRequestViewModel(ServiceRequestService serviceRequestService, EmployeesService employeesService)
            : base(nameof(EquipmentPurchaseRequestViewModel).ToLowerInvariant())
        {
            _serviceRequestService = serviceRequestService;
            _employeesService = employeesService;

            Page = new PaginationEquipmentsServiceRequestVM();

            var cancelletion = _sourceCache.Connect()
                .Sort(SortExpressionComparer<EquipmentsServiceRequestVM>.Ascending(r => r.CreationDate))
                //.Filter()
                .Bind(out _requests)
                .Subscribe();

            GetServiceRequests();
            GetEmployees();

            var isExecuteNextPageCommand = this.WhenAnyValue(vm => vm.Page,
                page => page.PageNumber < Page.TotalPages);
            var isExecuteBackPageCommand = this.WhenAnyValue(vm => vm.Page,
                page => page.PageNumber != 1);
            NextPageCommand = ReactiveCommand.CreateFromTask(NextPage, isExecuteNextPageCommand);
            BackPageCommand = ReactiveCommand.CreateFromTask(BackPage, isExecuteBackPageCommand);


        }
        public int TotalPages { get; set; } = 0;
        private async Task GetEmployees()
        {
            var response = await _employeesService.GetEmployees();
            if (response.IsSucces)
            {
                Employees = new ObservableCollection<EmployeModel>(response.Data);
            }
        }
        private async Task GetServiceRequests()
        {
            var query = GetPageQuery();
            var response = await _serviceRequestService.GetPageServiceRequests(query);
            if (response.IsSucces)
            {
                Page = response.Data;
                _sourceCache.Edit(edit =>
                {
                    edit.Clear();
                    edit.AddOrUpdate(Page.Items);
                });

            }
        }
        private GetPageServiceRequestQuery GetPageQuery() =>
             new GetPageServiceRequestQuery
             {
                 Pagination = new PaginationVM
                 {
                     PageNumber = Page.PageNumber,
                     PageSize = Page.PageSize
                 }
             };
        public ReactiveCommand<Unit, Unit> NextPageCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> BackPageCommand { get; private set; }
        private async Task BackPage()
        {
            Page.PageNumber--;
            await GetServiceRequests();
        }
        private async Task NextPage()
        {
            Page.PageNumber++;
            await GetServiceRequests();
        }

        #region Properties
        private PaginationEquipmentsServiceRequestVM _page;
        public PaginationEquipmentsServiceRequestVM Page
        {
            get => _page;
            set => this.RaiseAndSetIfChanged(ref _page, value);
        }

        [Reactive] ObservableCollection<EmployeModel> Employees { get; set; }
        [Reactive] EmployeModel? SelectedResponsible { get; set; }
        [Reactive] EmployeModel? SelectedSystemAdministrator { get; set; }

        private SourceCache<EquipmentsServiceRequestVM, Guid> _sourceCache = new(x => x.ID);


        private ReadOnlyObservableCollection<EquipmentsServiceRequestVM> _requests;
        public ReadOnlyObservableCollection<EquipmentsServiceRequestVM> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }
        #endregion
    }
}
