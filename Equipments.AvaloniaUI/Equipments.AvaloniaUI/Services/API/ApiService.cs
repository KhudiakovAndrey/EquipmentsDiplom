﻿using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Linq;

namespace Equipments.AvaloniaUI.Services.API
{
    public class ApiService : ApiClient
    {
        public ApiService(string baseAddress)
            : base(baseAddress,
                  JwtTokenData.AccessToken)
        {


        }

    }
}
