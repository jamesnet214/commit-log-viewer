using CommitLogView.Local.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
