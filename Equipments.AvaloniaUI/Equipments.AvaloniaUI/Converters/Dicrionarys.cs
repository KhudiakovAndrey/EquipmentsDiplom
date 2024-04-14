using Avalonia.Media;
using System.Collections.Generic;

namespace Equipments.AvaloniaUI.Converters
{
    public static class Dicrionarys
    {
        public static Dictionary<string, IBrush> StatusColors = new Dictionary<string, IBrush>
        {
            { "В обработке", SolidColorBrush.Parse("#2196F3")!},
            { "Завершено", SolidColorBrush.Parse("#4CAF50")! },
            { "В работе" , SolidColorBrush.Parse("#FFEB3B") !},
            { "Отменена " , SolidColorBrush.Parse("#F44336") !},
        };
    }
}
