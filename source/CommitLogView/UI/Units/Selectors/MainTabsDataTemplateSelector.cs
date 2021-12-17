using CommitLogView.Local.Data;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units.Selectors
{
    public class MainTabsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RepositoryTemplate { get; set; }
        public DataTemplate CommitTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is RepoTabContentItem)
            {
                return RepositoryTemplate;
            }
            else if (item is CommitTabContentItem)
            {
                return CommitTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
