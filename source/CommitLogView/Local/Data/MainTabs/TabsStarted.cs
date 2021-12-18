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
