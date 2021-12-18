using CommitLogView.Local.Data.MainTabs;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units.DataTemplateSelectors
{
    public class MainTabsRoute : DataTemplateSelector
    {
        public DataTemplate Start { get; set; }
        public DataTemplate Repos { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TabsStarted)
            {
                return Start;
            }
            else if (item is TabsRepository)
            {
                return Repos;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
