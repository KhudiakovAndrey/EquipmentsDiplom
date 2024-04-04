using Avalonia.Controls;
using Avalonia.Styling;
using Equipments.AvaloniaUI.Views;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
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
        public void ShowRegistrationView()
        {
            SelectedView = new RegistrationView();
            var vm = SelectedView.DataContext as RegistrationViewModel;
            vm!.SuccessfulRegistration += RegistrationViewModel_SuccessfulRegistration;
            vm.FailedRegistraion += async (s, error) => await ShowDialogHostAsync(error);
        }

        private void RegistrationViewModel_SuccessfulRegistration(object? sender, Models.RegViewModel e) => ShowConfirmEmailView(e.Email);
        public void ShowAuthorizationView() => SelectedView = new AuthorizationView();
        public void ShowConfirmEmailView(string email)
        {
            SelectedView = new ConfirmEmailView(email);
            var vm = SelectedView.DataContext as ConfirmEmailViewModel;
            vm!.OnError += async (s, err) => await ShowDialogHostAsync(err);
        }

        public async Task ShowDialogHostAsync(string message)
        {
            await _dialogService.ShowDialogHostAsync(
                    this,
                    new DialogHostSettings(message)
                    {
                        CloseOnClickAway = true
                    }).ConfigureAwait(true);
        }
    }
}

