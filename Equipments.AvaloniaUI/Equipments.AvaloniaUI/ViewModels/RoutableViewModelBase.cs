using Equipments.Api;
using ReactiveUI;
using System;
using System.Linq;
using System.Reflection;

namespace Equipments.AvaloniaUI.ViewModels
{
    public abstract class RoutableViewModelBase : ViewModelBase, IRoutableViewModel
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
