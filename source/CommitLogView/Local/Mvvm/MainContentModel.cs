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
        private readonly List<TabsRepository> RepoItems;
        public TabsStarted StartPage { get; }
        public RepoContentModel Workspace { get; }
        public ObservableCollection<TabsItemBasedModel> TabsContents { get; }
        public RepoContentModel Repository { get; }

        public MainContentModel()
        {
            RepoItems = new();
            Workspace = new(TabsItemLoad);
            StartPage = new("Getting Started.");
            
            TabsContents = new() { StartPage };
        }

        internal void TabsItemLoad(RepositoryItem repo)
        {
            if (RepoItems.FirstOrDefault(x => x.Equals(repo)) is TabsRepository tabsItem)
            {
                tabsItem.Select();
            }
            else
            {
                TabsRepository newContent = new(repo);
                RepoItems.Add(newContent);
                TabsContents.Add(newContent);
                newContent.Select();
            }
        }
    }
}
