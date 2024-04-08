using Avalonia.Styling;
using System;

namespace Equipments.AvaloniaUI.Data
{
    public class AppSettings
    {
        public int Id { get; set; }
        public string? Theme { get; set; } = ThemeVariant.Light.ToString();
        public string LogLevel { get; set; } = "Test";
        public string? AccessToken { get; set; }
        public DateTime? ExpirationToken { get; set; }
        public ThemeVariant GetThemeVariant() => Theme switch
        {
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            "Default" => ThemeVariant.Default,
            _ => ThemeVariant.Default,
        };
    }
}
