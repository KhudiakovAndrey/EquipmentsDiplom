using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI
{
    public class AppConfiguration
    {
        public string IdentityUrl { get; set; } = string.Empty;
        public string AuthEndpoint { get; set; } = string.Empty;
        public string WebApiUrl { get; set; } = string.Empty;
        public string HealthEndpoint { get; set; } = string.Empty;
    }
}
