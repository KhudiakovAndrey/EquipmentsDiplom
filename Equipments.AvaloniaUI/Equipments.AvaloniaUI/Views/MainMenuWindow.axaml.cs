using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<MainMenuViewModel>();
            DataContext = vm;
            //DataGridRow row = new DataGridRow();
            //row.IsFocused = true;
        }
    }
}
