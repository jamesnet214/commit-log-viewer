using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class CommitHashListItem : ListBoxItem
    {
        #region DefaultStyleKey

        static CommitHashListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitHashListItem), new FrameworkPropertyMetadata(typeof(CommitHashListItem)));
        }
        #endregion
    }
}