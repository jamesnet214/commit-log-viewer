using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class MainTabs : TabControl
    {
        #region DefaultStyleKey

        static MainTabs()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTabs), new FrameworkPropertyMetadata(typeof(MainTabs)));
        }
        #endregion

        public MainTabs()
        {
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MainTabsItem();
        }
    }
}
