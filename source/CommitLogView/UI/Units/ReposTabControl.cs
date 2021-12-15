using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class ReposTabControl : TabControl
    {
        static ReposTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ReposTabControl), new FrameworkPropertyMetadata(typeof(ReposTabControl)));
        }

        public ReposTabControl()
        {
        }
    }
}
