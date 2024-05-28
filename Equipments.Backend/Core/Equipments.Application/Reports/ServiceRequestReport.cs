using Equipments.Application.EquipmentsServiceRequest.Queries;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace Equipments.Application.Reports
{
    public class ServiceRequestReport
    {
        public GetServiceRequestDetails.RequestDetailsVM Model { get; }
        public ServiceRequestReport(GetServiceRequestDetails.RequestDetailsVM model)
        {
            Model = model;
            //Model = new()
            //{
            //    ID = Guid.NewGuid(),
            //    Responsible = new EmployeDto
            //    {
            //        FullName = "Иванов Иван Иванович",
            //        Post = "Лектор",
            //        Department = "Учительская",
            //    },
            //    SystemAdministrator = new EmployeDto
            //    {
            //        FullName = "Петров Петр Петрович",
            //        Post = "Системный администратор",
            //        Department = "Сервер",
            //    },
            //    CreationDate = DateTime.Now,
            //    DetailedDescription = "Et minim consectetur aute ipsum eiusmod. Cillum consectetur id ea pariatur est dolor do non ex eu pariatur quis proident. Quis nulla do in consequat ipsum do fugiat esse nostrud ad excepteur est duis. Exercitation amet aute cupidatat ea laboris excepteur irure sint laboris laboris ut elit. Nostrud nulla aliqua laboris ea in mollit reprehenderit Lorem do duis.",
            //    BrokenEquipmentDescription = "Consequat aliquip minim ullamco cillum magna Lorem magna sit est. Consequat do qui et ex ullamco eu. In enim in exercitation veniam labore.",
            //    Statues = new()
            //    {
            //        new RequestDetailsVM
            //        {
            //            Status = new RequestStatuses.RequestStatusDto
            //            {
            //                Name = "В обработке"
            //            },
            //            ChangeStatusDate = DateTime.Now.AddHours(-2),
            //            Description = "Обрабатывается исполнителем"
            //        },
            //        new RequestDetailsVM
            //        {
            //            Status = new RequestStatuses.RequestStatusDto
            //            {
            //                Name = "Выполняется"
            //            },
            //            ChangeStatusDate = DateTime.Now,
            //            Description = "Принялись за работы"
            //        },
            //        new RequestDetailsVM
            //        {
            //            Status = new RequestStatuses.RequestStatusDto
            //            {
            //                Name = "Выполняется"
            //            },
            //            ChangeStatusDate = DateTime.Now,
            //            Description = "Принялись за работы"
            //        },
            //        new RequestDetailsVM
            //        {
            //            Status = new RequestStatuses.RequestStatusDto
            //            {
            //                Name = "Выполняется"
            //            },
            //            ChangeStatusDate = DateTime.Now,
            //            Description = "Принялись за работы"
            //        },
            //        new RequestDetailsVM
            //        {
            //            Status = new RequestStatuses.RequestStatusDto
            //            {
            //                Name = "Выполняется"
            //            },
            //            ChangeStatusDate = DateTime.Now,
            //            Description = "Принялись за работы"
            //        },
            //    }
            //};
        }
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public byte[] Compose()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.DefaultTextStyle(TextStyle.Default.FontFamily("JetBrains Mono"));
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
            });
            return document.GeneratePdf();
        }

        private void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontFamily("JetBrains Mono").FontSize(20).SemiBold()
                .FontColor(Colors.Black);
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(text =>
                    {
                        text.Span("Заявка ").Style(titleStyle);
                        text.Span($"#{Model.ID}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Дата подачи: ").SemiBold();
                        text.Span($"{Model.CreationDate:G}");
                    });
                });
            });
        }
        private void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);

                column.Item().Row(row =>
                {
                    row.RelativeItem().Component(new EmployeComponent("Заявитель", Model.Responsible));
                    row.ConstantItem(50);
                    row.RelativeItem().Component(new EmployeComponent("Исполнитель", Model.SystemAdministrator));
                });

                column.Item().PaddingTop(20).Element(ComposeTable);

                if (!string.IsNullOrWhiteSpace(Model.DetailedDescription))
                    column.Item().Element(ComposeDetailedDescription);

                if (!string.IsNullOrWhiteSpace(Model.BrokenEquipmentDescription))
                    column.Item().Element(ComposeBrokenEquipmentDescription);
            });
        }


        private void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                //1
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                //2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("Статус");
                    header.Cell().Element(CellStyle).PaddingRight(10).AlignRight().Text("Дата изменения");
                    header.Cell().Element(CellStyle).Text("Описание");

                    static IContainer CellStyle(IContainer container)
                        => container.DefaultTextStyle(x => x.SemiBold())
                        .PaddingVertical(5)
                        .BorderBottom(1)
                        .BorderColor(Colors.Black);

                });

                //3
                foreach (var status in Model.Statues)
                {
                    table.Cell().Element(CellStyle).Text(Model.Statues.IndexOf(status) + 1);
                    table.Cell().Element(CellStyle).Text(status.Status.Name);
                    table.Cell().Element(CellStyle).PaddingRight(10).AlignRight().Text(status.ChangeStatusDate);
                    table.Cell().Element(CellStyle).Text(status.Description);

                    static IContainer CellStyle(IContainer container)
                        => container.BorderBottom(1)
                                    .BorderColor(Colors.Grey.Lighten2)
                                    .PaddingVertical(5);
                }
            });
        }
        private void ComposeDetailedDescription(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Описание заявки").FontSize(14);
                column.Item().Text(Model.DetailedDescription);
            });
        }
        private void ComposeBrokenEquipmentDescription(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Описание сломанного оборудования").FontSize(14);
                column.Item().Text(Model.BrokenEquipmentDescription);
            });
        }
    }

    public class EmployeComponent : IComponent
    {
        private string Title { get; }
        private EmployeDto Employe { get; }
        public EmployeComponent(string title, EmployeDto employe)
        {
            Title = title;
            Employe = employe;
        }
        public void Compose(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(2);

                column.Item().BorderBottom(1).PaddingBottom(5).Text(Title).SemiBold();

                column.Item().Text(Employe.FullName);
                column.Item().Text(Employe.Post);
                column.Item().Text(Employe.Department);
            });
        }
    }
}
