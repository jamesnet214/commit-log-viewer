namespace CommitLogView.Local.Data
{
    public interface IRepo
    { 
    
    }

    public class RepoTabContentItem : IRepo
    {
        public string Title { get; set; }
        public object ViewModel { get; set; }
        public string Tag { get; internal set; }
    }
    public class CommitTabContentItem : IRepo 
    {
        public string Title { get; set; }
        public object Content { get; set; }
        public string Tag { get; internal set; }
    }
}
