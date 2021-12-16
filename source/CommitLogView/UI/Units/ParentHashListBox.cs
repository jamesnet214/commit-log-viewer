using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
    }
}
