using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevNcore.UI.Foundation.Mvvm;
using CommitLogView.Local.Data;
using CommitLogView.Local.Settings;
using CommitLogView.Local.Data.Yamls;
using CommitLogView.Local.Data.MainTabs;

namespace CommitLogView.Local.Mvvm
{
    public class MainContentModel : ObservableObject
    {
        private List<TabsRepository> TabsItems = null;
        public TabsStarted StartPage { get; }
        public RepoContentModel Workspace { get; }
        public ObservableCollection<ITabsItemBase> TabsContents { get; }
        public RepoContentModel Repository { get; }

        public MainContentModel()
        {
            TabsItems = new();
            Workspace = new(TabsItemLoad);
            StartPage = new("Getting Started");
            
            TabsContents = new() { StartPage };
        }

        internal void TabsItemLoad(RepositoryItem repo)
        {
            TabsRepository newContent = new(repo);
            TabsItems.Add(newContent);
            TabsContents.Add(newContent);
        }
    }
}
