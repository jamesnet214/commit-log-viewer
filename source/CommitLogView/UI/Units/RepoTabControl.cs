using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class RepoTabControl : TabControl
    {
        #region DefaultStyleKey

        static RepoTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTabControl), new FrameworkPropertyMetadata(typeof(RepoTabControl)));
        }
        #endregion

        public RepoTabControl()
        {
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RepoTabItem();
        }
    }
}
