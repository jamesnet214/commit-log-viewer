using DevNcore.WPF.Controls;
using System.Windows;
using System.Windows.Input;

namespace CommitLogView.UI.Units
{
    public class RootTreeControl : NcoreTreeControl
    {
        #region DefaultStyleKey

        static RootTreeControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RootTreeControl), new FrameworkPropertyMetadata(typeof(RootTreeControl)));
        }
        #endregion

        #region GetContainerForItemOverride

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RootTreeItem();
        }
        #endregion

        //protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        //{
        //    base.OnPreviewMouseUp(e);

        //    if (e.OriginalSource is FrameworkElement fe && fe.DataContext.Equals(SelectedItem))
        //    {
        //        ClickCommand?.Execute(SelectedItem);
        //    }
        //}

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            DoubleClickCommand?.Execute(SelectedItem);
        }
    }
}
