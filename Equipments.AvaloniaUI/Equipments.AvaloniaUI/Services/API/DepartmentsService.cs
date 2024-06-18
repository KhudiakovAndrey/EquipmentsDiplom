using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class DepartmentsService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public DepartmentsService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<IEnumerable<DepartmentModel>>> GetAll()
        {
            var response = await GetAsync<IEnumerable<DepartmentModel>>(_appConfiguration.DepartmentsEndpoint);
            return response;

        }

    }
}
