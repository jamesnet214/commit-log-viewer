using DevNcore.WPF.Controls;
using System.Windows;

namespace CommitLogView.UI.Units
{
    public class CommitHashListBox : NcoreListControl
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
