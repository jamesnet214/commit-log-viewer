using System.Windows;

namespace CommitLogView.UI.Units
{
    public class CommitListBox : RepoFileListBox
    {
        #region DefaultStyleKey

        static CommitListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitListBox), new FrameworkPropertyMetadata(typeof(CommitListBox)));
        }
        #endregion

        #region GetContainerForItemOverride

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CommitListItem();
        }
        #endregion
    }
}
