using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevNcore.UI.Foundation.Mvvm;
using CommitLogView.Local.Data.Yamls;
using CommitLogView.Local.Data.MainTabs;
using System.Linq;

namespace CommitLogView.Local.Mvvm
{
    public class MainContentModel : ObservableObject
    {
        private readonly List<TabsRepository> TabsItems;
        public TabsStarted StartPage { get; }
        public RepoContentModel Workspace { get; }
        public ObservableCollection<TabsItemBasedModel> TabsContents { get; }
        public RepoContentModel Repository { get; }

        public MainContentModel()
        {
            TabsItems = new();
            Workspace = new(TabsItemLoad);
            StartPage = new("Getting Started.");
            
            TabsContents = new() { StartPage };
        }

        internal void TabsItemLoad(RepositoryItem repo)
        {
            if (TabsItems.FirstOrDefault(x => x.Equals(repo)) is TabsRepository tabsItem)
            {
                tabsItem.Select();
            }
            else
            {
                TabsRepository newContent = new(repo);
                TabsItems.Add(newContent);
                TabsContents.Add(newContent);
            }
        }
    }
}
