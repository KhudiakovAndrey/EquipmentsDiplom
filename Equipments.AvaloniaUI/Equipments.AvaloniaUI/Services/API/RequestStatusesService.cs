using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class RequestStatusesService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public RequestStatusesService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<List<RequestStatusModel>>> GetAll()
        {
            var response = await GetAsync<List<RequestStatusModel>>(_appConfiguration.RequestStatusesEndpoint);
            return response;
        }
    }
}
