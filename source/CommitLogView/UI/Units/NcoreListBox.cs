using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommitLogView.UI.Units
{
    public class NcoreListBox : ListBox
    {
        public static readonly DependencyProperty ClickCommandProperty = DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(NcoreListBox));
        public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(NcoreListBox));

        public ICommand ClickCommand
        {
            get { return (ICommand)this.GetValue(ClickCommandProperty); }
            set { this.SetValue(ClickCommandProperty, value); }
        }

        public ICommand DoubleClickCommand
        {
            get { return (ICommand)this.GetValue(DoubleClickCommandProperty); }
            set { this.SetValue(DoubleClickCommandProperty, value); }
        }

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
