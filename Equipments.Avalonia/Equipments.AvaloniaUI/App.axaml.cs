using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.ViewModels;
using Equipments.AvaloniaUI.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Equipments.AvaloniaUI;

public partial class App : Application
{
    public override async void Initialize()
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppSettingsContext>(options =>
        {
            options.UseSqlite("Data Source=settings.db");
        });


        var serviceProvider = services.BuildServiceProvider();

        var settingContext = serviceProvider.GetService<AppSettingsContext>();
        var settings = await settingContext!.Settings.FirstOrDefaultAsync();

        if (settings != null)
        {
            //if (Enum.TryParse(settings.Theme, out ThemeVariant? theme))
            //{
                string line = ThemeVariant.Dark.Key.ToString();
            //    this.RequestedThemeVariant = theme;
            //}
        }

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        
        base.OnFrameworkInitializationCompleted();
    }
}
