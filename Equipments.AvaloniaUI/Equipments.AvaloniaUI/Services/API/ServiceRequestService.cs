using Avalonia.Diagnostics;
using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Equipments.AvaloniaUI.Services.API
{
    public class ServiceRequestService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public ServiceRequestService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<PaginationEquipmentsServiceRequestVM>> GetPageServiceRequests(GetPageServiceRequestQuery query)
        {
            var response = await PostAsync<PaginationEquipmentsServiceRequestVM>(
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

        public async Task<ApiResponse<object>> UpdateAsync(UpdateEquipmentServiceRequestModel body)
        {
            var response = await PutAsync<object>(_appConfiguration.ServiceRequestsEndpoint, body);
            return response;
        }

        public async Task<ApiResponse<DetailedEquipmentServiceRequestVm>> GetDetailedServiceRequest(Guid id)
        {
            var response = await GetAsync<DetailedEquipmentServiceRequestVm>(_appConfiguration.ServiceRequestsEndpoint + "/" + id);
            return response;
        }

        public async Task<ApiResponse<int>> GetCountCreatedByUserAsync()
        {
            var response = await GetAsync<int>(_appConfiguration.ServiceRequestsEndpoint + "/" + "dashboard/createdCount");
            return response;
        }
        public async Task<ApiResponse<double>> GetAvgCreatedByUserAsync()
        {
            var response = await GetAsync<double>(_appConfiguration.ServiceRequestsEndpoint + "/" + "dashboard/avgCreatedCount");
            return response;
        }
        public async Task<ApiResponse<IEnumerable<ServiceRequestPrevMonth>>> GetAllPrevMonth()
        {
            var response = await GetAsync<IEnumerable<ServiceRequestPrevMonth>>(_appConfiguration.ServiceRequestsEndpoint + "/" + "services-prev-month");
            return response;
        }
        public async Task<ApiResponse<List<RequestCountDateModel>>> GetCountCreatedByDate(DateTime startDate, DateTime endDate, CountDatePeriodModel period)
        {
            NameValueCollection queryStrig = HttpUtility.ParseQueryString(string.Empty);
            queryStrig.Add("startDate", startDate.ToString("yyyy-MM-dd"));
            queryStrig.Add("endDate", endDate.ToString("yyyy-MM-dd"));
            queryStrig.Add("period", period.ToString());

            var response = await GetAsync<List<RequestCountDateModel>>($"{_appConfiguration.ServiceRequestsEndpoint}/dashboard/countCreatedDate?"
                + queryStrig.ToString());
            return response;
        }
    }
}
