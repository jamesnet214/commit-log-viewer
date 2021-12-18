using System.Windows.Input;
using System.Collections.Generic;
using DevNcore.UI.Foundation.Mvvm;
using System;
using CommitLogView.Local.Settings;
using CommitLogView.Local.Data.Yamls;

namespace CommitLogView.Local.Mvvm
{
    public class RepoContentModel : ObservableObject
    {
        private readonly Action<RepositoryItem> TabsItemLoadEvent;

        public ICommand RepoClickCommand { get; }
        public ICommand RepoDoubleClickCommand { get; }
        public List<RepositoryGroup> Repositories { get; }

        public RepoContentModel(Action<RepositoryItem> tabsItemLoad)
         {
            TabsItemLoadEvent = tabsItemLoad;
            RepoClickCommand = new RelayCommand<object>(RepoClick);
            RepoDoubleClickCommand = new RelayCommand<object>(RepoDoubleClick);

            Repositories = RepositoryListBuilder.Build().Repositories();
        }

        private void RepoDoubleClick(object obj)
        {
            if (obj is RepositoryItem repo)
            {
            }
        }

        private void RepoClick(object obj)
        {
            if (obj is RepositoryItem repo)
            {
                TabsItemLoadEvent.Invoke(repo);
            }
        }
    }
}
