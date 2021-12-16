using System.Windows;

namespace CommitLogView.UI.Units
{
    public class CommitFileListBox : RepoFileListBox
    {
        #region DefaultStyleKey

        static CommitFileListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitFileListBox), new FrameworkPropertyMetadata(typeof(CommitFileListBox)));
        }
        #endregion

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CommitFileListItem();
        }
    }
}
