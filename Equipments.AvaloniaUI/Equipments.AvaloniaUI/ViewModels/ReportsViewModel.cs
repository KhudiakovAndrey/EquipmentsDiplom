using System;
using System.Collections.Generic;
using Equipments.AvaloniaUI.Services.API;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class ReportsViewModel : RoutableViewModelBase
    {
        private readonly ReportService _reportService;
        public ReportsViewModel(ReportService reportService) : base(nameof(ReportsViewModel))
        {
            _reportService = reportService;
        }
        public async void SetPdfContent(Guid id)
        {
            var response = await _reportService.GenerateServiceRequestDetailsReport(id);
            if (response.IsSucces)
            {
                HtmlContent = $@"
                <html>
                    <head>
                        <title>PDF Viewer</title>
                    </head>
                    <body>
                        <embed src=""data:application/pdf;base64,{Convert.ToBase64String(response.Data)}"" width=""100%"" height=""100%"">
                    </body>
                </html>";

            }
        }
        [Reactive] public string HtmlContent { get; set; }
        [Reactive] public string Url { get; set; }
    }
}