using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class EquipmentPurchaseRequestService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;
        public EquipmentPurchaseRequestService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<PurchaseRequestList>> GetAllAsync()
        {
            var response = await GetAsync<PurchaseRequestList>(_appConfiguration.PurchaseRequestsEndpoint);
            return response;
        }
    }
}
