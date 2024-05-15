
using Avalonia.Controls.ApplicationLifetimes;
using Equipments.AvaloniaUI;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

public static class TokenExpiredEventHandler
{
    private static readonly List<ApiService> _apiServices = new();
    public static void RegisterApiService(ApiService apiService)
    {
        _apiServices.Add(apiService);
        apiService.TokenExpired += OnTokenExpired;
    }
    public static void UnRegisterApiService(ApiService apiService)
    {
        _apiServices.Remove(apiService);
        apiService.TokenExpired -= OnTokenExpired;
    }
    private static void OnTokenExpired(object? sender, EventArgs e)
    {
        if (App.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (desktop.MainWindow is MainMenuWindow mainMenuWindow)
            {
                var settingsDb = App.ServiceProvider!.GetService<SettingsDbContext>();
                var settings = settingsDb?.Settings.First();
                if (settings != null)
                {
                    settings.AccessToken = null;
                    settingsDb?.Update(settings);
                    settingsDb?.SaveChangesAsync();
                }
                var content = new MainAuthView();
                mainMenuWindow.Content = content;
            }
        }
    }
}
