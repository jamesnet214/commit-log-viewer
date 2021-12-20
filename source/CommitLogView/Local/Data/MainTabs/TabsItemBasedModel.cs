using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommitLogView.Local.Data.MainTabs
{
    public class TabsItemBasedModel : INotifyPropertyChanged
    {
        private bool _isSelected;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string TabsItemType { get; set; }
        public string Header { get; protected set; }
        public object Content { get; protected set; }

        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(); }
        }
    }
}
