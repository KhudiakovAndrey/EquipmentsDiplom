using Avalonia.Styling;
using Equipments.AvaloniaUI.Data;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainAuthorizationViewModel : ViewModelBase
    {
        private readonly SettingsDbContext _settingsDbContext;
        public MainAuthorizationViewModel(SettingsDbContext settingsDbContext)
        {
            _settingsDbContext = settingsDbContext;
            ChangeThemeCommand = ReactiveCommand.Create(() =>
            {
                if (App.Current!.ActualThemeVariant == ThemeVariant.Dark)
                {
                    App.Current!.RequestedThemeVariant = ThemeVariant.Light;
                }
                else
                {
                    App.Current!.RequestedThemeVariant = ThemeVariant.Dark;
                }
            });
        }

        public ReactiveCommand<Unit, Unit> ChangeThemeCommand { get; }
    }
}
