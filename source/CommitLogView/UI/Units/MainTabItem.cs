using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class MainTabItem : TabItem
    {
        #region DefaultStyleKey
        static MainTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTabItem), new FrameworkPropertyMetadata(typeof(MainTabItem)));
        }
        #endregion
    }
}
