using Aspose.Cells;
using Aspose.Cells.Drawing;
using Equipments.AvaloniaUI.Services;
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


        private ReactiveCommand<SaveFormat, Unit>? _export;
        public ReactiveCommand<SaveFormat, Unit> Export => _export ??= ReactiveCommand.Create<SaveFormat>(async format =>
                                                                                                                await SelectedViewModel.ExportAsync(format));
        [Reactive] public IReportViewModel SelectedViewModel { get; set; }
    }
}