using DevNcore.UI.Foundation.Mvvm;
using System.Windows.Controls;

namespace CommitLogView.UI.Units
{
    public class NcoreLayer : UserControl
    {
        public NcoreLayer()
        {
            Loaded += NcoreLayer_Loaded;
        }

        private void NcoreLayer_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is ObservableObject vm)
            {
                vm.ForceViewLoaded(this);
            }
        }
    }
}
