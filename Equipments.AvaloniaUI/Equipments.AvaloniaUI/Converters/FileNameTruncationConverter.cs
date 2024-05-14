using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;
using System.IO;

namespace Equipments.AvaloniaUI.Converters
{
    public class FileNameTruncationConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string fileName && fileName.Length > 15)
            {
                string extension = Path.GetExtension(fileName);
                string truncation = fileName.Substring(0, 10) + $"...{extension}";
                return truncation;
            }
            return value;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new Avalonia.Data.BindingNotification(value);
        }

    }
}
