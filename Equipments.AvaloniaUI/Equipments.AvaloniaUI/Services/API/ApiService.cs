using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using System;
using System.Linq;

namespace Equipments.AvaloniaUI.Services.API
{
    public class ApiService : ApiClient
    {
        public ApiService(string baseAddress) : base(baseAddress)
        {

        }
        public ApiService(string baseAddress, SettingsDbContext settingsDbContext)
            : base(baseAddress,
                  settingsDbContext.Settings.First().AccessToken ?? string.Empty)
        {


        }

    }
}
