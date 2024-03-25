using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Data
{
    public class AppSettings
    {
        public int Id { get; set; }
        public string? Theme { get; set; } = ThemeVariant.Light.ToString();
        public string LogLevel { get; set; } = "Test";
        public string AccessToken { get; set; } = string.Empty;
    }
}
