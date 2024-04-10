using Equipments.Api;
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
        }

        public async Task<ApiResponse<List<EmployeModel>>> GetEmployees()
        {
            var response = await GetAsync<List<EmployeModel>>(_appConfiguration.EmployeesEndpoint);
            return response;
        }
    }
}
