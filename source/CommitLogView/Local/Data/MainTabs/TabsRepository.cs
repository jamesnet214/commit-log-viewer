using CommitLogView.Local.Data.Yamls;
using CommitLogView.Local.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitLogView.Local.Data.MainTabs
{
    internal class TabsRepository : ITabsItemBase
    {
        public string Header { get; }
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
    }
}
