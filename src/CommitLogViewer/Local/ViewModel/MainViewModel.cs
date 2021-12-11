using CommitLogViewer.Local.Data;
using CommitLogViewer.Local.FileStream;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CommitLogViewer.Local.Mvvm
{
    public class MainViewModel : ObservableObject
    {
        public ICommand KeyDownCommand { get; set; }

        private string _keyword;
        public string Keyword
        {
            get => _keyword;
            set { _keyword = value; KeywordChanged(value); OnPropertyChanged(); }
        }

        public List<CommitLog> CommitLogs { get; set; }

        public MainViewModel()
        {
            CommitLogs = CsvStreamBuilder.Instance.LoadCsv();
            KeyDownCommand = new RelayCommand<object>(KeydownChanged);
        }

        private void KeydownChanged(object obj)
        {
            //
        }

        private void KeywordChanged(string value)
        {
            string[] keywords = value.Split(';');
            CommitLogs.ForEach(x => x.Visibility = System.Windows.Visibility.Visible);

            foreach (var keyword in keywords)
            {
                if (keyword.Contains('%'))
                {
                    CommitLogs.Where(x => x.CommitComment.ToLower().Contains(keyword.ToLower().Replace("%", "")))
                        .ToList().ForEach(x => x.Visibility = System.Windows.Visibility.Collapsed);
                }
                else
                {
                    CommitLogs.Where(x => x.CommitComment.ToLower().Equals(keyword.ToLower()))
                        .ToList().ForEach(x => x.Visibility = System.Windows.Visibility.Collapsed);
                }
            }
        }
    }
}
