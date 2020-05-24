using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MinitureOrderManagementTool.Helpers
{
    public class DateConverter : IValueConverter, IBindingTypeConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dt)
            {
                return dt.Date.ToString("yyyy/MM/dd");
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

        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            if (fromType == typeof(DateTime) && toType == typeof(string))
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        public bool TryConvert(object from, Type toType, object conversionHint, out object result)
        {
            if (from is DateTime dt && toType == typeof(string))
            {
                result = dt.ToString("yyyy年MM月dd日");

                return true;
            }
            else
            {
                result = null;

                return false;
            }
        }
    }
}
