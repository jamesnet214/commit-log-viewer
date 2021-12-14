using System.Windows;
using CommitLogView.Local.Mvvm;

namespace CommitLogView.UI.Units
{
    public class RepoView : NcoreLayer
    {
        static RepoView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoView), new FrameworkPropertyMetadata(typeof(RepoView)));
        }

        public RepoView()
        {
            DataContext = new RepoViewModel();
        }
    }
}
