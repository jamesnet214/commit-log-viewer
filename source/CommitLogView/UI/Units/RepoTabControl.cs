using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class RepoTabControl : TabControl
    {
        #region DefaultStyleKey

        static RepoTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RepoTabControl), new FrameworkPropertyMetadata(typeof(RepoTabControl)));
        }
        #endregion

        public RepoTabControl()
        {
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RepoTabItem();
        }
    }
}
