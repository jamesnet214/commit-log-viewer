using CommitLogView.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommitLogView
{
    public class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/CommitLogView;component/Themes/Units/ScrollViewer.xaml", UriKind.RelativeOrAbsolute) });
            var win = new MainWindow();

            win.ShowDialog();
        }
    }
}
