using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class RepoTabItem : TabItem
    {
        #region DefaultStyleKey

        static RepoTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTabItem), new FrameworkPropertyMetadata(typeof(RepoTabItem)));
        }
        #endregion

        public RepoTabItem()
        {
        }
    }
}
