using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitLogView.Local.Data.Yamls
{
    public class RepositoryGroup
    {
        public string Name { get; set; }
        public bool IsGroupHeader { get; set; } = true;
        public List<RepositoryItem> Repositories { get; set; }
    }
}
