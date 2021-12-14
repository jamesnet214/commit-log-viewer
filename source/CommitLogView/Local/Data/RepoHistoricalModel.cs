using System;
using System.Collections.ObjectModel;

namespace CommitLogView.Local.Data
{
    public class RepoHistoricalModel
    {
        public bool IsGroupHeader { get; set; }
        public string Name { get; set; }
        public DateTime Lasted { get; set; }
        public ObservableCollection<IsolateGitRepositoryItem> Children { get; set; }
    }
}
