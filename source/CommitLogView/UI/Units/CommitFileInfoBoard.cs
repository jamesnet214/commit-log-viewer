using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class CommitFileInfoBoard : ContentControl
    {
        #region DefaultStyleKey

        static CommitFileInfoBoard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitFileInfoBoard), new FrameworkPropertyMetadata(typeof(CommitFileInfoBoard)));
        }
        #endregion
    }
}