﻿using System;

namespace Equipments.AvaloniaUI.Resources
{
    public class AppConfiguration
    {
        public string IdentityUrl { get; set; } = string.Empty;
        public string AuthEndpoint { get; set; } = string.Empty;
        public string WebApiUrl { get; set; } = string.Empty;
        public string HealthEndpoint { get; set; } = string.Empty;
        public string ServiceRequestsEndpoint { get; set; } = string.Empty;
        public string EmployeesEndpoint { get; set; } = string.Empty;
        public string EquipmentTypesEndpoint { get; set; } = string.Empty;
        public string ProblemTypesEndpoint { get; set; } = string.Empty;
        public string RequestStatusChangesEndpoint { get; set; } = string.Empty;
        public string RequestStatusesEndpoint { get; set; } = string.Empty;

        public static string AccesToken { get; set; } = string.Empty;
        public static DateTime? ExpirationToken { get; set; }

    }
}