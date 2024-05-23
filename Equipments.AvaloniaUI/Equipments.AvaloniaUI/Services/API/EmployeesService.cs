using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class EmployeesService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public EmployeesService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<List<EmployeModel>>> GetEmployees()
        {
            var response = await GetAsync<List<EmployeModel>>(_appConfiguration.EmployeesEndpoint);
            return response;
        }
        public async Task<ApiResponse<FullEmployeModel>> GetMeEmploye()
        {
            var response = await GetAsync<FullEmployeModel>(_appConfiguration.EmployeesEndpoint + "/me");
            return response;
        }
    }
}
