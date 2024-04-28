using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Equipments.AvaloniaUI.Models
{
    public class ChangeHeightDataGridRowModel
    {
        public int Height { get; set; }
        public StreamGeometry Icon { get; }

        public ChangeHeightDataGridRowModel(int height, string iconKey)
        {
            Height = height;
            Application.Current!.TryFindResource(iconKey, out var res);
            Icon = (StreamGeometry)res!;
        }

        public void ChangeHeight(DataGrid dataGrid)
        {
            dataGrid.RowHeight = Height;
        }
    }
}
