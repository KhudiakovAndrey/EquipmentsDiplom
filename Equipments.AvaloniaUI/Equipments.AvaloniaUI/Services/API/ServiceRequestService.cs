using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class ServiceRequestService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public ServiceRequestService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            AccessToken = AppConfiguration.AccesToken;
            _appConfiguration = appConfiguration;
        }

        public async Task<ApiResponse<PaginationEquipmentsServiceRequestVM>> GetPageServiceRequests(GetPageServiceRequestQuery query)
        {
            var response = await GetAsync<PaginationEquipmentsServiceRequestVM>(
                _appConfiguration.ServiceRequestsEndpoint + "/page",
                query);
            return response;
        }

        public async Task<ApiResponse<Guid>> CreateServiceRequest(CreateServiceRequestModel body)
        {
            var response = await PostAsync<Guid>(_appConfiguration.ServiceRequestsEndpoint, body);
            return response;
        }

        public async Task<ApiResponse<object>> DeleteServiceRequest(Guid id)
        {
            var response = await DeleteAsync<object>(_appConfiguration.ServiceRequestsEndpoint + "/" + id.ToString());
            return response;
        }

        public async Task<ApiResponse<DetailedEquipmentServiceRequestVm>> GetDetailedServiceRequest(Guid id)
        {
            var response = await GetAsync<DetailedEquipmentServiceRequestVm>(_appConfiguration.ServiceRequestsEndpoint + "/" + id);
            return response;
        }
    }
}
