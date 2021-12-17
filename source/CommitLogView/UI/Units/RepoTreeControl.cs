using DevNcore.WPF.Controls;
using System.Windows;
using System.Windows.Input;

namespace CommitLogView.UI.Units
{
    public class RepoTreeControl : NcoreTreeControl
    {
        #region DefaultStyleKey

        static RepoTreeControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTreeControl), new FrameworkPropertyMetadata(typeof(RepoTreeControl)));
        }
        #endregion

        #region GetContainerForItemOverride
        
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RepoTreeItem();
        }
        #endregion

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement fe && fe.DataContext.Equals(SelectedItem))
            {
                DoubleClickCommand?.Execute(SelectedItem);
                e.Handled = true;
            }
            base.OnMouseDoubleClick(e);
        }
    }
}
