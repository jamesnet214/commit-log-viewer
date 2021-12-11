using System;

namespace CommitLogViewer.Local.Data
{

    public class CommitLog
    {
        DateTime date = DateTime.Now;
        public string CommitId { get; set; }
        public string CommitName { get; set; }
        public string CommitEmail { get; set; }
        public DateTime CommitDate { get; set; }
        public string CommitComment { get; set; }
        public string StrDate { get; set; }

        public CommitLog(string line)
        {

            CommitId = line.Split(',')[0];
            CommitName = line.Split(',')[1];
            CommitEmail = line.Split(',')[2];
            CommitDate = DateTime.Parse(line.Split(',')[3]);
            CommitComment = GetLastAttach(line, 3);
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
