using System.Windows;
using System.Windows.Controls.Primitives;

namespace CommitLogView.UI.Units
{
    public class RepoTreeItemExpander : ToggleButton
    {
        #region DefaultStyleKey

        static RepoTreeItemExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTreeItemExpander), new FrameworkPropertyMetadata(typeof(RepoTreeItemExpander)));
        }
        #endregion
    }
}
