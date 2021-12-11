using CommitLogViewer.Local.Data;
using CommitLogViewer.Local.FileStream;
using System.Collections.Generic;

namespace CommitLogViewer.Local.Mvvm
{
    public class MainViewModel : ObservableObject
    {
        public List<CommitLog> CommitLogs { get; set; }

        public MainViewModel()
        {
            CommitLogs = CsvStreamBuilder.Instance.LoadCsv();
        }
    }
}
