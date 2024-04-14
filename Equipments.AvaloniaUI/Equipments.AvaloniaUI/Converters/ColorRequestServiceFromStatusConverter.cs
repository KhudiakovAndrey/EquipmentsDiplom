using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Equipments.AvaloniaUI.Converters
{
    public class ColorRequestServiceFromStatusConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string status && Dicrionarys.StatusColors.TryGetValue(status, out var color))
            {
                return color;
            }
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Avalonia.Data.BindingNotification(value);
        }
    }
}
