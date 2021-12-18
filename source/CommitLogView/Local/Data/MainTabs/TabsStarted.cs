using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitLogView.Local.Data.MainTabs
{
    public class TabsStarted : ITabsItemBase
    {
        public string Header { get; set; }

        public TabsStarted(string header)
        {
            Header = header;
        }
    }
}
