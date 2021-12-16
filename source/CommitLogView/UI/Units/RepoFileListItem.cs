using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class RepoFileListItem : ListBoxItem
    {
        #region DefaultStyleKey

        static RepoFileListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoFileListItem), new FrameworkPropertyMetadata(typeof(RepoFileListItem)));
        }
        #endregion
    }
}