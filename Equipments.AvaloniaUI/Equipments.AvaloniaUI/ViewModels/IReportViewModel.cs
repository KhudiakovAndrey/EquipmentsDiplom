using Aspose.Cells;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public interface IReportViewModel
    {
        public void Reload();
        public Task ExportAsync(SaveFormat format);
    }
}
