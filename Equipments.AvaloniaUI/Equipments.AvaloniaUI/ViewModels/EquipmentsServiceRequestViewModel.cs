using Aspose.Cells;
using DynamicData;
using DynamicData.Binding;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.Services.Enums;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Microsoft.Extensions.DependencyInjection;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class EquipmentsServiceRequestViewModel : RoutableViewModelBase
    {
        private readonly ServiceRequestService _serviceRequestService;
        private readonly EmployeesService _employeesService;
        private readonly MainMenuWindowViewModel _mainMenuWindowViewModel;
        private readonly IDialogService _dialogService;

        public EquipmentsServiceRequestViewModel(ServiceRequestService serviceRequestService,
            EmployeesService employeesService,
            MainMenuWindowViewModel mainMenuWindowViewModel,
            IDialogService dialogService)
            : base(nameof(EquipmentPurchaseRequestViewModel).ToLowerInvariant())
        {
            _serviceRequestService = serviceRequestService;
            _employeesService = employeesService;

            ChangeHeightDataGridRowItems = new()
            {
                new ChangeHeightDataGridRowModel(40, "table_row_tree_regular"),
                new ChangeHeightDataGridRowModel(48, "table_row_four_regular"),
                new ChangeHeightDataGridRowModel(56, "table_row_five_regular")
            };
            SelectedHeightDataGridRow = ChangeHeightDataGridRowItems[0];
            Page = new PaginationEquipmentsServiceRequestVM();

            var cancelletion = _sourceCache.Connect()
                .Sort(SortExpressionComparer<EquipmentsServiceRequestVM>.Ascending(r => r.CreationDate))
                .Bind(out _requests)
                .DisposeMany()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe();

            InitializeNotify = NotifyTaskCompletion.Create(GetEmployees);

            Page.PageSize = PageSizes.First();

            this.WhenAnyValue(vm => vm.Page.PageSize).Subscribe(_ =>
            {
                InitializeNotify = NotifyTaskCompletion.Create(GetServiceRequests);
            });


            this.WhenAnyValue(vm => vm.SelectedResponsible,
                              vm => vm.SelectedSystemAdministrator,
                              vm => vm.SelectedStartDate,
                              vm => vm.SelectedEndDate
                              ).Subscribe(async _ => await FilterGetServiceRequest());

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

            var isExecuteCleadDateFilterCommand = this.WhenAnyValue(
                vm => vm.SelectedStartDate,
                vm => vm.SelectedEndDate, (start, end) => start != null || end != null);

            NextPageCommand = ReactiveCommand.CreateFromTask(NextPage, isExecuteNextPageCommand);
            BackPageCommand = ReactiveCommand.CreateFromTask(BackPage, isExecuteBackPageCommand);
            ClearFilterCommand = ReactiveCommand.Create(ClearFilter, isExecuteClearFilterCommand);
            DeleteServiceRequestCommand = ReactiveCommand.CreateFromTask<Guid>(DeleteServiceRequest);
            EditServiceRequestCommand = ReactiveCommand.Create<Guid>(EditServiceRequest);
            ClearDateFilterCommand = ReactiveCommand.Create(ClearDateFilter, isExecuteCleadDateFilterCommand);
            _mainMenuWindowViewModel = mainMenuWindowViewModel;
            _dialogService = dialogService;
        }
        public ReactiveCommand<Guid, Unit> EditServiceRequestCommand { get; private set; }
        private void EditServiceRequest(Guid id) => App.ServiceProvider!.GetRequiredService<MainMenuViewModel>()
            .ShowCreateServiceRequestView(id);
        public ReactiveCommand<Guid, Unit> DeleteServiceRequestCommand { get; private set; }
        public async Task DeleteServiceRequest(Guid id)
        {
            var result = await App.MainMenuVM
                .ShowAskQuestionDialogAsync(
                "Вы действителЬно хотите удалить заявку на обслуживание?",
                "Удаление заявки");
            if (result == true)
            {
                var response = await _serviceRequestService.DeleteServiceRequest(id);
                if (response.IsSucces)
                {
                    await GetServiceRequests();
                }
            }
        }

        private async Task GetEmployees()
        {
            var response = await _employeesService.GetEmployees();
            if (response.IsSucces)
            {
                Responsibles = new ObservableCollection<EmployeModel>(
                    new List<EmployeModel>()
                    {
                        response.Data.Where(em => em.RoleID == (int)Roles.Responsible)
                    });
                SystemAdministrations = new ObservableCollection<EmployeModel>(
                    new List<EmployeModel>()
                    {
                        response.Data.Where(em => em.RoleID == (int)Roles.SystemAdministration)
                    });

            }
        }
        private async Task FilterGetServiceRequest()
        {
            Page.PageNumber = 1;
            await GetServiceRequests();
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
                 },
                 IDSystemAdministration = SelectedSystemAdministrator?.ID,
                 IDResponsible = SelectedResponsible?.ID,
                 CreationStartDate = SelectedStartDate,
                 CreationEndDate = SelectedEndDate,
             };
        public void ShowTest()
        {
            App.MainMenuVM.ShowUploadFileDialog();
        }

        //private ReactiveCommand<Unit,Unit> _exportRequest

        public ReactiveCommand<Unit, Unit> ClearDateFilterCommand { get; private set; }
        private void ClearDateFilter()
        {
            SelectedStartDate = null;
            SelectedEndDate = null;
        }
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


        public async void ExportPage(SaveFormat format)
        {
            var filter = new FileFilter()
            {
                Extensions = new List<string>
                {
                    format.ToString().ToLower(),
                },
                Name = format.ToString()
            };
            var settings = new SaveFileDialogSettings
            {
                Filters = new List<FileFilter> { filter }
            };
            var file = await _dialogService.ShowSaveFileDialogAsync(_mainMenuWindowViewModel, settings);

            if (file == null)
                return;

            Workbook workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Cells[0, 0].PutValue("Заявитель");
            sheet.Cells[0, 1].PutValue("Исполнитель");
            sheet.Cells[0, 2].PutValue("Проблема");
            sheet.Cells[0, 3].PutValue("Дата подачи");

            int rowIndex = 1;
            foreach (var item in Page.Items)
            {
                sheet.Cells[rowIndex, 0].PutValue(item.Responsible.FullName);
                sheet.Cells[rowIndex, 1].PutValue(item.SystemAdministration.FullName);
                sheet.Cells[rowIndex, 2].PutValue(item.ProblemType);
                sheet.Cells[rowIndex, 3].PutValue(item.CreationDate.ToString("dd:MM:yyyy HH:mm:ss"));
                rowIndex++;
            }



            try
            {
                workbook.Save(file!.Path!.AbsolutePath, format);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(DateTime.Now + ": " + ex.Message);
            }
        }


        #region Properties
        [Reactive] public ChangeHeightDataGridRowModel SelectedHeightDataGridRow { get; set; }
        public ObservableCollection<ChangeHeightDataGridRowModel> ChangeHeightDataGridRowItems { get; private set; }

        private PaginationEquipmentsServiceRequestVM _page;
        public PaginationEquipmentsServiceRequestVM Page
        {
            get => _page;
            set => this.RaiseAndSetIfChanged(ref _page, value);
        }

        [Reactive] public ObservableCollection<EmployeModel> Responsibles { get; set; } = new();
        [Reactive] public ObservableCollection<EmployeModel> SystemAdministrations { get; set; } = new();
        [Reactive] public EmployeModel? SelectedResponsible { get; set; }
        [Reactive] public EmployeModel? SelectedSystemAdministrator { get; set; }
        [Reactive] public DateTime? SelectedDate { get; set; }
        [Reactive] public DateTime? SelectedStartDate { get; set; }
        [Reactive] public DateTime? SelectedEndDate { get; set; }

        private SourceCache<EquipmentsServiceRequestVM, Guid> _sourceCache = new(x => x.ID);


        [Reactive] public int? SelectedPageSize { get; set; }
        public List<int> PageSizes { get; } = new()
        {
            5,10,20,50,
        };
        private ReadOnlyObservableCollection<EquipmentsServiceRequestVM> _requests;
        public ReadOnlyObservableCollection<EquipmentsServiceRequestVM> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }
        #endregion
    }
}
