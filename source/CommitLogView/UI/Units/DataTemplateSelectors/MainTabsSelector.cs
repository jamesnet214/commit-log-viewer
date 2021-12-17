using CommitLogView.Local.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units.DataTemplateSelectors
{
    public class MainTabsSelector : DataTemplateSelector
    {
        public DataTemplate Repo { get; set; }
        public DataTemplate Commit { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is RepoViewModel)
            {
                return Repo;
            }
            else if (item is CommitViewModel)
            {
                return Commit;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
