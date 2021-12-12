using CommitLogViewer.Local.Data;
using CommitLogViewer.Local.FileStream;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            set { _keyword = value; OnPropertyChanged(); }
        }

        public List<CommitLog> CommitLogs { get; set; }
        public ObservableCollection<KeywordModel> Keywords { get; set; }

        public MainViewModel()
        {
            CommitLogs = CsvStreamBuilder.Instance.LoadCsv();
            KeyDownCommand = new RelayCommand<object>(KeydownChanged);
            Keywords = new ObservableCollection<KeywordModel>();
        }

        private void KeydownChanged(object obj)
        {
            string[] keywords = Keyword.Split(';');

            foreach (string keword in keywords)
            {
                if (string.IsNullOrWhiteSpace(keword))
                {
                    continue;
                }
                if (Keywords.FirstOrDefault(x => x.Keyword.Trim().ToLower() == Keyword.Trim().ToLower()) == null)
                {
                    Keywords.Add(new KeywordModel { Keyword = keword });
                }
            }

            Keyword = "";
            KeywordChanged();
        }

        private void KeywordChanged()
        {
            CommitLogs.ForEach(x => x.Visibility = System.Windows.Visibility.Visible);

            foreach (var keyword in Keywords)
            {
                if (keyword.Keyword.Contains('%'))
                {
                    CommitLogs.Where(x => x.CommitComment.ToLower().Contains(keyword.Keyword.ToLower().Replace("%", "")))
                        .ToList().ForEach(x => x.Visibility = System.Windows.Visibility.Collapsed);
                }
                else
                {
                    CommitLogs.Where(x => x.CommitComment.ToLower().Equals(keyword.Keyword.ToLower()))
                        .ToList().ForEach(x => x.Visibility = System.Windows.Visibility.Collapsed);
                }
            }
        }
    }
}
