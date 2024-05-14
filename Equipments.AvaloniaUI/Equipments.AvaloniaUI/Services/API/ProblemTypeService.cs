using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class ProblemTypeService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public ProblemTypeService(AppConfiguration appConfiguration, SettingsDbContext settingsDbContext)
            : base(appConfiguration.WebApiUrl, settingsDbContext)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<List<ProblemTypeDto>>> GetProblemTypes()
        {
            var response = await GetAsync<List<ProblemTypeDto>>(_appConfiguration.ProblemTypesEndpoint);
            return response;
        }
    }
}
