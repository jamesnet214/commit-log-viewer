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

namespace CommitLogViewer.UI.Units
{
    public class KeywordView : ListBox
    {
        static KeywordView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KeywordView), new FrameworkPropertyMetadata(typeof(KeywordView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new KeywordItem();
        }
    }
}
