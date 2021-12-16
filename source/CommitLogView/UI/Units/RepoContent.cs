using System.Windows;
using CommitLogView.Local.Mvvm;

namespace CommitLogView.UI.Units
{
    public class RepoContent : NcoreContent
    {
        #region RepoContent

        static RepoContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoContent), new FrameworkPropertyMetadata(typeof(RepoContent)));
        }
        #endregion

        public RepoContent()
        {
            DataContext = new RepoViewModel();
        }
    }
}
