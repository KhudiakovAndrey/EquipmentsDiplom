using Equipments.AvaloniaUI.Factorys;
using Equipments.AvaloniaUI.Models;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainMenuViewModel : ViewModelBase, IScreen
    {
        private readonly IDialogService _dialogService;
        private readonly ICreateServiceRequestViewModelFactory _createServiceRequestViewModelFactory;
        [Reactive] public RoutableViewModelBase? SelectedViewModel { get; set; }
        public RoutingState Router { get; } = new RoutingState();
        public MainMenuViewModel(IDialogService dialogService,
            ICreateServiceRequestViewModelFactory createServiceRequestViewModelFactory)
        {
            _dialogService = dialogService;
            _createServiceRequestViewModelFactory = createServiceRequestViewModelFactory;
            ShowEquipmentsServiceRequestView();

            Router.CurrentViewModel.Subscribe(view =>
            {
                SelectedViewModel = (RoutableViewModelBase?)view;
            });
        }
        public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack!;
        public void ShowCreateServiceRequestView(Guid? idRequest = null) =>
            Router.Navigate.Execute(_createServiceRequestViewModelFactory.Create(idRequest ?? Guid.Empty));
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
        public async Task<bool?> ShowDialogEditRequestStatusChange(UpdateRequestStatusChangeModel? model)
        {
            var result = await _dialogService.ShowEditRequestStatusChange(this, model);
            return result;
        }
    }
}
