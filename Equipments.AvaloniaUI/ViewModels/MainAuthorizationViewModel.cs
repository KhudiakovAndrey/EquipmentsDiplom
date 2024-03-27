using Avalonia.Controls;
using Avalonia.Styling;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainAuthorizationViewModel : ViewModelBase
    {
        [Reactive]
        public UserControl SelectedView { get; set; }
        [Reactive]
        public ObservableCollection<UserControl> Views { get; set; } = new()
        {
            new AuthorizationView(),
            new RegistrationView()
        };
        public ReactiveCommand<Unit, Unit> ChangeThemeCommand { get; private set; }
        public MainAuthorizationViewModel()
        {
            ChangeThemeCommand = ReactiveCommand.Create(() =>
            {
                var actualTheme = App.Current!.ActualThemeVariant;
                if (actualTheme == ThemeVariant.Dark)
                    App.Current!.RequestedThemeVariant = ThemeVariant.Light;
                else
                    App.Current!.RequestedThemeVariant = ThemeVariant.Dark;
            });
        }

        public void ShowRegistrationView() => SelectedView = Views[1];
        public void ShowAuthorizationView() => SelectedView = Views[0];
    }
}
