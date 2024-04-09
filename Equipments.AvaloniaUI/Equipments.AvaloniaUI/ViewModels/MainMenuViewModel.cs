using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Linq;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainMenuViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();

        public MainMenuViewModel()
        {
            Router.Navigate.Execute(new EquipmentsServiceRequestViewModel(this));
        }
        public void ShowEquipmentsServiceRequestView() =>
            NaviageIgnoreCopyUrl(new EquipmentsServiceRequestViewModel(this));

        public void ShowEquipmentPurchaseRequestView() =>
            NaviageIgnoreCopyUrl(new EquipmentPurchaseRequestViewModel(this));

        private void NaviageIgnoreCopyUrl(IRoutableViewModel vm)
        {
            Router.NavigationStack.Clear();
            if (Router.NavigationStack.Any(rout => rout.UrlPathSegment == vm.UrlPathSegment))
                return;
            Router.Navigate.Execute(vm);
        }
    }
}
