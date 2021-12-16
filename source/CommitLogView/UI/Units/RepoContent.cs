using System.Windows;
using CommitLogView.Local.Mvvm;

namespace CommitLogView.UI.Units
{
    public class RepoContent : NcoreLayer
    {
        static RepoContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoContent), new FrameworkPropertyMetadata(typeof(RepoContent)));
        }

        public RepoContent()
        {
            DataContext = new RepoViewModel();
        }
    }
}
