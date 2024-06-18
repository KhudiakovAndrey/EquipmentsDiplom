using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Aspose.Cells;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services;
using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class ReportServiceRequestPrevMonthViewModel : ViewModelBase, IReportViewModel
    {
        private readonly ServiceRequestService _serviceRequestService;
        private readonly IDialogService _dialogService;
        private readonly MainMenuWindowViewModel _mainWindowViewModel;

        public ReportServiceRequestPrevMonthViewModel(ServiceRequestService serviceRequestService, IDialogService dialogService, MainMenuWindowViewModel mainWindowViewModel)
        {
            _serviceRequestService = serviceRequestService;
            _dialogService = dialogService;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public async Task FillServices()
        {
            var response = await _serviceRequestService.GetAllPrevMonth();
            if (response.IsSucces)
            {
                Items = new ObservableCollection<ServiceRequestPrevMonth>(response.Data);
            }
        }
        public async Task ExportAsync(SaveFormat format)
        {
            var filter = new FileFilter()
            {
                Extensions = new List<string>
                {
                    format.ToString().ToLower(),
                },
                Name = format.ToString()
            };
            var settings = new SaveFileDialogSettings
            {
                Filters = new List<FileFilter> { filter }
            };
            var file = await _dialogService.ShowSaveFileDialogAsync(_mainWindowViewModel, settings);

            if (file == null)
                return;

            var workbook = ExportData.Export(Items.ToArray());

            try
            {
                workbook.Save(file.Path.AbsolutePath, format);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

        }
        public void Reload()
        {
            InitializeNotify = NotifyTaskCompletion.Create(FillServices);
        }

        [Reactive] public ObservableCollection<ServiceRequestPrevMonth> Items { get; set; }
    }
}