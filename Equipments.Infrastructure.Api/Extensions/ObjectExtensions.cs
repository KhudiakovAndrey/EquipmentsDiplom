using System;
using System.Linq;
using System.Web;

namespace Equipments.Api.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToQueryString(this object obj)
        {
            var properties = obj.GetType().GetProperties();
            var queryString = properties.SelectMany(property =>
            {
                var value = property.GetValue(obj);
                if (value == null)
                {
                    return Enumerable.Empty<string>();
                }

                if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string) || property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(Guid))
                {
                    return new[] { $"{property.Name}={HttpUtility.UrlEncode(value.ToString())}" };
                }

                if (property.PropertyType.IsArray)
                {
                    var array = (Array)value;
                    return array.Cast<object>().SelectMany(item => ToQueryString(item)).Select(query => $"{property.Name}[]={query}");
                }

                if (property.PropertyType.IsClass)
                {
                    var nestedProperties = value.GetType().GetProperties();
                    var nestedQueryString = nestedProperties.SelectMany(nestedProperty =>
                    {
                        var nestedValue = nestedProperty.GetValue(value);
                        if (nestedValue == null)
                        {
                            return Enumerable.Empty<string>();
                        }

                        return new[] { $"{property.Name}.{nestedProperty.Name}={HttpUtility.UrlEncode(nestedValue.ToString())}" };
                    });

                    return nestedQueryString;
                }

                return Enumerable.Empty<string>();
            }).ToArray();

            return string.Join("&", queryString);
        }
    }

}
