﻿using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.ViewModels;
using Equipments.AvaloniaUI.Views;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace Equipments.AvaloniaUI;

public partial class App : Application
{
    public static ServiceProvider? ServiceProvider { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        var services = new ServiceCollection();

        //Добавляем базу данных для настроек
        services.AddData("Data Source=D:\\dev\\Equipments\\Equipments.AvaloniaUI\\Equipments.AvaloniaUI\\settings.db");

        //Добавляем сервис для диалогово в MVVM
        services.AddSingleton<IDialogService>(new DialogService(
            new DialogManager(
                viewLocator: new ViewLocator(),
                dialogFactory: new DialogFactory().AddDialogHost().AddMessageBox()),
            viewModelFactory: x => ServiceProvider!.GetRequiredService(x))
        );

        //Добавляем все ViewModels
        services.AddViewModels();

        var apiConfiguration = LoadConfiguration();
        services.AddSingleton(apiConfiguration);


        ServiceProvider = services.BuildServiceProvider();
        DbInitializer.Initialize(ServiceProvider!.GetRequiredService<SettingsDbContext>());
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainAuthView();
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
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