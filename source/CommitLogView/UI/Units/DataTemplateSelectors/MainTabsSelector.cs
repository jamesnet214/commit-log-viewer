﻿using CommitLogView.Local.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units.DataTemplateSelectors
{
    public class MainTabsRoute : DataTemplateSelector
    {
        public DataTemplate Repos { get; set; }
        public DataTemplate Commit { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is RepoViewModel)
            {
                return Repos;
            }
            else if (item is CommitViewModel)
            {
                return Commit;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
