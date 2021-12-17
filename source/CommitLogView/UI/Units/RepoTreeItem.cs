using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class RepoTreeItem : TreeViewItem
    {
        #region DefaultStyleKey

        static RepoTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTreeItem), new FrameworkPropertyMetadata(typeof(RepoTreeItem)));
        }
        #endregion

        #region GetContainerForItemOverride

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RepoTreeItem();
        }
        #endregion
    }
}
