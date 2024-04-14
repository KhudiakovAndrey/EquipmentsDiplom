using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.ViewModels;
using System;

namespace Equipments.AvaloniaUI.Factorys
{
    public class CreateServiceRequestViewModelFactory : ICreateServiceRequestViewModelFactory
    {
        private readonly EmployeesService _employService;
        private readonly ProblemTypeService _problemTypeService;
        private readonly ServiceRequestService _serviceRequestService;
        private readonly RequestStatusChangesService _requestStatusChangesService;

        public CreateServiceRequestViewModelFactory(EmployeesService employService,
            ProblemTypeService problemTypeService,
            ServiceRequestService serviceRequestService,
            RequestStatusChangesService requestStatusChangesService)
        {
            _employService = employService;
            _problemTypeService = problemTypeService;
            _serviceRequestService = serviceRequestService;
            _requestStatusChangesService = requestStatusChangesService;
        }

        public CreateServiceRequestViewModel Create(Guid idParam)
        {
            return new CreateServiceRequestViewModel(_employService,
                _problemTypeService,
                _serviceRequestService,
                idParam,
                _requestStatusChangesService);
        }
    }
}
