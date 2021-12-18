using DevNcore.WPF.Controls;
using System.Windows;
using System.Windows.Input;

namespace CommitLogView.UI.Units
{
    public class MainTreeControl : NcoreTreeControl
    {
        #region DefaultStyleKey

        static MainTreeControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTreeControl), new FrameworkPropertyMetadata(typeof(MainTreeControl)));
        }
        #endregion

        #region GetContainerForItemOverride
        
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MainTreeItem();
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

        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            base.OnSelectedItemChanged(e);
            Command?.Execute(e.NewValue);
        }
    }
}
