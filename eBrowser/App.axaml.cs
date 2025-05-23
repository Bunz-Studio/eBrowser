using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace eBrowser;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
        
        LocalStorage.GetPersistPath("previews").CreateForceDirectory();
        LocalStorage.GetPersistPath("full").CreateForceDirectory();
        LocalStorage.GetPersistPath("data").CreateForceDirectory();
        LocalStorage.GetPersistPath("pages").CreateForceDirectory();
        LocalStorage.GetPersistPath("info").CreateForceDirectory();
    }
}
