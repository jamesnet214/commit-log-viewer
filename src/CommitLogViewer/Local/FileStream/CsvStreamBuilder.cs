using CommitLogViewer.Local.Data;
using System.Collections.Generic;
using System.IO;

namespace CommitLogViewer.Local.FileStream
{
    public class CsvStreamBuilder
    {
        public static CsvStreamBuilder Instance = null;

        private CsvStreamBuilder()
        {

        }

        static CsvStreamBuilder()
        {
            Instance = new CsvStreamBuilder();
        }

        public List<CommitLog> LoadCsv()
        {
            using (var reader = new StreamReader(@"history.csv"))
            {
                List<CommitLog> source = new List<CommitLog>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    source.Add(new CommitLog(line));
                }
                return source;
            }
        }
    }
}
