using Equipments.Application.EquipmentsServiceRequest.Queries;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;

namespace Equipments.Application.Reports
{
    public class ServiceRequestReport
    {
        public GetServiceRequestDetails.RequestDetailsVM Model { get; }
        public ServiceRequestReport(GetServiceRequestDetails.RequestDetailsVM model)
        {
            Model = model;
        }
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose()
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(50);
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
            }).ShowInPreviewer();
        }

        private void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold()
                .FontColor(Colors.Blue.Medium);
            container.AlignCenter().Text("Заявка на обслуживание компьютерного оборудования")
                .Style(titleStyle);
        }
        private void ComposeContent(IContainer container)
        {
        }

    }
}
