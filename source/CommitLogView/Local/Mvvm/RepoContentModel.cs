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

namespace CommitLogView.Local.Mvvm
{
    public class RepoContentModel : ObservableObject
    {
        private ObservableCollection<RepoHistoricalModel> _repositories;
        private List<RevisionFileInfo> _markdowns;

        public ICommand RepoClickCommand { get; set; }
        public ICommand RepoDoubleClickCommand { get; set; }

        public ObservableCollection<RepoHistoricalModel> Repositories
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

        public Action<IsolateGitRepositoryItem> TabsItemLoadEvent;
        public string Header { get; internal set; }
        public string Tag { get; internal set; }

        public RepoContentModel(Action<IsolateGitRepositoryItem> tabsItemLoad)
         {
            Content = new();
            Content.DataContext = this;
            TabsItemLoadEvent = tabsItemLoad;
            Header = "Find Repository";
            RepoClickCommand = new RelayCommand<object>(RepoClick);
            RepoDoubleClickCommand = new RelayCommand<object>(RepoDoubleClick);
            Repositories = new ObservableCollection<RepoHistoricalModel>();
        }

        protected override void OnInitializedComponent()
        {
            LoadRepositories();
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

        private void View_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var dir in files)
            {
                if (View.Parent is FrameworkElement fe && fe.DataContext is MainContentModel)
                {
                    RepositoryConfig.Access.Add(dir);
                }
            }
            RepositoryConfig.Access.Save();
            LoadRepositories();
        }

        private void LoadRepositories()
        {
            var source = RepositoryConfig.Access.Config.Repositories;
            var repos = new ObservableCollection<RepoHistoricalModel>();
            foreach (var item in source.OrderByDescending(x => x.LastAccessTime).GroupBy(x => x.LastAccessTime.ToString("yyyy-MM-dd")))
            {
                var date = new RepoHistoricalModel
                {
                    IsGroupHeader = true,
                    Name = item.Key,
                    Children = new ObservableCollection<IsolateGitRepositoryItem>()
                };
                item.OrderByDescending(x => x.LastAccessTime).ToList().ForEach(x => date.Children.Add(x));
                repos.Add(date);
            }
            Repositories = repos;
        }

        private void RepoDoubleClick(object obj)
        {
            if (obj is IsolateGitRepositoryItem repo)
            {
                TabsItemLoadEvent.Invoke(repo);
                RepositoryConfig.Access.Visit(repo.RepositoryPath);
                RepositoryConfig.Access.Save();
                LoadRepositories();
            }
        }

        private void RepoClick(object obj)
        {
            if (obj is IsolateGitRepositoryItem repo)
            {
                List<RevisionFileInfo> markdowns = new();
                RecrusiveSearchMarkdown(repo.RepositoryPath, markdowns);
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
