using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;

namespace Equipments.AvaloniaUI.Behaviors
{
    public class RectanglePropertysBehavior
    {
        public static readonly StyledProperty<bool> IsDraggingProperty =
            AvaloniaProperty.RegisterAttached<Rectangle, bool>("IsDragging", typeof(RectanglePropertysBehavior), false);

        public static void SetIsDragging(Rectangle rectangle, bool value)
        {
            rectangle.SetValue(IsDraggingProperty, value);
        }
        public static bool GetIsDragging(Rectangle rectangle)
        {
            return rectangle.GetValue(IsDraggingProperty);
        }

    }
}
