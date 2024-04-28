using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;

namespace Equipments.AvaloniaUI.Behaviors
{
    public class DataGridNumberRowsBehavior : Behavior<DataGrid>
    {
        private DataGrid? _dataGrid;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject!.LoadingRow += OnDataGridLoadedRow;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject!.LoadingRow -= OnDataGridLoadedRow;
        }

        private void OnDataGridLoadedRow(object? sender, DataGridRowEventArgs e)
        {
            _dataGrid = sender as DataGrid;
            if (_dataGrid != null)
            {
                e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            }
        }
    }
}