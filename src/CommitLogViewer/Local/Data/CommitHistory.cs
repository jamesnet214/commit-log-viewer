using System;

namespace CommitLogViewer.Local.Data
{
    public class CommitLog
    {
        public string CommitId { get; set; }
        public string CommitName { get; set; }
        public string CommitEmail { get; set; }
        public DateTime? CommitDate { get; set; }
        public string CommitComment { get; set; }

        public CommitLog(string line)
        {
            CommitId = line.Split(',')[0];
            CommitName = line.Split(',')[1];
            CommitEmail = line.Split(',')[2];
            CommitDate = DateTime.Parse(line.Split(',')[3]);
            CommitComment = GetLastAttach(line, 3);
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
