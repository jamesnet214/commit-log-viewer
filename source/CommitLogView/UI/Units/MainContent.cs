using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommitLogView.Local.Mvvm;
using DevNcore.UI.Foundation.Mvvm;

namespace CommitLogView.UI.Units
{
    public class MainContent : NcoreView
    {
        #region DefaultStyleKey

        static MainContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainContent), new FrameworkPropertyMetadata(typeof(MainContent)));
        }
        #endregion

        public MainContent()
        {
            DataContext = new GitViewModel();
            Loaded += GitView_Loaded;
        }

        public static readonly DependencyProperty SeqProperty = DependencyProperty.Register("Seq", typeof(int), typeof(MainContent), new PropertyMetadata(0));

        public int Seq
        {
            get { return (int)this.GetValue(SeqProperty); }
            set { this.SetValue(SeqProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_Taskline") is StackPanel taskBar)
            {
                taskBar.MouseLeftButtonDown += TaskBar_MouseLeftButtonDown;
            }
        }

        private void TaskBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();
        }

        private void GitView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableObject vm)
            {
                vm.ForceViewLoaded(this);
            }
        }
    }
}
