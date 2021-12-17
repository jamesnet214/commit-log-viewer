using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CommitLogView.UI.Units;
using DevNcore.UI.Foundation.Mvvm;

namespace CommitLogView.Local.Mvvm
{
    public class MainContentViewModel : ObservableObject
    {
        public ObservableCollection<ObservableObject> TabsContents { get; } = new();

        public ICommand MarkdownClickCommand { get; set; }

        public MainContentViewModel()
        {
            TabsContents.Add(new RepoViewModel("New", Add));
        }

        internal void Add(string dir)
        {
            if (true)
            {
                var name = Path.GetFileNameWithoutExtension(dir);
                TabsContents.Add(new CommitViewModel { Tag = dir, Header = name });
            }
            else
            {
                //Repositories2.Single(x => x.ViewModel.Equals(LayerItems[dir])).IsSelected = true;
            }
        }

        #region [UnUsed] MarkdownClick

        //private void MarkdownClick(object obj)
        //{
        //    FlowCanvas canvas = UIVisualHelper.GetNearParent<FlowCanvas>(View);

        //    if (obj is RevisionFileInfo fi && File.Exists(fi.Path))
        //    {
        //        var left = View.RenderTransform.Value.OffsetX;
        //        var top = View.RenderTransform.Value.OffsetY;

        //        string text = File.ReadAllText(fi.Path);
        //        MarkdownView view = new MarkdownView(fi);
        //        view.SetPosition(View.Width + (int)left, (int)top);
        //        view.Header = "Markdown VIewer";
        //        canvas.Add(view);
        //        view.IsSelected = true;
        //    }
        //}
        #endregion
    }
}
