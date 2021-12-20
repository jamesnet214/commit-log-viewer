using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DevNcore.UI.Foundation.Mvvm;
using CommitLogView.Local.Data.Yamls;
using CommitLogView.Local.Data.MainTabs;
using CommitLogView.Local.Builder;

namespace CommitLogView.Local.Mvvm
{
    public class MainContentModel : ObservableObject
    {
        private readonly List<TabsRepository> RepoItems;

        public ICommand RepoClickCommand { get; }
        public TabsStarted StartPage { get; }
        public ObservableCollection<TabsItemBasedModel> TabsContents { get; }
        public List<RepositoryGroup> Repositories { get; }

        public MainContentModel()
        {
            RepoItems = new();
            StartPage = new("Getting Started.");            
            TabsContents = new() { StartPage };
            Repositories = SettingsBuilder.Build().Repositories();

            RepoClickCommand = new RelayCommand<object>(RepoClick);
        }

        private void RepoClick(object obj)
        {
            if (obj is RepositoryItem repo)
            {
                TabsItemLoad(repo);
            }
        }

        private void TabsItemLoad(RepositoryItem repo)
        {
            switch (RepoItems.FirstOrDefault(x => x.Equals(repo)))
            {
                case TabsRepository tabsItem:
                    tabsItem.Select();
                    break;
                default:
                    TabsRepository newContent = new(repo);
                    RepoItems.Add(newContent);
                    TabsContents.Add(newContent);
                    newContent.Select();
                    break;
            }
        }
    }
}
