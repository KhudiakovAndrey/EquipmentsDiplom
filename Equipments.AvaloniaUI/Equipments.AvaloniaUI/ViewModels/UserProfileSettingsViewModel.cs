using System;
using System.Collections.Generic;
using Avalonia.Styling;
using Equipments.AvaloniaUI.Data;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class UserProfileSettingsViewModel : ViewModelBase
    {
        private readonly SettingsDbContext _settingsDbContext;

        public UserProfileSettingsViewModel(SettingsDbContext settingsDbContext)
        {
            _settingsDbContext = settingsDbContext;
        }

        public void ChangeTheme(string theme)
        {
            ThemeVariant themeVariant = theme switch
            {
                "Light" => ThemeVariant.Light,
                "Dark" => ThemeVariant.Dark,
                "Default" => ThemeVariant.Default,
                _ => ThemeVariant.Default,
            };

            App.Current.RequestedThemeVariant = themeVariant;


        }
    }
}