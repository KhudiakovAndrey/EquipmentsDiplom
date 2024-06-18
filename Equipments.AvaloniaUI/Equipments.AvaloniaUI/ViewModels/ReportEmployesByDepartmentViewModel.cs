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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class ReportEmployesByDepartmentViewModel : ViewModelBase, IReportViewModel
    {
        private readonly EmployeesService _employeesService;
        private readonly DepartmentsService _departmentsService;
        private readonly IDialogService _dialogService;
        private readonly MainMenuWindowViewModel _mainMenuViewModel;
        public ReportEmployesByDepartmentViewModel(EmployeesService employeesService,
            IDialogService dialogService,
            MainMenuWindowViewModel mainMenuViewModel,
            DepartmentsService departmentsService)
        {
            _employeesService = employeesService;
            _dialogService = dialogService;
            _mainMenuViewModel = mainMenuViewModel;
            _departmentsService = departmentsService;

            this.WhenAnyValue(vm => vm.SelectedDepartments).Subscribe(async _ => await Initialize());
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
            var file = await _dialogService.ShowSaveFileDialogAsync(_mainMenuViewModel, settings);

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
            InitializeNotify = NotifyTaskCompletion.Create(InitializeDepartments);
            InitializeNotify = NotifyTaskCompletion.Create(Initialize);
        }
        private async Task InitializeDepartments()
        {
            var responseDepartments = await _departmentsService.GetAll();
            if (responseDepartments.IsSucces)
            {
                Departments = new ObservableCollection<DepartmentModel>(responseDepartments.Data);
            }
        }
        private async Task Initialize()
        {
            if (SelectedDepartments != null)
            {
                var responceReport = await _employeesService.GetAllByDepartment(SelectedDepartments.ID);
                if (responceReport.IsSucces)
                {
                    Items = new ObservableCollection<ReportEmployeByDepartmentModel>(responceReport.Data);
                }
            }
        }
        [Reactive] public ObservableCollection<DepartmentModel> Departments { get; set; }
        [Reactive] public DepartmentModel? SelectedDepartments { get; set; }
        [Reactive] public ObservableCollection<ReportEmployeByDepartmentModel> Items { get; set; }
    }
}