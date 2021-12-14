using CommitLogView.Local.Mvvm;
using System.Windows;

namespace CommitLogView.UI.Units
{
    public class CommitView : NcoreLayer
    {
        static CommitView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommitView), new FrameworkPropertyMetadata(typeof(CommitView)));
        }

        public CommitView()
        {
            DataContext = new CommitViewModel();
        }
    }
}
