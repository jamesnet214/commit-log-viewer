using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class RootTreeItem : TreeViewItem
    {
        #region DefaultStyleKey

        static RootTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RootTreeItem), new FrameworkPropertyMetadata(typeof(RootTreeItem)));
        }
        #endregion

        #region GetContainerForItemOverride

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RootTreeItem();
        }
        #endregion
    }
}