using Aspose.Cells;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Equipments.AvaloniaUI.Services
{
    public static class ExportData
    {


        public static Workbook Export(object[] data)
        {
            Workbook workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets[0];

            Type elementType = data.GetType().GetElementType();

            // Получаем все свойства элементов списка
            PropertyInfo[] properties = elementType.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                string displayName = properties[i].GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                displayName = displayName ?? properties[i].Name;
                sheet.Cells[0, i].PutValue(displayName);
            }

            for (int rIndex = 0; rIndex < data.Count(); rIndex++)
            {
                object item = data[rIndex];
                for (int colIndex = 0; colIndex < properties.Length; colIndex++)
                {
                    object value = properties[colIndex].GetValue(item);
                    string stringValue = value?.ToString() ?? string.Empty;

                    sheet.Cells[rIndex + 1, colIndex].PutValue(stringValue);
                }
            }

            return workbook;
        }
    }
}
