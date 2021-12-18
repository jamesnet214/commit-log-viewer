using System.Collections.Generic;

namespace CommitLogView.Local.Data.Yamls
{
    public class Configs
    {
        public List<RepositoryGroup> RepositoryGroup { get; set; }
        public IgnoreFields Ignore { get; set; }
    }
}
