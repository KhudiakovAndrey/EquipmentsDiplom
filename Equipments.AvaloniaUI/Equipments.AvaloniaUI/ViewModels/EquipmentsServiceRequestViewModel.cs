using DynamicData;
using DynamicData.Binding;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.Services.Enums;
using Microsoft.Extensions.DependencyInjection;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class EquipmentsServiceRequestViewModel : RoutableViewModelBase
    {
        private readonly ServiceRequestService _serviceRequestService;
        private readonly EmployeesService _employeesService;

        public EquipmentsServiceRequestViewModel(ServiceRequestService serviceRequestService,
            EmployeesService employeesService)
            : base(nameof(EquipmentPurchaseRequestViewModel).ToLowerInvariant())
        {
            _serviceRequestService = serviceRequestService;
            _employeesService = employeesService;

            Page = new PaginationEquipmentsServiceRequestVM();

            var cancelletion = _sourceCache.Connect()
                .Sort(SortExpressionComparer<EquipmentsServiceRequestVM>.Ascending(r => r.CreationDate))
                .Filter(request => Filtered(request))
                .Bind(out _requests)
                .DisposeMany()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe();
            Notify = NotifyTaskCompletion.Create(GetEmployees);
            Notify = NotifyTaskCompletion.Create(GetServiceRequests);

            var isExecuteNextPageCommand = this.WhenAnyValue(vm => vm.Page,
                page => page.PageNumber < Page.TotalPages);
            var isExecuteBackPageCommand = this.WhenAnyValue(vm => vm.Page,
                page => page.PageNumber != 1);
            var isExecuteClearFilterCommand = this.WhenAnyValue(
                    vm => vm.SelectedDate,
                    vm => vm.SelectedResponsible,
                    vm => vm.SelectedSystemAdministrator,
                    (date, responsible, sysadmin) => date != null || responsible != null || sysadmin != null
                );

            this.WhenAnyValue(
                vm => vm.SelectedResponsible,
                vm => vm.SelectedSystemAdministrator,
                vm => vm.SelectedDate).Subscribe(_ =>
                {
                    Page.PageNumber = 1;
                    _sourceCache.Refresh();
                });

            NextPageCommand = ReactiveCommand.CreateFromTask(NextPage, isExecuteNextPageCommand);
            BackPageCommand = ReactiveCommand.CreateFromTask(BackPage, isExecuteBackPageCommand);
            ClearFilterCommand = ReactiveCommand.Create(ClearFilter, isExecuteClearFilterCommand);
            DeleteServiceRequestCommand = ReactiveCommand.CreateFromTask<Guid>(DeleteServiceRequest);
            EditServiceRequestCommand = ReactiveCommand.Create<Guid>(EditServiceRequest);
        }
        public ReactiveCommand<Guid, Unit> EditServiceRequestCommand { get; private set; }
        private void EditServiceRequest(Guid id) => App.ServiceProvider!.GetRequiredService<MainMenuViewModel>()
            .ShowCreateServiceRequestView(id);
        public ReactiveCommand<Guid, Unit> DeleteServiceRequestCommand { get; private set; }
        public async Task DeleteServiceRequest(Guid id)
        {
            var result = await App.ServiceProvider!.GetRequiredService<MainMenuViewModel>()
                .ShowAskQuestionDialogAsync(
                "Вы действителЬно хотите удалить заявку на обслуживание?",
                "Удаление заявки");
            if (result)
            {
                var response = await _serviceRequestService.DeleteServiceRequest(id);
                if (response.IsSucces)
                {
                    await GetServiceRequests();
                }
            }
        }
        private bool Filtered(EquipmentsServiceRequestVM request)
        {
            bool isResponsibleValid = SelectedResponsible?.ID == Guid.Empty ? true
                : request.Responsible == SelectedResponsible?.FullName;

            bool isSysAdmunValid = SelectedSystemAdministrator?.ID == Guid.Empty ? true
                : request.SystemAdministration == SelectedSystemAdministrator?.FullName;

            bool isCreationDateValid = SelectedDate == null ? true
                : request.CreationDate == SelectedDate;

            return isResponsibleValid && isSysAdmunValid && isCreationDateValid;
        }

        private async Task GetEmployees()
        {
            var response = await _employeesService.GetEmployees();
            if (response.IsSucces)
            {
                Responsibles = new ObservableCollection<EmployeModel>(
                    new List<EmployeModel>()
                    {
                        new EmployeModel
                        {
                            ID = Guid.Empty,
                            FullName = "Все заявители"
                        },
                        response.Data.Where(em => em.RoleID == (int)Roles.Responsible)
                    });
                SystemAdministrations = new ObservableCollection<EmployeModel>(
                    new List<EmployeModel>()
                    {
                        new EmployeModel
                        {
                            ID = Guid.Empty,
                            FullName = "Все исполнители"
                        },
                        response.Data.Where(em => em.RoleID == (int)Roles.SystemAdministration)
                    });

                SelectedResponsible = Responsibles.First();
                SelectedSystemAdministrator = SystemAdministrations.First();
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
        public ReactiveCommand<Unit, Unit> ClearFilterCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> NextPageCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> BackPageCommand { get; private set; }
        private void ClearFilter()
        {
            SelectedDate = null;
            SelectedResponsible = Responsibles.First();
            SelectedSystemAdministrator = SystemAdministrations.First();
        }
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

        [Reactive] public ObservableCollection<EmployeModel> Responsibles { get; set; } = new();
        [Reactive] public ObservableCollection<EmployeModel> SystemAdministrations { get; set; } = new();
        [Reactive] public EmployeModel SelectedResponsible { get; set; }
        [Reactive] public EmployeModel SelectedSystemAdministrator { get; set; }
        [Reactive] public DateTime? SelectedDate { get; set; }

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
