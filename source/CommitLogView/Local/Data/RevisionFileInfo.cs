using LibGit2Sharp;

namespace CommitLogView.Local.Data
{
    public class RevisionFileInfo
    {
        public RevisionFileInfo()
        {

        }

        public RevisionFileInfo(string path)
        {
            Path = path;
            FileName = System.IO.Path.GetFileName(path);
        }

        public ChangeKind Status { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Display => $"{Status}, {Path}";
    }
}