using MiniatureOrderManagementTool.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MiniatureOrderManagementTool.Helpers
{
    public class StockedPartValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is StockedPart sp)
            {
                return sp.UnitPrice * sp.Count;
            }
            else
            {
                return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
