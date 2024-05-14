using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Platform;
using Equipments.AvaloniaUI.Resources;
using Equipments.AvaloniaUI.Services;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetService<MainMenuWindowViewModel>();
            DataContext = vm;
        }


        public void ShowAuthView()
        {
            var content = new MainAuthView();
            this.Content = content;
        }
        public void ShowMainMenu()
        {
            var content = new MainMenuView();
            var vm = content.DataContext as MainMenuViewModel;
            this.Content = content;
            vm?.Initialize();

        }
    }
}
