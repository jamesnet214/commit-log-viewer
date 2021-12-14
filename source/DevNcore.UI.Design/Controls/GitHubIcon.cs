using DevNcore.UI.Design.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;

namespace DevNcore.UI.Design.Controls
{
    public class GitHubIcon : Icon
    {
        static GitHubIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GitHubIcon), new FrameworkPropertyMetadata(typeof(GitHubIcon)));
        }
    }
}
