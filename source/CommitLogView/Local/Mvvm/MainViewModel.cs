using System.Collections.ObjectModel;
using DevNcore.UI.Foundation.Mvvm;
using CommitLogView.Local.Data;
using System.Collections.Generic;

namespace CommitLogView.Local.Mvvm
{
    public class MainContentViewModel : ObservableObject
    {
        private RepoContentViewModel RepoExplorer = null;
        private List<CommitContentViewModel> Repositories = null; 
        public ObservableCollection<ObservableObject> TabsContents { get; }

        public MainContentViewModel()
        {
            Repositories = new();
            RepoExplorer = new(RepoOpenLoad);
            TabsContents = new() { RepoExplorer };
        }

        internal void RepoOpenLoad(IsolateGitRepositoryItem repo)
        {
            CommitContentViewModel newContent = new(repo);
            Repositories.Add(newContent);
            TabsContents.Add(newContent);
        }
    }
}
