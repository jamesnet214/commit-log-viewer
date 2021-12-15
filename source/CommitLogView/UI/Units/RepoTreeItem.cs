using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class RepoTreeItem : TreeViewItem
    {
        static RepoTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTreeItem), new FrameworkPropertyMetadata(typeof(RepoTreeItem)));
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RepoTreeItem();
        }
    }
}
