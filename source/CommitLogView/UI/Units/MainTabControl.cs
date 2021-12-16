using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class MainTabControl : TabControl
    {
        #region DefaultStyleKey

        static MainTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainTabControl), new FrameworkPropertyMetadata(typeof(MainTabControl)));
        }
        #endregion

        public MainTabControl()
        {
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MainTabItem();
        }
    }
}
