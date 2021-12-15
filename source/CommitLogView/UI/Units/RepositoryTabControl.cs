using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class RepositoryTabControl : TabControl
    {
        static RepositoryTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepositoryTabControl), new FrameworkPropertyMetadata(typeof(RepositoryTabControl)));
        }

        public RepositoryTabControl()
        {
        }
    }
}
