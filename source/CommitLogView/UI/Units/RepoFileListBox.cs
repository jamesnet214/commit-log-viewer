using DevNcore.WPF.Controls;
using System.Windows;
using System.Windows.Input;

namespace CommitLogView.UI.Units
{
    public class RepoFileListBox : NcoreListControl
    {
        #region DefaultStyleKey

        static RepoFileListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoFileListBox), new FrameworkPropertyMetadata(typeof(RepoFileListBox)));
        }
        #endregion

        #region GetContainerForItemOverride

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RepoFileListItem();
        }
        #endregion
    }
}
