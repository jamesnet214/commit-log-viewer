using System.Windows;

namespace CommitLogView.UI.Units
{
    public class ParentHashListBox : RepoFileListBox
    {
        #region DefaultStyleKey

        static ParentHashListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ParentHashListBox), new FrameworkPropertyMetadata(typeof(ParentHashListBox)));
        }
        #endregion

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ParentHashListItem();
        }
    }
}
