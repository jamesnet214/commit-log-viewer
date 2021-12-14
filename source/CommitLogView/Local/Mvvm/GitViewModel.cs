using CommitLogView.UI.Units;
using DevNcore.UI.Foundation.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommitLogView.Local.Mvvm
{
    internal class GitViewModel : ObservableObject
    {
        private Dictionary<string, NcoreLayer> LayerItems;
        public ICommand MarkdownClickCommand { get; set; }

        #region . Repositories . 

        public ObservableCollection<TabItem> Repositories { get; private set; }
        #endregion

        #region . Constructor .

        public GitViewModel()
        {
            //MarkdownClickCommand = new RelayCommand<object>(MarkdownClick);

            LayerItems = new Dictionary<string, NcoreLayer>();
            Repositories = new ObservableCollection<TabItem>();
            Repositories.Add(new TabItem { Header = "New", Tag = "REPOSITORY", Content = new RepoView() });
        }
        #endregion

        #region . internal AddNewRepository .

        internal void Add(string dir)
        {
            if (!LayerItems.ContainsKey(dir))
            {
                var name = Path.GetFileNameWithoutExtension(dir);
                var layer = new CommitView { Tag = dir };
                var tabitem = new TabItem { Header = name, Content = layer };
                LayerItems.Add(dir, layer);
                Repositories.Add(tabitem);
                tabitem.IsSelected = true;
            }
            else
            {
                Repositories.Single(x => x.Content.Equals(LayerItems[dir])).IsSelected = true;
            }
        }
        #endregion

        //#region . MarkdownClick .

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
        //#endregion
    }
}
