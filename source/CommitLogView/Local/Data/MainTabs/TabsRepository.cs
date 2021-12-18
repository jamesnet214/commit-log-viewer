using CommitLogView.Local.Data.Yamls;
using CommitLogView.Local.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommitLogView.Local.Data.MainTabs
{
    public class TabsRepository : TabsItemBasedModel
    {
        public RepositoryItem Repository { get; }
        public CommitContentModel CommitContentData { get; }
        public List<RevisionFileInfo> Markdowns { get; }

        public TabsRepository(RepositoryItem repository)
        {
            Header = repository.Name;
            Repository = repository;
            CommitContentData = new(repository);

            List<RevisionFileInfo> markdowns = new();
            RecrusiveSearchMarkdown(repository.Path, markdowns);
            Markdowns = markdowns;
        }

        private void RecrusiveSearchMarkdown(string repositoryPath, List<RevisionFileInfo> markdowns)
        {
            var dirs = Directory.GetDirectories(repositoryPath).ToList();
            var files = Directory.GetFiles(repositoryPath, "*.md");
            markdowns.AddRange(files.Select(x => new RevisionFileInfo(x)));

            dirs.ForEach(x => RecrusiveSearchMarkdown(x, markdowns));
        }

        internal void Select()
        {
            IsSelected = true;
        }

        public bool Equals(RepositoryItem obj)
        {
            if (obj is RepositoryItem repo)
            {
                return Repository.Path == repo.Path;
            }
            return base.Equals(obj);
        }
    }
}
