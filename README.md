## commit-log-viewer

이 리포지토리는 commit-log-viewer에 대해 기술한 리포지토리입니다. <br />

<a href="https://github.com/devncore/devncore"><strong>더 알아보기 »</strong></a>
 
| Star | License | Activity |
|:----:|:-------:|:--------:|
| <a href="https://github.com/devncore/commit-log-viewer/stargazers"><img src="https://img.shields.io/github/stars/devncore/commit-log-viewer" alt="Github Stars"></a> | <img src="https://img.shields.io/github/license/devncore/commit-log-viewer" alt="License"> | <a href="https://github.com/devncore/commit-log-viewer/pulse"><img src="https://img.shields.io/github/commit-activity/m/devncore/commit-log-viewer" alt="Commits-per-month"></a> |

<br />

Config 위치

TBD...0

```
C:\Users\james\AppData\Roaming\DevFlow\Configs
```


temp-backup
```
private void View_Drop(object sender, DragEventArgs e)
{
    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

    foreach (var dir in files)
    {
        if (View.Parent is FrameworkElement fe && fe.DataContext is MainContentModel)
        {
            RepositoryConfig.Access.Add(dir);
        }
    }
    RepositoryConfig.Access.Save();
}



        private void View_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
```
