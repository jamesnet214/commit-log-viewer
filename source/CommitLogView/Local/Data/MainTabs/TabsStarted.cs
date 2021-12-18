using CommitLogView.UI.Units;

namespace CommitLogView.Local.Data.MainTabs
{
    public class TabsStarted : TabsItemBasedModel
    {
        public TabsStarted(string header)
        {
            TabsItemType = "FirstPage";
            Header = header;
            Content = new StartedContent();
        }
    }
}
