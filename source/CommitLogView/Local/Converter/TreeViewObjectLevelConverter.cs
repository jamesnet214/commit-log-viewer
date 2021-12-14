using CommitLogView.UI.Units;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CommitLogView.Local.Converter
{
    public class TreeViewObjectLevelConverter : IValueConverter
    {
        public int Length { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int level = -1;

            if (value is DependencyObject d)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(d);

                while (!(parent is NcoreTreeView))
                {
                    if (parent is TreeViewItem)
                    {
                        level++;
                    }
                    parent = VisualTreeHelper.GetParent(parent);
                }

            }
            return new Thickness(level * Length, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
