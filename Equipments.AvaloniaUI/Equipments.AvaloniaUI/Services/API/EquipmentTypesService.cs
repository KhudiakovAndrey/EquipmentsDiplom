using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class EquipmentTypesService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public EquipmentTypesService(AppConfiguration appConfiguration, SettingsDbContext settingsDbContext)
            : base(appConfiguration.WebApiUrl, settingsDbContext)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<List<EquipmentTypeModel>>> GetEquipmentTypes()
        {
            var response = await GetAsync<List<EquipmentTypeModel>>(_appConfiguration.EquipmentTypesEndpoint);
            return response;
        }
    }
}
