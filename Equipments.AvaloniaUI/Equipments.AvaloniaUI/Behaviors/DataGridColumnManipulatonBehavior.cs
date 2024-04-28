using Avalonia;
using Avalonia.Controls;

namespace Equipments.AvaloniaUI.Behaviors
{
    public class DataGridColumnManipulatonBehavior
    {
        public static readonly StyledProperty<bool> IsCanRemoveColumnProperty =
            AvaloniaProperty.RegisterAttached<DataGridColumn, bool>("IsCanRemoveColumn", typeof(DataGridColumnManipulatonBehavior), false);

        public static void SetIsCanRemoveColumn(DataGridColumn column, bool value)
        {
            column.SetValue(IsCanRemoveColumnProperty, value);
        }
        public static bool GetIsCanRemoveColumn(DataGridColumn column)
        {
            return column.GetValue(IsCanRemoveColumnProperty);
        }
    }
}
