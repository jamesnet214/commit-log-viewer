using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class CommitListItem : ListBoxItem
    {
        #region DefaultStyleKey

        static CommitListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitListItem), new FrameworkPropertyMetadata(typeof(CommitListItem)));
        }
        #endregion
    }
}