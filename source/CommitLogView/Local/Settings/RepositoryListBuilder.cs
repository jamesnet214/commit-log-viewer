using CommitLogView.Local.Data.Yamls;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CommitLogView.Local.Settings
{
    public class RepositoryListBuilder
    {
        private SettingsConfig Settings { get; }

        private RepositoryListBuilder()
        {
            string ymlContents = FindAssemblyInfo("CommitLogView.App.settings.yml");
            var deserializer = new DeserializerBuilder()
              .WithNamingConvention(CamelCaseNamingConvention.Instance)
              .Build();

            Settings = deserializer.Deserialize<SettingsConfig>(ymlContents);
        }

        public static RepositoryListBuilder Build()
        {
            return new RepositoryListBuilder();
        }

        public List<RepositoryGroup> Repositories()
        {
            return Settings.RepositoryGroup;
        }

        // 이 부분은 나중에 Assembly 관련 프레임워크로 이동합니다...
        private static string FindAssemblyInfo(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            string result = reader.ReadToEnd();
            return result;
        }
    }
}
