using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using AvaloniaWebView;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Factory;
using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.ViewModels;
using Equipments.AvaloniaUI.Views;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using IdentityModel.Client;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
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

        //Загружаем фабрики для создания ViewModel с параметрами
        services.AddFactory();
        //Добавляем все ViewModels
        services.AddViewModels();

        //Загружаем конфиги
        var apiConfiguration = LoadConfiguration();
        services.AddSingleton(apiConfiguration);

        //Загружаем сервисы для работы с апи
        services.AddApiServices();


        ServiceProvider = services.BuildServiceProvider();

        //Инициализируем БД
        DbInitializer.Initialize(ServiceProvider!.GetRequiredService<SettingsDbContext>());

        var settingsDbContext = ServiceProvider?.GetService<SettingsDbContext>();

        LiveCharts.Configure(config =>
        {
            if (settingsDbContext != null
            && settingsDbContext.Settings.FirstOrDefault()?.Theme != null)
            {
                if (settingsDbContext.Settings.First().Theme == ThemeVariant.Dark.ToString())
                {
                    config.AddDarkTheme();
                    App.Current!.RequestedThemeVariant = ThemeVariant.Dark;
                }
                else
                {
                    config.AddLightTheme();
                    App.Current!.RequestedThemeVariant = ThemeVariant.Light;
                }
            }
        });

    }

    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var settingsDbContext = ServiceProvider?.GetService<SettingsDbContext>();


            var settings = settingsDbContext?.Settings.First();

            if (settings?.AccessToken != null)
            {
                JwtTokenData.AccessToken = settings.AccessToken;
                var menuWindow = new MainMenuWindow();
                desktop.MainWindow = menuWindow;

                var content = menuWindow.Content as MainMenuView;
                var vm = content?.DataContext as MainMenuViewModel;
                vm?.Initialize();
            }
            else
            {
                var menuWindow = new MainMenuWindow();
                desktop.MainWindow = menuWindow;
                menuWindow.Content = new MainAuthView();
            }
        }

        base.OnFrameworkInitializationCompleted();
    }

    public override void RegisterServices()
    {
        base.RegisterServices();
        AvaloniaWebViewBuilder.Initialize(default);
    }

    public static ServiceProvider? ServiceProvider { get; private set; }
    public static MainAuthViewModel? MainAuthVM => ServiceProvider!.GetService<MainAuthViewModel>();
    public static MainMenuWindowViewModel MainMenuVM => ServiceProvider!.GetService<MainMenuWindowViewModel>()!;
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
