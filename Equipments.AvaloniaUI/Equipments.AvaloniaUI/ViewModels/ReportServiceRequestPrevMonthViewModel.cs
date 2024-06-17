using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class ReportServiceRequestPrevMonthViewModel : ViewModelBase, IReportViewModel
    {
        private readonly ServiceRequestService _serviceRequestService;

        public ReportServiceRequestPrevMonthViewModel(ServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        public async Task FillServices()
        {
            var response = await _serviceRequestService.GetAllPrevMonth();
            if (response.IsSucces)
            {
                Items = new ObservableCollection<ServiceRequestPrevMonth>(response.Data);
            }
        }

        public void Reload()
        {
            InitializeNotify = NotifyTaskCompletion.Create(FillServices);
        }

        [Reactive] public ObservableCollection<ServiceRequestPrevMonth> Items { get; set; }
    }
}