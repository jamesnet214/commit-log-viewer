using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CommitLogView.UI.Units;
using DevNcore.UI.Foundation.Mvvm;

namespace CommitLogView.Local.Mvvm
{
    public class MainViewModel : ObservableObject
    {
        private RepoViewModel RepoExplorer = null;
        public ObservableCollection<ObservableObject> TabsContents { get; }

        public MainViewModel()
        {
            RepoExplorer = new(RepoOpenLoad);
            TabsContents = new() { RepoExplorer };
        }

        internal void RepoOpenLoad(string dir)
        {
            if (true)
            {
                var name = Path.GetFileNameWithoutExtension(dir);
                TabsContents.Add(new CommitViewModel { Tag = dir, Header = name });
            }
            else
            {
                //Repositories2.Single(x => x.ViewModel.Equals(LayerItems[dir])).IsSelected = true;
            }
        }
    }
}
