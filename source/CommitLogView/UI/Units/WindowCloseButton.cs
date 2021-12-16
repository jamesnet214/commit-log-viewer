using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class WindowCloseButton : Button
    {
        #region DefaultStyleKey

        static WindowCloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowCloseButton), new FrameworkPropertyMetadata(typeof(WindowCloseButton)));
        }
        #endregion
    }
}
