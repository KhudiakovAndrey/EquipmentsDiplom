using Avalonia.Controls;
using Avalonia.Styling;
using Equipments.AvaloniaUI.Views;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;


namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainAuthViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        [Reactive]
        public UserControl SelectedView { get; set; } = new AuthorizationView();

        public MainAuthViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            ShowRegistrationViewCommand = ReactiveCommand.Create(ShowRegistrationView);
            ShowAuthorizationViewCommand = ReactiveCommand.Create(ShowAuthorizationView);
            ChangeThemeCommand = ReactiveCommand.Create(ChangeTheme);

        }
        public async void ShowDialog()
        {
            await _dialogService.ShowDialogHostAsync(
                   this,
                   new DialogHostSettings("Hello world!")
                   {
                       CloseOnClickAway = true,

                   });
        }
        public ReactiveCommand<Unit, Unit> ChangeThemeCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ShowRegistrationViewCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ShowAuthorizationViewCommand { get; private set; }
        public void ChangeTheme()
        {
            var actualTheme = App.Current!.ActualThemeVariant;
            if (actualTheme == ThemeVariant.Dark)
                App.Current!.RequestedThemeVariant = ThemeVariant.Light;
            else
                App.Current!.RequestedThemeVariant = ThemeVariant.Dark;
        }
        public void ShowRegistrationView() => SelectedView = new RegistrationView();
        public void ShowAuthorizationView() => SelectedView = new AuthorizationView();
        public void ShowConfirmEmailView(string email) => SelectedView = new ConfirmEmailView(email);
    }
}

