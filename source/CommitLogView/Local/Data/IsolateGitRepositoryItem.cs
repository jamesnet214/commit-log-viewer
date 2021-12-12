using System;

namespace CommitLogView.Local.Data
{
    public class IsolateGitRepositoryItem
    {
        public string Name { get; set; }
        public string RepositoryPath { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime Created { get; set; }
    }
}