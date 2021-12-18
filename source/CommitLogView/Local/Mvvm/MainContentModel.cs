using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevNcore.UI.Foundation.Mvvm;
using CommitLogView.Local.Data;

namespace CommitLogView.Local.Mvvm
{
    public class MainContentModel : ObservableObject
    {
        private RepoContentModel Workspace = null;
        private List<CommitContentModel> TabsItems = null; 
        public ObservableCollection<ObservableObject> TabsContents { get; }

        public MainContentModel()
        {
            TabsItems = new();
            Workspace = new(TabsItemLoad);
            TabsContents = new() { Workspace };
        }

        internal void TabsItemLoad(IsolateGitRepositoryItem repo)
        {
            CommitContentModel newContent = new(repo);
            TabsItems.Add(newContent);
            TabsContents.Add(newContent);
        }
    }
}
