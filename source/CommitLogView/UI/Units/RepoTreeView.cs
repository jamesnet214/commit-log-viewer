using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommitLogView.UI.Units
{
    public class RepoTreeView : TreeView
    {
        #region DefaultStyleKey

        static RepoTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTreeView), new FrameworkPropertyMetadata(typeof(RepoTreeView)));
        }
        #endregion

        public RepoTreeView()
        { 
        
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(RepoTreeView));
        public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(RepoTreeView));

        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public ICommand DoubleClickCommand
        {
            get { return (ICommand)this.GetValue(DoubleClickCommandProperty); }
            set { this.SetValue(DoubleClickCommandProperty, value); }
        }

        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            base.OnSelectedItemChanged(e);
            Command?.Execute(e.NewValue);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext.Equals(SelectedItem))
            {
                DoubleClickCommand?.Execute(SelectedItem);
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RepoTreeItem();
        }
    }
}
