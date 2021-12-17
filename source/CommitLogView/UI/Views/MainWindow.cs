using System.Windows;

namespace CommitLogView.UI.Views
{
    public class MainWindow : Window
    {
        #region DefaultStyleKey

        static MainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindow), new FrameworkPropertyMetadata(typeof(MainWindow)));
        }
        #endregion

        public MainWindow()
        {
            Title = "GitHub";
            WindowStyle = WindowStyle.None;
            SizeToContent = SizeToContent.WidthAndHeight;
            AllowsTransparency = true;
        }
    }
}
