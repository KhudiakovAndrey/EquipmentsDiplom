using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.ViewModels;
using Equipments.AvaloniaUI.Views;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Equipments.AvaloniaUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        var services = new ServiceCollection();

        //Добавляем базу данных для настроек
        services.AddData("Data Source=settings.db");

        //Добавляем сервис для диалогово в MVVM
        services.AddSingleton<IDialogService>(new DialogService(
            new DialogManager(
                viewLocator: new ViewLocator(),
                dialogFactory: new DialogFactory().AddDialogHost().AddMessageBox()),
            viewModelFactory: x => ServiceProvider!.GetRequiredService(x))
        );

        //Добавляем все ViewModels
        services.AddViewModels();

        //Загружаем конфиги
        var apiConfiguration = LoadConfiguration();
        services.AddSingleton(apiConfiguration);

        //Загружаем сервисы для работы с апи
        services.AddApiServices(apiConfiguration);

        ServiceProvider = services.BuildServiceProvider();

        //Инициализируем БД
        DbInitializer.Initialize(ServiceProvider!.GetRequiredService<SettingsDbContext>());
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var settingsDbContext = ServiceProvider?.GetService<SettingsDbContext>();

            var settings = SettingsDbContext?.Settings.First();
            if (settings?.AccessToken != null && settings?.ExpirationToken!.Value > DateTime.Now)
            {
                AppConfiguration.AccesToken = settings.AccessToken!;
                AppConfiguration.ExpirationToken = settings.ExpirationToken;

                var mainMenuWindow = new MainMenuWindow();
                desktop.MainWindow = mainMenuWindow;
            }
            else
            {
                var authWindow = new MainAuthView();
                desktop.MainWindow = authWindow;
                authWindow.Closing += (s, e) =>
                {
                    var mainMenuWindow = new MainMenuWindow();
                    desktop.MainWindow = mainMenuWindow;

                    mainMenuWindow.Show();
                };
            }
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void AuthWindow_Closed(object? sender, System.EventArgs e)
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainMenuWindow = new MainMenuWindow();
            desktop.MainWindow = mainMenuWindow;

            mainMenuWindow.Show();

            (sender as Window)?.Close();
        }
    }

    public static ServiceProvider? ServiceProvider { get; private set; }
    public static MainAuthViewModel? MainAuthVM => ServiceProvider!.GetService<MainAuthViewModel>();
    public static SettingsDbContext? SettingsDbContext => ServiceProvider?.GetService<SettingsDbContext>();
    private AppConfiguration LoadConfiguration()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "Equipments.AvaloniaUI.Resources.appconfig.json";

        using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
        using StreamReader reader = new StreamReader(stream);
        string json = reader.ReadToEnd();

        var configuration = JsonConvert.DeserializeObject<AppConfiguration>(json);
        return configuration ?? new AppConfiguration();
    }
}
