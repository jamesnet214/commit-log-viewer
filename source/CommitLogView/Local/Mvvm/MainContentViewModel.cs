using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommitLogView.UI.Units;
using DevNcore.UI.Foundation.Mvvm;
using CommitLogView.Local.Data;

namespace CommitLogView.Local.Mvvm
{
    public class MainContentViewModel : ObservableObject
    {
        public static MainContentViewModel vm;

        private readonly Dictionary<string, NcoreContent> LayerItems;
        
        public ObservableCollection<MainTabsItem> Repositories { get; private set; }
        public ObservableCollection<IRepo> Repositories2 { get; private set; }

        public ICommand MarkdownClickCommand { get; set; }

        public MainContentViewModel()
        {
            vm = this;
            LayerItems = new Dictionary<string, NcoreContent>();
            Repositories = new ObservableCollection<MainTabsItem>
            {
                new MainTabsItem { Header = "New1111", Tag = "REPOSITORY", Content = new RepoContent() }
            };
            Repositories2 = new ObservableCollection<IRepo>();
            Repositories2.Add(new RepoTabContentItem { Title = "James", ViewModel = new RepoViewModel() });
        }

        internal void Add(string dir)
        {
            if (!LayerItems.ContainsKey(dir))
            {
                var name = Path.GetFileNameWithoutExtension(dir);
                var layer = new CommitContent { Tag = dir };
                var tabItem = new MainTabsItem { Header = name, Content = layer };

                var data = new CommitViewModel();
                data.Tag = dir;
                LayerItems.Add(dir, layer);
                Repositories2.Add(new CommitTabContentItem { Title = "Repo", Content = data });
                tabItem.IsSelected = true;
            }
            else
            {
                Repositories.Single(x => x.Content.Equals(LayerItems[dir])).IsSelected = true;
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
