using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class MainTreeItem : TreeViewItem
    {
        #region DefaultStyleKey

        static MainTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTreeItem), new FrameworkPropertyMetadata(typeof(MainTreeItem)));
        }
        #endregion

        #region GetContainerForItemOverride

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MainTreeItem();
        }
        #endregion
    }
}
