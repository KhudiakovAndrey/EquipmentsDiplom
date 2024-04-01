using Equipments.Api;
using Equipments.AvaloniaUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class RegistrationService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public RegistrationService(AppConfiguration appConfiguration) : base(appConfiguration.IdentityUrl)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<ApiResponse<object>> RegistrationUserAsync(RegistrationModel model)
        {
            var response = await PostAsync<object>(_appConfiguration.AuthEndpoint, model);
            return response;
        }
    }
}
