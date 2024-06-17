using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainReportViewModel : RoutableViewModelBase
    {
        public MainReportViewModel()
            : base(nameof(MainReportViewModel))
        {
            this.WhenAnyValue(vm => vm.SelectedViewModel).Subscribe(selected => selected?.Reload());
        }

        private ReactiveCommand<Unit, Unit>? _reload;
        public ReactiveCommand<Unit, Unit> Reload => _reload ??= ReactiveCommand.Create(SelectedViewModel.Reload);

        [Reactive] public IReportViewModel SelectedViewModel { get; set; }
    }
}