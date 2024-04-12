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

        public CreateServiceRequestViewModelFactory(EmployeesService employService,
            ProblemTypeService problemTypeService,
            ServiceRequestService serviceRequestService)
        {
            _employService = employService;
            _problemTypeService = problemTypeService;
            _serviceRequestService = serviceRequestService;
        }

        public CreateServiceRequestViewModel Create(Guid idParam)
        {
            return new CreateServiceRequestViewModel(_employService,
                _problemTypeService,
                _serviceRequestService,
                idParam);
        }
    }
}
