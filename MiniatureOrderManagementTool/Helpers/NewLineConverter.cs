﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace MiniatureOrderManagementTool.Helpers
{
    public class NewLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Regex.Replace((string)value, @"\r\n?|\n", " ") : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
