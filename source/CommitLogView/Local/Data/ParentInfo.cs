using LibGit2Sharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommitLogView.Local.Data
{
    public class ParentInfo : INotifyPropertyChanged
    {
        public ObjectId Id { get; set; }
        private int _line;
        public int Line
        {
            get { return _line; }
            set { _line = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
