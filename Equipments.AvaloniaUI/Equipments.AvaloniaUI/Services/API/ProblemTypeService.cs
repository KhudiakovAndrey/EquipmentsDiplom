using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class ProblemTypeService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public ProblemTypeService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<ApiResponse<List<ProblemTypeDto>>> GetProblemTypes()
        {
            var response = await GetAsync<List<ProblemTypeDto>>(_appConfiguration.ProblemTypesEndpoint);
            return response;
        }
    }
}
