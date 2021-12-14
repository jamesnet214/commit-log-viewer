using System;
using System.Globalization;
using System.Windows.Data;

namespace CommitLogView.Local.Converter
{
    public class UpperShortCutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string word = value.ToString().ToUpper();
            int length = int.Parse(parameter.ToString());
            length = word.Length < length ? word.Length : length;
            return value.ToString().ToUpper().Substring(0, length);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
