using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Factory;
using Equipments.AvaloniaUI.Factorys;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Equipments.AvaloniaUI.Views;
using HanumanInstitute.MvvmDialogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainMenuViewModel : ViewModelBase, IScreen
    {
        private readonly ICreateServiceRequestViewModelFactory _createServiceRequestViewModelFactory;
        private readonly IEditEquipmentPurchaseRequestViewModelFactory _purchaseRequestViewModelFactory;
        private readonly EmployeesService _employeesService;
        private readonly UserService _userService;
        private readonly MainMenuWindowViewModel _ownerVM;
        private readonly SettingsDbContext _settingsDbContext;
        [Reactive] public RoutableViewModelBase? SelectedViewModel { get; set; }
        public RoutingState Router { get; } = new RoutingState();
        public MainMenuViewModel(ICreateServiceRequestViewModelFactory createServiceRequestViewModelFactory,
            IEditEquipmentPurchaseRequestViewModelFactory purchaseRequestViewModelFactory,
            EmployeesService employeesService,
            UserService userService,
            MainMenuWindowViewModel ownerVM,
            SettingsDbContext settingsDbContext)
        {
            _createServiceRequestViewModelFactory = createServiceRequestViewModelFactory;
            _purchaseRequestViewModelFactory = purchaseRequestViewModelFactory;
            _employeesService = employeesService;
            _userService = userService;
            _ownerVM = ownerVM;
            _settingsDbContext = settingsDbContext;
        }
        public async void Initialize()
        {
            ShowEquipmentsServiceRequestView();
            User = await GetMyUser();
            IsDarkTheme = App.Current!.RequestedThemeVariant == ThemeVariant.Dark;
            ChangeThemeCommand = ReactiveCommand.Create(ChangeTheme);
            Router.CurrentViewModel.Subscribe(view =>
            {
                SelectedViewModel = (RoutableViewModelBase?)view;
            });

        }
        private async Task<UserModel> GetMyUser()
        {
            var resultMyUser = await _userService.GetMeUser();
            if (resultMyUser.IsSucces)
            {
                var resultMyEmploye = await _employeesService.GetMeEmploye();
                if (resultMyEmploye.IsSucces)
                {
                    resultMyUser.Data.Employe = resultMyEmploye.Data;
                    return resultMyUser.Data;
                }
            }
            return null;
        }
        public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack!;
        public void ShowCreateServiceRequestView(Guid? idRequest = null) =>
            Router.Navigate.Execute(_createServiceRequestViewModelFactory.Create(idRequest ?? Guid.Empty));
        public void ShowEquipmentsServiceRequestView() =>
            NaviageIgnoreCopyUrl(App.ServiceProvider!.GetService<EquipmentsServiceRequestViewModel>()!);
        public void ShowEquipmentPurchaseRequestView() =>
            NaviageIgnoreCopyUrl(App.ServiceProvider!.GetService<EquipmentPurchaseRequestViewModel>()!);
        public void ShowDashboardView() =>
            NaviageIgnoreCopyUrl(new DashboardViewModel());
        public void ShowEditEquipmentPurchaseRequestView(Guid? id) =>
            Router.Navigate.Execute(_purchaseRequestViewModelFactory.Create(id ?? Guid.Empty));

        private ReactiveCommand<Unit, Unit>? _exitApp;
        public ReactiveCommand<Unit, Unit> ExitApp => _exitApp ??= ReactiveCommand.CreateFromTask(ExitAppActionAsync);
        private async Task ExitAppActionAsync()
        {
            var result = await _ownerVM.ShowAskQuestionDialogAsync("Вы уверены что хотите выйти из своего профиля? (Вам придётся снова авторизироваться)", "Выход");
            if (result == true
               && App.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
               && desktop.MainWindow is MainMenuWindow mainMenuWindow)
            {
                var settings = await _settingsDbContext.Settings.FirstAsync();
                if (settings != null)
                {
                    settings.AccessToken = null;
                    await _settingsDbContext.SaveChangesAsync();

                    mainMenuWindow.ShowAuthView();
                }
            }
        }

        [Reactive] public bool IsDarkTheme { get; set; }
        public ReactiveCommand<Unit, Unit> ChangeThemeCommand { get; private set; }
        private void ChangeTheme()
        {
            App.Current!.RequestedThemeVariant = App.Current.RequestedThemeVariant == ThemeVariant.Dark ? ThemeVariant.Light : ThemeVariant.Dark;
            IsDarkTheme = !IsDarkTheme;
        }
        private void NaviageIgnoreCopyUrl(IRoutableViewModel vm)
        {
            Router.NavigationStack.Clear();
            if (Router.NavigationStack.Any(rout => rout.UrlPathSegment == vm.UrlPathSegment))
                return;
            Router.Navigate.Execute(vm);
        }

        [Reactive] public UserModel User { get; set; }

    }
}
