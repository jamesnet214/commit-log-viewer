using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace CommitLogView.Local.Data
{
    public class RevisionInfo
    {
        public string Sha { get; set; }
        public string ShaShort { get; set; }
        public string MessageShort { get; set; }
        public ObjectId Id { get; set; }
        public List<ParentInfo> Parents { get; set; }
        public Signature Author { get; set; }
        public DateTimeOffset When { get; set; }
        public bool IsFirst { get; set; }
        public int Line { get; set; }
        public int Gen { get; set; }
        public long Ticks { get; set; }
        public bool IsMerge { get; set; }
        public int TotalLine { get; set; }

        public BitmapImage Avatar
        {
            get
            {
                if (Author.Email.Contains("+"))
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(string.Format("https://avatars1.githubusercontent.com/{0}", Author.Email.Split('@')[0].Split('+')[1]));
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
                return null;
            }
        }

        public ParentInfo Parent
        {
            get { return Parents.FirstOrDefault(); }
        }

        public bool ParentContains(ObjectId id)
        {
            return Parents.Select(x => x.Id).Contains(id);
        }
    }
}
