using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CommitLogView.Local.Converter
{
    public class SubStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Substring(0, int.Parse(parameter.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
