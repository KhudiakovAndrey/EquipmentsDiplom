using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Equipments.AvaloniaUI.Views
{
    public partial class CreateServiceRequestView : ReactiveUserControl<CreateServiceRequestViewModel>
    {
        public CreateServiceRequestView()
        {
            InitializeComponent();
        }

        private void ShowReportViewPdfButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var dataContext = DataContext as CreateServiceRequestViewModel;
            Guid idRequest = Guid.Parse(dataContext!.NumberRequest.Substring(1));
            if (App.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                if (desktop.Windows.Any(win => win.Tag?.ToString() == idRequest.ToString()))
                    return;
            }
            var vm = App.ServiceProvider!.GetService<ReportsViewModel>();
            vm!.SetPdfContent(idRequest);
            var reportView = new ReportsView()
            {
                Tag = idRequest,
            };
            reportView.DataContext = vm;
            reportView.Show();
        }
    }
}
