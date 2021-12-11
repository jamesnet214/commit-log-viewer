using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommitLogViewer.Local.Mvvm
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null) 
        {
            if (PropertyChanged != null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
