using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class CommitFileListItem : ListBoxItem
    {
        #region DefaultStyleKey

        static CommitFileListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitFileListItem), new FrameworkPropertyMetadata(typeof(CommitFileListItem)));
        }
        #endregion
    }
}