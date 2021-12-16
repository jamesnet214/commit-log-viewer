using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    internal class ParentHashListItem : ListBoxItem
    {
        #region DefaultStyleKey

        static ParentHashListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ParentHashListItem), new FrameworkPropertyMetadata(typeof(ParentHashListItem)));
        }
        #endregion
    }
}