﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using CommitLogView.UI.Units;

namespace CommitLogView.Local.Converter
{
    public class RootTreeItemLevelConverter : MarkupExtension, IValueConverter
    {
        public int Length { get; set; } = 10;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int level = -1;

            if (value is DependencyObject d)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(d);

                while (parent is not RootTreeControl)
                {
                    if (parent is RootTreeItem)
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

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
