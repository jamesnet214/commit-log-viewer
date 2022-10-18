# Commit Log Viewer

이 리포지토리는 commit-log-viewer에 대해 기술한 리포지토리입니다. <br />

<img src="https://user-images.githubusercontent.com/52397976/196339550-87fdc15b-697a-465b-83ee-d80ea8d36c58.png" style="width:80%"/>


| Star | License | Activity |
|:----:|:-------:|:--------:|
| <a href="https://github.com/devncore/commit-log-viewer/stargazers"><img src="https://img.shields.io/github/stars/devncore/commit-log-viewer" alt="Github Stars"></a> | <img src="https://img.shields.io/github/license/devncore/commit-log-viewer" alt="License"> | <a href="https://github.com/devncore/commit-log-viewer/pulse"><img src="https://img.shields.io/github/commit-activity/m/devncore/commit-log-viewer" alt="Commits-per-month"></a> |

<br />

## Config 위치

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
