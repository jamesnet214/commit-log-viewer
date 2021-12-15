using CommitLogView.UI.Views;
using System;
using System.Windows;

namespace CommitLogView
{
    public class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/CommitLogView;component/Themes/Units/ScrollViewer.xaml", UriKind.RelativeOrAbsolute) });
            Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/DevNcore.UI.Design.Geometry;component/Themes/Packages.xaml", UriKind.RelativeOrAbsolute) });
            var win = new MainWindow();

            win.ShowDialog();
        }
    }
}
