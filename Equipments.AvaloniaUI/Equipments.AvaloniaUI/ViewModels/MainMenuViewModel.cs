using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainMenuViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();
        private readonly IDialogService _dialogService;
        public MainMenuViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            ShowEquipmentsServiceRequestView();
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



    }
}
