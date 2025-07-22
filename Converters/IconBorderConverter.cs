using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TBRAppMobile.Converters
{
    public class IconBorderConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var selectedIcon = (parameter as CollectionView)?.SelectedItem as string;
            var currentIcon = value as string;

            if (string.IsNullOrEmpty(selectedIcon) || string.IsNullOrEmpty(currentIcon))
                return Colors.Transparent;

            return selectedIcon == currentIcon ? Colors.DodgerBlue : Colors.Transparent;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
