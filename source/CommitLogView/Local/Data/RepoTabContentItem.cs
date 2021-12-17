namespace CommitLogView.Local.Data
{
    public interface IRepo
    { 
        object ViewModel { get; set; }
    }

    public class RepoTabContentItem : IRepo
    {
        public string Title { get; set; }
        public object ViewModel { get; set; }
        public string Tag { get; internal set; }
        public bool IsSelected { get; set; }
    }
    public class CommitTabContentItem : IRepo 
    {
        public string Title { get; set; }
        public object ViewModel { get; set; }
        public string Tag { get; internal set; }
        public bool IsSelected { get; set; }
    }
}
