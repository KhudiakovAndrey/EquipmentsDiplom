﻿using Equipments.Api;
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

        public HealthService(AppConfiguration appConfiguration, HttpClient client) : base(client)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<bool> CheckServerStatusAsync()
        {
            var responce = await SendRequestAsync(HttpMethod.Get, _appConfiguration.WebApiUrl + _appConfiguration.HealthEndpoint);
            return responce.IsSuccessStatusCode;
        }
    }
}