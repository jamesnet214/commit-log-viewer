using CommitLogViewer.Local.Mvvm;
using System;
using System.Windows;

namespace CommitLogViewer.Local.Data
{

    public class CommitLog : ObservableObject
    {
        DateTime date = DateTime.Now;
        public string CommitId { get; set; }
        public string CommitName { get; set; }
        public string CommitEmail { get; set; }
        public DateTime CommitDate { get; set; }
        public string CommitComment { get; set; }
        public string StrDate { get; set; }

        private Visibility _visibility;
        public Visibility Visibility
        {
            get => _visibility;
            set { _visibility = value; OnPropertyChanged(); }
        }

        public CommitLog(string line)
        {
            CommitId = line.Split(',')[0].Trim();
            CommitName = line.Split(',')[1].Trim();
            CommitEmail = line.Split(',')[2].Trim();
            CommitDate = DateTime.Parse(line.Split(',')[3]);
            CommitComment = GetLastAttach(line, 3).Trim();
            TimeSpan timeDiff = date - CommitDate;
            int diffDays = timeDiff.Days; 
            int diffHoures = timeDiff.Hours; 
            int diffMiniute = timeDiff.Minutes; 
            int diffSecond = timeDiff.Seconds;        
        
            if (diffSecond != 0)
            {
                StrDate = diffDays.ToString() + "seconds ago";
            }
            if (diffMiniute != 0)
            {
                StrDate = diffDays.ToString() + "minutes ago";
            }
            if (diffHoures != 0)
            {
                StrDate = diffDays.ToString() + "hour ago";
            }
            if (diffDays != 0)
            {
                StrDate = diffDays.ToString() + "days ago";
            }



        }

        private string GetLastAttach(string line, int count)
        {
            int index = 0;
            string text = "";
            foreach (var t in line.Split(','))
            {
                if (index > count)
                {
                    text += t;
                }
                index++;
            }
            return text.TrimEnd('\'');
        }
    }
}
