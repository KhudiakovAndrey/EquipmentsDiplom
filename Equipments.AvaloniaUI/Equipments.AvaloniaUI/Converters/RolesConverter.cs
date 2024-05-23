using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Converters
{

    public class IconFromRoleConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string role && Dicrionarys.RoleIcons.TryGetValue(role, out var icon))
            {
                return icon;
            }
            return "Alert";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Avalonia.Data.BindingNotification(value);
        }
    }
    public class ContentFromRoleConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string role && Dicrionarys.RoleContents.TryGetValue(role, out var content))
            {
                return content;
            }
            return "Не удалось индентифицировать роль";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Avalonia.Data.BindingNotification(value);
        }
    }
}
