using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class UserProfileViewModel : RoutableViewModelBase
    {
        public UserProfileViewModel()
            : base(nameof(UserProfileViewModel))
        {
            SelectedPaneItem = PaneItems.First();
            this.WhenAnyValue(vm => vm.SelectedPaneItem).Subscribe(OnSelectedPaneItemChanged);
        }

        private void OnSelectedPaneItemChanged(MenuListItemTemplate template)
        {
            var vm = App.ServiceProvider!.GetService(template.ModelType);
            SelectedView = (RoutableViewModelBase)vm!;
        }

        [Reactive] public ViewModelBase SelectedView { get; set; }
        public List<MenuListItemTemplate> PaneItems { get; set; } = new()
        {
            new MenuListItemTemplate("Профиль", typeof(UserProfileInfoViewModel),"HomeUser"),
            new MenuListItemTemplate("Статистика", typeof(UserProfileDashboardViewModel),"ChartArc"),
        };
        [Reactive] public MenuListItemTemplate? SelectedPaneItem { get; set; }
    }

    public class MenuListItemTemplate
    {
        public MenuListItemTemplate(string header, Type type, string kind)
        {
            Header = header;
            ModelType = type;
            Kind = kind;
        }
        public string Header { get; }
        public Type ModelType { get; }
        public string Kind { get; }
    }
}
