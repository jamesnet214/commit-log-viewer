using DevNcore.WPF.Controls;
using System.Windows;

namespace CommitLogView.UI.Units
{
    public class StartedContent : NcoreContent
    {
        static StartedContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StartedContent), new FrameworkPropertyMetadata(typeof(StartedContent)));
        }
    }
}
