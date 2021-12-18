# commit-log-viewer

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
