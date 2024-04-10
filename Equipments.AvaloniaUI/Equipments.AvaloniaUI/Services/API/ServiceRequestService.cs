using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
