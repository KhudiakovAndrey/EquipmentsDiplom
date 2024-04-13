// See https://aka.ms/new-console-template for more information
using Equipments.Application.Reports;
using QuestPDF.Fluent;

Console.WriteLine("Hello, World!");
new ServiceRequestReport(null).Compose();

