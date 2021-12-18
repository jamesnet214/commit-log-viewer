using CommitLogView.Local.Data.Yamls;
using CommitLogView.Local.Mvvm;
using DevNcore.WPF.Controls;
using System.Windows;

namespace CommitLogView.UI.Units
{
    public class CommitContent : NcoreContent
    {
        #region DefaultStyleKey

        static CommitContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitContent), new FrameworkPropertyMetadata(typeof(CommitContent)));
        }
        #endregion

        public CommitContent(RepositoryItem repository) 
        {
            DataContext = new CommitContentModel(repository);
        }
    }
}
