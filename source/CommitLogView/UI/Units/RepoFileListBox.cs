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

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext.Equals(SelectedItem))
            {
                ClickCommand?.Execute(SelectedItem);
            }
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            DoubleClickCommand?.Execute(SelectedItem);
        }
    }
}
