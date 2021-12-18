using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;

namespace CommitLogView.Local.Data
{
    public class RepositoryConfig
    {
        private readonly string SYS_PATH = "";
        private readonly string CFG_PATH = "";
        private readonly string GIT_PATH = "";

        internal static RepositoryConfig Access { get; private set; }
        internal IsolateGitRepository Config { get; private set; }

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

        private void LoadConfigFile()
        {
            if (!Directory.Exists(CFG_PATH))
            {
                Directory.CreateDirectory(CFG_PATH);
            }

            if (!File.Exists(GIT_PATH))
            {
                IsolateGitRepository repoInfo = new()
                {
                    Repositories = new List<IsolateGitRepositoryItem>()
                };
                string json = JsonConvert.SerializeObject(repoInfo);

                File.WriteAllText(GIT_PATH, json);
            }

            Config = JsonConvert.DeserializeObject<IsolateGitRepository>(File.ReadAllText(GIT_PATH));
        }

        internal void Add(string dir)
        {
            var name = Path.GetFileNameWithoutExtension(dir);
            var date = DateTime.Now;

            Config.Repositories = Config.Repositories ?? new List<IsolateGitRepositoryItem>();
            Config.Repositories.Add(new IsolateGitRepositoryItem { Name = name, RepositoryPath = dir, LastAccessTime = date, Created = date });
        }

        internal void Save()
        {
            string json = JsonConvert.SerializeObject(Config);
            File.WriteAllText(GIT_PATH, json);
        }

        internal void Visit(string v)
        {
            //Config.Repositories.FirstOrDefault(x => x.RepositoryPath == v).LastAccessTime = DateTime.Now;
        }
    }
}
