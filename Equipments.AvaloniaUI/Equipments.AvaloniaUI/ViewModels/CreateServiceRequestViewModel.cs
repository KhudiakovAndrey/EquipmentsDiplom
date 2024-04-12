using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.Services.Enums;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class CreateServiceRequestViewModel : RoutableViewModelBase
    {
        private readonly EmployeesService _employService;
        private readonly ProblemTypeService _problemTypeService;
        private readonly ServiceRequestService _serviceRequestService;
        private readonly Guid _idRequest;
        public CreateServiceRequestViewModel(EmployeesService employService,
            ProblemTypeService problemTypeService,
            ServiceRequestService serviceRequestService,
            Guid idRequest)
            : base(nameof(CreateServiceRequestViewModel).ToLowerInvariant())
        {
            _employService = employService;
            _problemTypeService = problemTypeService;
            _serviceRequestService = serviceRequestService;
            _idRequest = idRequest;

            Notify = NotifyTaskCompletion.Create(InitializeAsync);

            this.WhenAnyValue(vm => vm.SelectedEquipmentType).Subscribe(_ =>
            {
                var types = _problemTypes?.Where(p => p.EquipmentType == SelectedEquipmentType).Select(p => p.Description);
                ProblemTypesInEquipment = new ObservableCollection<string>(types ?? Enumerable.Empty<string>());
            });

            var isExecuteCreateRequestCommand = this.WhenAnyValue(
                vm => vm.SelectedResponsible,
                vm => vm.SelectedSystemAdministration,
                vm => vm.SelectedEquipmentType,
                vm => vm.SelectedProblemType,
                vm => vm.DetailedDescription,
                vm => vm.BrokenEquipmentDescription,
                (response, sys, eqType, probType, detailed, eqDescription) =>
                response != null && sys != null && !string.IsNullOrEmpty(eqType)
                && !string.IsNullOrEmpty(probType) && !string.IsNullOrWhiteSpace(detailed)
                && !string.IsNullOrWhiteSpace(eqDescription));
            CreateRequestCommand = ReactiveCommand.CreateFromTask(CreateRequest, isExecuteCreateRequestCommand);



        }
        private async Task InitializeAsync()
        {
            await GetAllEmployees();
            await GetAllProblemTypes();
            if (_idRequest != Guid.Empty)
            {
                await GetServiceRequestDetailed(_idRequest);
                Title = "Заяка";
                NumberRequest = "№" + _idRequest;
                InputText = "Сохранить изменения";
                return;
            }
            Title = "Создание заявки на обслуживание оборудования";
            InputText = "Подать заявку";
        }
        public ReactiveCommand<Unit, Unit> CreateRequestCommand { get; private set; }
        public async Task CreateRequest()
        {
            var createServiceRequest = new CreateServiceRequestModel
            {
                IDResponsible = SelectedResponsible.ID,
                IDSystemAdministrator = SelectedSystemAdministration.ID,
                EquipmentType = SelectedEquipmentType!,
                ProblemType = SelectedProblemType!,
                DetailedDescription = this.DetailedDescription,
                BrokenEquipmentDescription = this.BrokenEquipmentDescription
            };

            var response = await _serviceRequestService.CreateServiceRequest(createServiceRequest);
            if (response.IsSucces)
            {
                await App.MainMenuVM.ShowDialogHostAsync("Заявка успешно создана! В данный момент она находится в обработке")!;
            }
            else
            {
                await App.MainMenuVM.ShowDialogHostAsync("Произошла ошибка во время создания заявки, повторите попытку позже");
            }
        }
        private async Task GetAllEmployees()
        {
            var response = await _employService.GetEmployees();
            if (response.IsSucces)
            {
                Responsibles = new ObservableCollection<EmployeModel>(response.Data.Where(em => em.RoleID == (int)Roles.Responsible));
                SystemAdministration = new ObservableCollection<EmployeModel>(response.Data.Where(em => em.RoleID == (int)Roles.SystemAdministration));
            }
        }
        private async Task GetAllProblemTypes()
        {
            var response = await _problemTypeService.GetProblemTypes();
            if (response.IsSucces)
            {
                _problemTypes = response.Data;
                EquipmentTypes = new ObservableCollection<string>(_problemTypes.Select(problem => problem.EquipmentType).Distinct());
            }
        }
        private async Task GetServiceRequestDetailed(Guid id)
        {
            var response = await _serviceRequestService.GetDetailedServiceRequest(id);
            if (response.IsSucces)
            {
                SelectedSystemAdministration = response.Data.SystemAdministrator;
                SelectedResponsible = response.Data.Responsible;
                SelectedEquipmentType = response.Data.ProblemType.EquipmentType;
                SelectedProblemType = response.Data.ProblemType.Description;
                DetailedDescription = response.Data.DetailedDescription;
                BrokenEquipmentDescription = response.Data.BrokenEquipmentDescription;
                Statuses = new ObservableCollection<RequestStatusModel>(response.Data.Statues);
            }
        }
        #region Properties
        [Reactive] public ObservableCollection<RequestStatusModel> Statuses { get; set; }
        [Reactive] public string NumberRequest { get; private set; }
        [Reactive] public string Title { get; set; } = string.Empty;
        [Reactive] public string InputText { get; set; } = string.Empty;
        [Reactive] public string DetailedDescription { get; set; } = string.Empty;
        [Reactive] public string BrokenEquipmentDescription { get; set; } = string.Empty;
        [Reactive] public ObservableCollection<EmployeModel> Responsibles { get; set; } = new();
        [Reactive] public ObservableCollection<EmployeModel> SystemAdministration { get; set; } = new();

        [Reactive] public EmployeModel SelectedResponsible { get; set; }
        [Reactive] public EmployeModel SelectedSystemAdministration { get; set; }

        [Reactive] public ObservableCollection<string> EquipmentTypes { get; set; } = new();
        [Reactive] public string? SelectedEquipmentType { get; set; }

        [Reactive] public ObservableCollection<string> ProblemTypesInEquipment { get; set; } = new();
        [Reactive] public string? SelectedProblemType { get; set; }

        private List<ProblemTypeDto> _problemTypes;
        #endregion
    }
}
