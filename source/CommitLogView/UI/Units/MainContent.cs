using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommitLogView.Local.Mvvm;
using DevNcore.UI.Foundation.Mvvm;

namespace CommitLogView.UI.Units
{
    public class MainContent : NcoreContent
    {
        #region DefaultStyleKey

        static MainContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainContent), new FrameworkPropertyMetadata(typeof(MainContent)));
        }
        #endregion

        public MainContent()
        {
            DataContext = new MainContentViewModel();
            Loaded += GitView_Loaded;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_Taskline") is StackPanel taskBar)
            {
                taskBar.MouseLeftButtonDown += TaskBar_MouseLeftButtonDown;
            }
            if (GetTemplateChild("PART_Close") is Button button)
            {
                button.Click += (s, e) => Window.GetWindow(this).Close();
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
