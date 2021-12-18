using System.Windows;
using System.Windows.Controls.Primitives;

namespace CommitLogView.UI.Units
{
    public class MainTreeItemExpander : ToggleButton
    {
        #region DefaultStyleKey

        static MainTreeItemExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTreeItemExpander), new FrameworkPropertyMetadata(typeof(MainTreeItemExpander)));
        }
        #endregion
    }
}
