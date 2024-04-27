using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class DashboardViewModel : RoutableViewModelBase
    {
        public DashboardViewModel()
            : base(nameof(DashboardViewModel).ToLowerInvariant())
        {

        }
        public ISeries[] OneSeries { get; set; }
            = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = new int[] { 4, 6, 5, 3, -3, -1, 2 }
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 2, 5, 4, -2, 4, -3, 5 }
                }
            };
        public ISeries[] PieSeries { get; set; }
            = new ISeries[]
            {
                new PieSeries<double> { Values = new double[] { 2 } },
                new PieSeries<double> { Values = new double[] { 4 } },
                new PieSeries<double> { Values = new double[] { 1 } },
                new PieSeries<double> { Values = new double[] { 4 } },
                new PieSeries<double> { Values = new double[] { 3 } }
            };
    }
}
