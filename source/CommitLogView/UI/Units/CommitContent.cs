using System.Windows;
using CommitLogView.Local.Mvvm;

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

        public CommitContent()
        {
            DataContext = new CommitViewModel();
        }
    }
}
