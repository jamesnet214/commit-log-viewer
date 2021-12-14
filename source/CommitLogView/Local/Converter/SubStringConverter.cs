using System;
using System.Globalization;
using System.Windows.Data;

namespace CommitLogView.Local.Converter
{
    public class SubStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Substring(0, int.Parse(parameter.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
