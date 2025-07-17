using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TBRAppMobile.Converters
{
    public class IconBorderConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var currentIcon = value as string;
            var selectedIcon = parameter as string;

            return currentIcon == selectedIcon ? Colors.DodgerBlue : Colors.Transparent;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
