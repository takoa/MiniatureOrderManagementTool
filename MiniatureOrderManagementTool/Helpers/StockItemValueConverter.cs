using MiniatureOrderManagementTool.Models.Dtos;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MiniatureOrderManagementTool.Helpers
{
    public class StockItemValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is StockItem si)
            {
                return si.UnitPrice * si.Count;
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
