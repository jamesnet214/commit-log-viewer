using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitLogView.Local.Data
{
    public class RevisionFileInfo
    {
        private string x;

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