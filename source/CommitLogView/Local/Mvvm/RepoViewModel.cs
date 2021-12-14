using CommitLogView.Local.Data;
using DevNcore.UI.Foundation.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CommitLogView.Local.Mvvm
{
    public class RepoViewModel : ObservableObject
    {
        #region . Commands .

        public ICommand RepoClickCommand { get; set; }
        public ICommand RepoDoubleClickCommand { get; set; }
        #endregion

        #region . Repositories .

        private ObservableCollection<RepoHistoricalModel> _repositories;
        public ObservableCollection<RepoHistoricalModel> Repositories
        {
            get { return _repositories; }
            set { _repositories = value; OnPropertyChanged(); }
        }
        #endregion

        #region . Markdowns .

        private List<RevisionFileInfo> _markdowns;
        public List<RevisionFileInfo> Markdowns
        {
            get { return _markdowns; }
            set { _markdowns = value; OnPropertyChanged(); }
        }
        #endregion

        #region . Constructor .

        public RepoViewModel()
         {
            RepoClickCommand = new RelayCommand<object>(RepoClick);
            RepoDoubleClickCommand = new RelayCommand<object>(RepoDoubleClick);
            Repositories = new ObservableCollection<RepoHistoricalModel>();
        }
        #endregion

        protected override void OnInitializedComponent()
        {
            LoadRepositories();
        }

        #region . View_DragEnter .

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
        #endregion

        #region . View_Drop .

        private void View_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var dir in files)
            {
                if (View.Parent is FrameworkElement fe && fe.DataContext is GitViewModel vm)
                {
                    RepositoryConfig.Access.Add(dir);
                }
            }
            RepositoryConfig.Access.Save();
            LoadRepositories();
        }
        #endregion

        #region . LoadRepositories .

        private void LoadRepositories()
        {
            var source = RepositoryConfig.Access.Config.Repositories;
            var repos = new ObservableCollection<RepoHistoricalModel>();
            foreach (var item in source.OrderByDescending(x => x.LastAccessTime).GroupBy(x => x.LastAccessTime.ToString("yyyy-MM-dd")))
            {
                var date = new RepoHistoricalModel();
                date.IsGroupHeader = true;
                date.Name = item.Key;
                date.Children = new ObservableCollection<IsolateGitRepositoryItem>();
                item.OrderByDescending(x => x.LastAccessTime).ToList().ForEach(x => date.Children.Add(x));
                repos.Add(date);
            }
            Repositories = repos;
        }
        #endregion

        #region . RepoDoubleClick .

        private void RepoDoubleClick(object obj)
        {
            if (obj is IsolateGitRepositoryItem repo)
            {
                if (View.Parent is FrameworkElement fe && fe.DataContext is GitViewModel vm)
                {
                    vm.Add(repo.RepositoryPath);
                    RepositoryConfig.Access.Visit(repo.RepositoryPath);
                    RepositoryConfig.Access.Save();
                    LoadRepositories();
                }
            }
        }
        #endregion

        #region . RepoClick .

        private void RepoClick(object obj)
        {
            if (obj is IsolateGitRepositoryItem repo)
            {
                List<RevisionFileInfo> markdowns = new List<RevisionFileInfo>();
                RecrusiveSearchMarkdown(repo.RepositoryPath, markdowns);
                Markdowns = markdowns;
            }
        }
        #endregion

        #region . RecrusiveSearchMarkdown .

        private void RecrusiveSearchMarkdown(string repositoryPath, List<RevisionFileInfo> markdowns)
        {
            var dirs = Directory.GetDirectories(repositoryPath);
            var files = Directory.GetFiles(repositoryPath, "*.md");
            markdowns.AddRange(files.Select(x => new RevisionFileInfo(x)));

            dirs.ToList().ForEach(x => RecrusiveSearchMarkdown(x, markdowns));
        }
        #endregion
    }
}
