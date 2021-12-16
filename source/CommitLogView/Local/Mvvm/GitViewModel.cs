using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommitLogView.UI.Units;
using DevNcore.UI.Foundation.Mvvm;

namespace CommitLogView.Local.Mvvm
{
    internal class GitViewModel : ObservableObject
    {
        private readonly Dictionary<string, NcoreContent> LayerItems;
        public ObservableCollection<MainTabsItem> Repositories { get; private set; }

        public ICommand MarkdownClickCommand { get; set; }

        public GitViewModel()
        {
            LayerItems = new Dictionary<string, NcoreContent>();
            Repositories = new ObservableCollection<MainTabsItem>
            {
                new MainTabsItem { Header = "New", Tag = "REPOSITORY", Content = new RepoContent() }
            };
        }

        internal void Add(string dir)
        {
            if (!LayerItems.ContainsKey(dir))
            {
                var name = Path.GetFileNameWithoutExtension(dir);
                var layer = new CommitContent { Tag = dir };
                var tabItem = new MainTabsItem { Header = name, Content = layer };

                LayerItems.Add(dir, layer);
                Repositories.Add(tabItem);
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
