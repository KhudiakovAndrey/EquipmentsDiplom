using System;

namespace Equipments.AvaloniaUI
{
    public class AppConfiguration
    {
        public string IdentityUrl { get; set; } = string.Empty;
        public string AuthEndpoint { get; set; } = string.Empty;
        public string WebApiUrl { get; set; } = string.Empty;
        public string HealthEndpoint { get; set; } = string.Empty;

        public static string AccesToken { get; set; } = string.Empty;
        public static DateTime? ExpirationToken { get; set; }

    }
}
