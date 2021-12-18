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
        private ObservableCollection<RepositoryGroup> _repositories;
        private List<RevisionFileInfo> _markdowns;

        public ICommand RepoClickCommand { get; set; }
        public ICommand RepoDoubleClickCommand { get; set; }

        public ObservableCollection<RepositoryGroup> Repositories
        {
            get => _repositories;
            set { _repositories = value; OnPropertyChanged(); }
        }

        public List<RevisionFileInfo> Markdowns
        {
            get => _markdowns;
            set { _markdowns = value; OnPropertyChanged(); }
        }

        public RepoContent Content { get; }

        public Action<RepositoryItem> TabsItemLoadEvent;
        public string Header { get; internal set; }
        public string Tag { get; internal set; }

        public RepoContentModel(Action<RepositoryItem> tabsItemLoad)
         {
            Content = new();
            Content.DataContext = this;
            TabsItemLoadEvent = tabsItemLoad;
            Header = "Find Repository";
            RepoClickCommand = new RelayCommand<object>(RepoClick);
            RepoDoubleClickCommand = new RelayCommand<object>(RepoDoubleClick);

            var source = RepositoryListBuilder.Build().Repositories();
            Repositories = new(source);
        }

        protected override void OnInitializedComponent()
        {
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
                List<RevisionFileInfo> markdowns = new();
                RecrusiveSearchMarkdown(repo.Path, markdowns);
                Markdowns = markdowns;
            }
        }

        private void RecrusiveSearchMarkdown(string repositoryPath, List<RevisionFileInfo> markdowns)
        {
            var dirs = Directory.GetDirectories(repositoryPath);
            var files = Directory.GetFiles(repositoryPath, "*.md");
            markdowns.AddRange(files.Select(x => new RevisionFileInfo(x)));

            dirs.ToList().ForEach(x => RecrusiveSearchMarkdown(x, markdowns));
        }
    }
}
