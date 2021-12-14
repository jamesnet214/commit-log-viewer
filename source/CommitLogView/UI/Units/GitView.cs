using CommitLogView.Local.Mvvm;
using DevNcore.UI.Foundation.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommitLogView.UI.Units
{
    public class GitView : NcoreView
    {
        public static readonly DependencyProperty SeqProperty = DependencyProperty.Register("Seq", typeof(int), typeof(GitView), new PropertyMetadata(0));

        public int Seq
        {
            get { return (int)this.GetValue(SeqProperty); }
            set { this.SetValue(SeqProperty, value); }
        }

        static GitView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GitView), new FrameworkPropertyMetadata(typeof(GitView)));
        }

        public GitView()
        {
            DataContext = new GitViewModel();
            Loaded += GitView_Loaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_TaskBar") is Grid taskBar)
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
