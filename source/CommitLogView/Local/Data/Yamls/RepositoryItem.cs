namespace CommitLogView.Local.Data.Yamls
{
    public class RepositoryItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsGroupHeader { get; set; } = false;
    }
}