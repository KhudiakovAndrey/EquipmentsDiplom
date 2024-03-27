using Avalonia.Animation;
using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainAuthorizationWindow : Window
    {
        public MainAuthorizationWindow()
        {
            InitializeComponent();
            var viewModel = App.ServiceProvider!.GetRequiredService<MainAuthorizationViewModel>();
            DataContext = viewModel;
            Carousel carousel = new Carousel();
        }
    }
}
