using CommitLogView.Local.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommitLogView.Local.Builder
{
    internal class StorageBuilder
    {
        public static StorageBuilder Build()
        {
            return new StorageBuilder();
        }

        private StorageBuilder()
        { 
        
        }

        public List<RevisionFileInfo> Repositories(string path)
        {
            List<RevisionFileInfo> source = new();
            RecrusiveSearchMarkdown(path, source);
            return source;
        }

        private void RecrusiveSearchMarkdown(string repositoryPath, List<RevisionFileInfo> source)
        {
            string[] fields = SettingsBuilder.Build().Ignore().Root;
            if (!fields.Any(x => repositoryPath.EndsWith(x)))
            {
                var dirs = Directory.GetDirectories(repositoryPath).ToList();
                var files = Directory.GetFiles(repositoryPath);
                source.AddRange(dirs.Select(x => new RevisionFileInfo(x, true)));
                source.AddRange(files.Select(x => new RevisionFileInfo(x, false)));
                dirs.ForEach(x => RecrusiveSearchMarkdown(x, source.Single(y => y.Path == x).Children));
            }
        }
    }
}
