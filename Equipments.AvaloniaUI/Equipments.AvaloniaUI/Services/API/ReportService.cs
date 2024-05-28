using Equipments.Api;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class ReportService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public ReportService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<byte[]>> GenerateServiceRequestDetailsReport(Guid id)
        {
            var response = await GetAsync<byte[]>(_appConfiguration.ReportsEndpoint + $"/service-request-details/{id}");
            return response;
        }

    }
}
