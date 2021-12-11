using System.Windows;
using System.Windows.Controls;

namespace CommitLogViewer.UI.Units
{
    public class CommitLogView : ListBox
    {
        static CommitLogView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitLogView), new FrameworkPropertyMetadata(typeof(CommitLogView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CommitLogItem();
        }
    }
}
