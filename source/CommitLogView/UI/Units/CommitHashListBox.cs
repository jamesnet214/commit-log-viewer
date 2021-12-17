using System.Windows;

namespace CommitLogView.UI.Units
{
    public class CommitHashListBox : RepoFileListBox
    {
        #region DefaultStyleKey

        static CommitHashListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitHashListBox), new FrameworkPropertyMetadata(typeof(CommitHashListBox)));
        }
        #endregion

        #region GetContainerForItemOverride

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CommitHashListItem();
        }
        #endregion
    }
}
