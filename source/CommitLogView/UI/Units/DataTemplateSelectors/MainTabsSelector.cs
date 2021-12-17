using CommitLogView.Local.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units.DataTemplateSelectors
{
    public class MainTabsSelector : DataTemplateSelector
    {
        public DataTemplate RepositoryTemplate { get; set; }
        public DataTemplate CommitTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is RepoViewModel)
            {
                return RepositoryTemplate;
            }
            else if (item is CommitViewModel)
            {
                return CommitTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
