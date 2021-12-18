using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommitLogView.Local.Data;
using DevNcore.UI.Foundation.Mvvm;
using System;
using CommitLogView.UI.Units;
using CommitLogView.Local.Settings;
using CommitLogView.Local.Data.Yamls;

namespace CommitLogView.Local.Mvvm
{
    public class RepoContentModel : ObservableObject
    {
        public ICommand RepoClickCommand { get; }
        public ICommand RepoDoubleClickCommand { get; }
        public ObservableCollection<RepositoryGroup> Repositories { get; }
        private Action<RepositoryItem> TabsItemLoadEvent;

        public RepoContentModel(Action<RepositoryItem> tabsItemLoad)
         {
            TabsItemLoadEvent = tabsItemLoad;
            RepoClickCommand = new RelayCommand<object>(RepoClick);
            RepoDoubleClickCommand = new RelayCommand<object>(RepoDoubleClick);

            var source = RepositoryListBuilder.Build().Repositories();
            Repositories = new(source);
        }

        private void View_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void RepoDoubleClick(object obj)
        {
            if (obj is RepositoryItem repo)
            {
                TabsItemLoadEvent.Invoke(repo);
            }
        }

        private void RepoClick(object obj)
        {
            if (obj is RepositoryItem repo)
            {
                //TabsItemLoadEvent.Invoke(repo);
            }
        }
    }
}
