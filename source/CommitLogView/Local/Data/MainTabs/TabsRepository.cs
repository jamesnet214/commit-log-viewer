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
        public string Header { get; set; }
        public RepositoryItem Repository { get; set; }
        public CommitContentModel CommitContentData { get; set; }
        public TabsRepository(RepositoryItem repository)
        {
            Header = repository.Name;
            Repository = repository;
            CommitContentData = new(repository);
        }
    }
}
