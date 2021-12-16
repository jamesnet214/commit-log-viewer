using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class CommitFileListItemCard : ContentControl
    {
        #region DefaultStyleKey

        static CommitFileListItemCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitFileListItemCard), new FrameworkPropertyMetadata(typeof(CommitFileListItemCard)));
        }
        #endregion
    }
}