using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive;
using Avalonia.Controls.Primitives;
using Equipments.AvaloniaUI.Views;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Disposables;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainMenuViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();
        private readonly IDialogService _dialogService;
        [Reactive] public RoutableViewModelBase? SelectedViewModel { get; set; }
        public MainMenuViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            ShowEquipmentsServiceRequestView();

            Router.CurrentViewModel.Subscribe(view =>
            {
                SelectedViewModel = (RoutableViewModelBase?)view;
            });
        }
        public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack!;
        public void ShowCreateServiceRequestView() =>
            Router.Navigate.Execute(App.ServiceProvider!.GetService<CreateServiceRequestViewModel>()!);
        public void ShowEquipmentsServiceRequestView() =>
            NaviageIgnoreCopyUrl(App.ServiceProvider!.GetService<EquipmentsServiceRequestViewModel>()!);

        public void ShowEquipmentPurchaseRequestView() =>
            NaviageIgnoreCopyUrl(App.ServiceProvider!.GetService<EquipmentPurchaseRequestViewModel>()!);

        private void NaviageIgnoreCopyUrl(IRoutableViewModel vm)
        {
            Router.NavigationStack.Clear();
            if (Router.NavigationStack.Any(rout => rout.UrlPathSegment == vm.UrlPathSegment))
                return;
            Router.Navigate.Execute(vm);
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

        public async Task<bool> ShowAskQuestionDialogAsync(string message, string? title = null)
        {
            bool result = await _dialogService.AskQuestionAsync(this, message, title);
            return result;
        }
    }
}
