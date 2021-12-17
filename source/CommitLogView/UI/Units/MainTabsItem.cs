using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class MainTabsItem : TabItem
    {
        #region DefaultStyleKey

        static MainTabsItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTabsItem), new FrameworkPropertyMetadata(typeof(MainTabsItem)));
        }
        #endregion
    }
}
