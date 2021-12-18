using DevNcore.WPF.Controls;
using System.Windows;

namespace CommitLogView.UI.Units
{
    public class CommitListBox : NcoreListControl
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
