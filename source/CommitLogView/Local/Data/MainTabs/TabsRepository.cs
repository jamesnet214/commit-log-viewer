using CommitLogView.Local.Data.Yamls;
using CommitLogView.UI.Units;

namespace CommitLogView.Local.Data.MainTabs
{
    public class TabsRepository : TabsItemBasedModel
    {
        public RepositoryItem Repository { get; }

        public TabsRepository(RepositoryItem repository)
        {
            TabsItemType = "Repository";
            Header = repository.Name;
            Content = new CommitContent(repository);            
            Repository = repository;
        }

        internal void Select()
        {
            IsSelected = true;
        }

        public bool Equals(RepositoryItem obj)
        {
            if (obj is RepositoryItem repo)
            {
                return Repository.Path == repo.Path;
            }
            return base.Equals(obj);
        }
    }
}
