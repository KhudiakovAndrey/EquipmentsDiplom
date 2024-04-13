using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class RequestStatusChangesService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;
        public RequestStatusChangesService(AppConfiguration appConfiguration)
            : base(appConfiguration.RequestStatusChangesEndpoint)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<ApiResponse<object>> DeleteByiDAsync(int id)
        {
            var response = await DeleteAsync<object>(_appConfiguration.RequestStatusChangesEndpoint + "/" + id.ToString());
            return response;
        }

        public async Task<ApiResponse<int>> CreateAsync(CreateRequestStatusChangeModel model)
        {
            var response = await PostAsync<int>(_appConfiguration.RequestStatusChangesEndpoint, model);
            return response;
        }

        public async Task<ApiResponse<object>> UpdateAsync(UpdateRequestStatusChangeModel model)
        {
            var response = await PutAsync<object>(_appConfiguration.RequestStatusChangesEndpoint, model);
            return response;
        }
    }
}
