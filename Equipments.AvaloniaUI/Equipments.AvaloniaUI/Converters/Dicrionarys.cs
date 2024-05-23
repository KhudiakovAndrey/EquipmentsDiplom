using Avalonia.Media;
using Material.Icons.Avalonia;
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

        public static Dictionary<string, Material.Icons.MaterialIconKind> RoleIcons = new Dictionary<string, Material.Icons.MaterialIconKind>
        {
            { "Гость", Material.Icons.MaterialIconKind.VisibilityOff },
            { "Сотрудник", Material.Icons.MaterialIconKind.Account },
            { "Ответственный", Material.Icons.MaterialIconKind.Account },
            { "Системный администратор", Material.Icons.MaterialIconKind.Support },
            { "Администратор", Material.Icons.MaterialIconKind.ShieldAccount },
        };
        public static Dictionary<string, string> RoleContents = new Dictionary<string, string>
        {
            { "Гость", "VisibilityOff" },
            { "Сотрудник", "Account" },
            { "Ответственный", "Account" },
            { "Системный администратор", "Support" },
            { "Администратор", "ShieldAccount" },
        };
    }
}
