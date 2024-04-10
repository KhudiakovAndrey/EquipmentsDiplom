using ReactiveUI;
using System;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class RoutableViewModelBase : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string? UrlPathSegment { get; set; }
        public RoutableViewModelBase(string urlPathSegment)
        {
            //HostScreen = screen;
            UrlPathSegment = urlPathSegment;
        }
    }
}
