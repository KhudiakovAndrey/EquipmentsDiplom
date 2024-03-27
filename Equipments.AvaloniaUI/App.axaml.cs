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
using System.Linq;

namespace Equipments.AvaloniaUI;

public partial class App : Application
{
    public static ServiceProvider? ServiceProvider { get; private set; }
    public override void Initialize()
    {
        var services = new ServiceCollection();

        services.AddData("Data Source=D:\\dev\\Equipments\\Equipments.Avalonia\\Equipments.AvaloniaUI\\settings.db");

        //Регистрируем все ViewModels
        services.Scan(scan => scan
            .FromAssemblyOf<MainAuthorizationViewModel>()
            .AddClasses(classes => classes.AssignableTo<ViewModelBase>())
            .AsSelf()
            .WithTransientLifetime());

        //Регистрируем все Windows
        services.Scan(scan => scan
            .FromAssemblyOf<MainAuthorizationWindow>()
            .AddClasses(classes => classes.AssignableTo<Window>())
            .AsSelf()
            .WithTransientLifetime());

        //Регистрируем все UserControls...

        ServiceProvider = services.BuildServiceProvider();

        var settingsContext = ServiceProvider.GetRequiredService<SettingsDbContext>();
        DbInitializer.Initialize(settingsContext);

        var settings = settingsContext!.Settings.FirstOrDefault();
        if (settings != null)
        {
            ThemeVariant theme = settings.GetThemeVariant();
        }

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = ServiceProvider!.GetRequiredService<MainAuthorizationWindow>();
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
