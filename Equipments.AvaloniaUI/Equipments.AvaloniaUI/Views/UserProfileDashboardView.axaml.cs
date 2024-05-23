using Avalonia.Controls;

namespace Equipments.AvaloniaUI.Views
{
    public partial class UserProfileDashboardView : UserControl
    {
        public UserProfileDashboardView()
        {
            InitializeComponent();
        }

        private void NextSeries(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Carousel chart)
            {
                if (chart.SelectedIndex < chart.ItemCount - 1)
                    ++chart.SelectedIndex;
                else
                    chart.SelectedIndex = 0;
            }
        }

        private void PreviousSeries(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Carousel chart)
            {
                if (chart.SelectedIndex != 0)
                    --chart.SelectedIndex;
                else
                    chart.SelectedIndex = chart.ItemCount - 1;
            }
        }
    }
}
