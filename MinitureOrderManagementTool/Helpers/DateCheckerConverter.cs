using System;
using System.Globalization;
using System.Windows.Data;

namespace MinitureOrderManagementTool.Helpers
{
    public class DateCheckerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double delta;

            if (!double.TryParse((string)parameter, out delta))
            {
                return false;
            }

            if (value is DateTime deadline)
            {
                DateTime dt = DateTime.Now;

                dt = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0).AddDays(delta);

                return dt < deadline;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
