using System.Windows;

namespace CommitLogView.UI.Units
{
    public class RepoContent : NcoreContent
    {
        #region DefaultStyleKey

        static RepoContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoContent), new FrameworkPropertyMetadata(typeof(RepoContent)));
        }
        #endregion
    }
}
