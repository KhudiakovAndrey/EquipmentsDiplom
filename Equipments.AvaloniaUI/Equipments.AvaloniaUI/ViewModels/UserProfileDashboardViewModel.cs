using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class UserProfileDashboardViewModel : RoutableViewModelBase
    {
        private readonly ServiceRequestService _serviceRequestService;
        public UserProfileDashboardViewModel(ServiceRequestService serviceRequestService)
            : base(nameof(UserProfileDashboardViewModel))
        {
            _serviceRequestService = serviceRequestService;
            InitializeNotify = NotifyTaskCompletion.Create(InitializeAsync);
            InitializeSeries = NotifyTaskCompletion.Create(InitializeSeriesAsync);
        }

        private async Task InitializeAsync()
        {
            CreatedCountRequest = await GetCreatedCount();
            AvgCreatedRequest = await GetAvgCreatedRequest();
        }

        private async Task InitializeSeriesAsync()
        {
            var countCreatedRequestByDate = await GetCountCreatedRequestByDate(new DateTime(2024, 4, 4), new DateTime(2024, 4, 14), CountDatePeriodModel.Day);
            ChangeSeriesAndAxesCountCreatedDate(countCreatedRequestByDate);
        }
        private async Task<int> GetCreatedCount()
        {
            var response = await _serviceRequestService.GetCountCreatedByUserAsync();
            if (response.IsSucces)
            {
                return response.Data;
            }
            return 0;
        }
        private async Task<double> GetAvgCreatedRequest()
        {
            var response = await _serviceRequestService.GetAvgCreatedByUserAsync();
            if (response.IsSucces)
            {
                return response.Data;
            }
            return 0;
        }
        private async Task<List<RequestCountDateModel>> GetCountCreatedRequestByDate(DateTime startDate, DateTime endDate, CountDatePeriodModel period)
        {
            var response = await _serviceRequestService.GetCountCreatedByDate(startDate, endDate, period);
            if (response.IsSucces)
            {
                return response.Data;
            }
            return new List<RequestCountDateModel>();
        }


        private ReactiveCommand<Unit, Unit>? _getCountCratedRequestByMonth;
        public ReactiveCommand<Unit, Unit> GetCountCratedRequestByMonth => _getCountCratedRequestByMonth ??= ReactiveCommand.CreateFromTask(GetCountCratedRequestByMonthMethod);

        private async Task GetCountCratedRequestByMonthMethod()
        {
            var requests = await GetCountCreatedRequestByDate(new DateTime(2024, 3, 14), new DateTime(2024, 4, 14), CountDatePeriodModel.Day);
            ChangeSeriesAndAxesCountCreatedDate(requests);
        }

        private ReactiveCommand<Unit, Unit>? _getCountCratedRequestByWeek;
        public ReactiveCommand<Unit, Unit> GetCountCratedRequestByWeek => _getCountCratedRequestByWeek ??= ReactiveCommand.CreateFromTask(GetCountCratedRequestByWeekMethod);
        private async Task GetCountCratedRequestByWeekMethod()
        {
            var requests = await GetCountCreatedRequestByDate(new DateTime(2024, 4, 7), new DateTime(2024, 4, 14), CountDatePeriodModel.Day);
            ChangeSeriesAndAxesCountCreatedDate(requests);
        }
        private ReactiveCommand<Unit, Unit>? _getCountCratedRequestByYear;
        public ReactiveCommand<Unit, Unit> GetCountCratedRequestByYear => _getCountCratedRequestByYear ??= ReactiveCommand.CreateFromTask(GetCountCratedRequestByYearMethod);
        private async Task GetCountCratedRequestByYearMethod()
        {
            var requests = await GetCountCreatedRequestByDate(new DateTime(2023, 4, 14), new DateTime(2024, 4, 14), CountDatePeriodModel.Month);
            ChangeSeriesAndAxesCountCreatedDate(requests);
        }
        private void ChangeSeriesAndAxesCountCreatedDate(List<RequestCountDateModel> requests)
        {
            CountCreatedDateSeries = new ObservableCollection<ISeries>
            {
                new LineSeries<int>
                {
                    Values = requests.Select(s=>s.Count)
                }
            };
            CountCreatedDateXAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Дата создания",
                    Labels = new ObservableCollection<string>(requests.Select(g => g.Date))
                }
            };
            CountCreatedDateYAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Количество"
                }
            };
        }

        [Reactive] public ObservableCollection<ISeries> CountCreatedDateSeries { get; set; } = new();
        [Reactive] public Axis[] CountCreatedDateXAxes { get; set; } = new Axis[0];
        [Reactive] public Axis[] CountCreatedDateYAxes { get; set; } = new Axis[0];
        [Reactive] public int CreatedCountRequest { get; set; }
        [Reactive] public double AvgCreatedRequest { get; set; }

        public INotifyTaskCompletion? InitializeSeries { get; set; }
    }
}
