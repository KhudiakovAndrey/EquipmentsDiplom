using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class HealthService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public HealthService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<bool> CheckServerStatusAsync()
        {
            var responce = await GetAsync<object>(_appConfiguration.WebApiUrl + _appConfiguration.HealthEndpoint);
            return responce.IsSucces;
        }
    }
}
