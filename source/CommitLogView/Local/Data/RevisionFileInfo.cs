using LibGit2Sharp;
using System.Collections.Generic;

namespace CommitLogView.Local.Data
{
    public class RevisionFileInfo
    {
        public RevisionFileInfo()
        {

        }

        public RevisionFileInfo(string path, bool isDirectory)
        {
            IsDirectory = isDirectory;
            Path = path;
            FileName = System.IO.Path.GetFileName(path);
            Children = new();
        }

        public ChangeKind Status { get; set; }
        public string Path { get; set; }
        public bool IsDirectory { get; set; }
        public string FileName { get; set; }
        public string Display => $"{Status}, {Path}";

        public List<RevisionFileInfo> Children { get; set; }
    }
}