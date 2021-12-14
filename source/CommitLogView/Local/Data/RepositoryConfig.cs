using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommitLogView.Local.Data
{

    public class RepositoryConfig
    {
        #region Singleton Instance

        internal static RepositoryConfig Access { get; private set; }
        #endregion

        #region Variables 

        private string SYS_PATH = "";
        private string CFG_PATH = "";
        private string GIT_PATH = "";
        #endregion

        #region Config

        internal IsolateGitRepository Config { get; private set; }
        #endregion

        #region Constructors

        static RepositoryConfig()
        {
            Access = new RepositoryConfig();
        }

        private RepositoryConfig()
        {
            SYS_PATH = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            CFG_PATH = string.Format(@"{0}\DevFlow\Configs", SYS_PATH);
            GIT_PATH = string.Format(@"{0}\GitRepositories.json", CFG_PATH);

            LoadConfigFile();
        }
        #endregion

        #region LoadConfigFile

        private void LoadConfigFile()
        {

            if (!Directory.Exists(CFG_PATH))
            {
                Directory.CreateDirectory(CFG_PATH);
            }

            if (!File.Exists(GIT_PATH))
            {
                IsolateGitRepository repoInfo = new IsolateGitRepository();
                repoInfo.Repositories = new List<IsolateGitRepositoryItem>();
                string json = JsonConvert.SerializeObject(repoInfo);

                File.WriteAllText(GIT_PATH, json);
            }

            Config = JsonConvert.DeserializeObject<IsolateGitRepository>(File.ReadAllText(GIT_PATH));
        }
        #endregion

        #region internal Add

        internal void Add(string dir)
        {
            var name = Path.GetFileNameWithoutExtension(dir);
            var date = DateTime.Now;


            Config.Repositories = Config.Repositories ?? new List<IsolateGitRepositoryItem>();
            Config.Repositories.Add(new IsolateGitRepositoryItem { Name = name, RepositoryPath = dir, LastAccessTime = date, Created = date });
        }
        #endregion

        #region internal Save

        internal void Save()
        {
            string json = JsonConvert.SerializeObject(Config);
            File.WriteAllText(GIT_PATH, json);
        }
        #endregion

        internal void Visit(string v)
        {
            Config.Repositories.FirstOrDefault(x => x.RepositoryPath == v).LastAccessTime = DateTime.Now;
        }
    }
}
