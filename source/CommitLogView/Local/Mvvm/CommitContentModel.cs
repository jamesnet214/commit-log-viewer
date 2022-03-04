using LibGit2Sharp;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using DevNcore.UI.Foundation.Mvvm;
using CommitLogView.Local.Data;
using CommitLogView.Local.Data.Yamls;
using CommitLogView.Local.Builder;
using System.Windows;

namespace CommitLogView.Local.Mvvm
{
    public class CommitContentModel : ObservableObject
    {
        private RevisionInfo _commit;
        private List<RevisionInfo> _commits;
        private List<RevisionFileInfo> _changedFiles;

        public ICommand ClickCommand { get; set; }

        public List<RevisionInfo> Commits
        {
            get => _commits;
            set { _commits = value; OnPropertyChanged(); }
        }

        public RevisionInfo Commit
        {
            get => _commit;
            set { _commit = value; OnPropertyChanged(); CommitChanged(value); }
        }

        public List<RevisionFileInfo> ChangedFiles
        {
            get => _changedFiles;
            set { _changedFiles = value; OnPropertyChanged(); }
        }

        public List<RevisionFileInfo> Roots { get; }

        private readonly string Tag;

        public CommitContentModel(RepositoryItem repo)
        {
            Tag = repo.Path;
            ClickCommand = new RelayCommand<ParentInfo>(RevisionClick);
            Roots = StorageBuilder.Build().Repositories(repo.Path);
            Load();
        }

        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            base.OnLoaded(sender, e);
            //Load();
            //RepositoryConfig.Visit(Tag);
        }

        private async void Load()
        {
            var repo = new Repository(Tag);
            var branches = repo.Branches.Count();

            var query = from c in repo.Commits.Take(1000).AsQueryable()
                        select new RevisionInfo
                        {
                            Id = c.Id,
                            Sha = c.Sha,
                            ShaShort = c.Sha.Substring(0, 7),
                            MessageShort = c.MessageShort,
                            Ticks = c.Committer.When.DateTime.Ticks,
                            Author = c.Author,
                            When = c.Committer.When,
                            Parents = c.Parents.Select(x => new ParentInfo { Id = x.Id }).ToList()
                        };

            var commits = query.ToList();
            commits.Where(x => x.Parents.Count == 0).ToList().ForEach(x => x.IsFirst = true);

            RevisionInfo lst = null;
            foreach (var item in commits.OrderBy(x => x.When.DateTime))
            {
                if (item.IsFirst)
                {
                    item.Gen = 1;
                    lst = item;
                    continue;
                }

                if (lst == null)
                {
                    item.Gen = 1;
                    lst = item;
                }

                if (item.Parent.Id.Sha == lst.Sha)
                {
                    item.Gen = lst.Gen + 1;
                    lst = item;
                    continue;
                }
                else
                {
                    item.Gen = lst.Gen;
                    lst = item;
                    continue;
                }
            }

            RevisionInfo last = null;

            foreach (var item in commits.OrderBy(x => x.When.DateTime))
            {
                if (item.IsFirst == true)
                {
                    item.Line = 0;
                    last = item;
                    continue;
                }

                if (item.Parents.Count == 1)
                {
                    if (commits.FirstOrDefault(x => x.Sha == item.Parent.Id.Sha) is RevisionInfo rev)
                    {
                        item.Line = rev.Line;
                    }
                    last = item;
                }

                if (item.Gen == last.Gen)
                {
                    var _m = commits.Single(x => x.Sha == item.Id.Sha);
                    var _c = commits.FirstOrDefault(x => x.Sha == _m.Parent.Id.Sha);
                    if (_c == null)
                    {
                        continue;
                    }

                    foreach (var i in commits.Where(x => x.Gen > _c.Gen && x.Gen < item.Gen + 1))
                    {
                        i.Line += 1;
                    }

                    item.Line -= 1;

                    item.Line = item.Line < 0 ? 0 : item.Line;
                    _c.Line = 0;
                }

                if (item.Parents.Count == 2)
                {
                    item.IsMerge = true;
                    item.Line = 0;
                    last = item;
                }
            }
            Commits = commits;
            if (Commits.Any())
            {
                Commit = Commits.First();
            }
        }

        private void CommitChanged(RevisionInfo value)
        {
            foreach (var item in value.Parents)
            {
                value.Parents.ForEach(x => x.Line = Commits.Single(s => s.Sha == x.Id.Sha).Line);
            }

            var repo = new Repository(Tag.ToString());
            var source = new List<RevisionFileInfo>();

            Tree commitTree = repo.Commits.Single(x => x.Sha == value.Sha).Tree; // Main Tree
            Tree parentCommitTree = repo.Commits.Single(x => x.Sha == value.Parent.Id.Sha).Tree; // Secondary Tree

            var patch = repo.Diff.Compare<Patch>(parentCommitTree, commitTree); // Difference

            foreach (var ptc in patch)
            {
                var finfo = new RevisionFileInfo
                {
                    Status = ptc.Status,
                    Path = ptc.Path
                };
                source.Add(finfo);
            }
            ChangedFiles = source;
        }

        private void RevisionClick(ParentInfo obj)
        {
            Commit = Commits.Single(x => x.Sha == obj.Id.Sha);
        }
    }
}
