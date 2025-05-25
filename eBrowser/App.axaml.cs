using System;
using Avalonia;
using Avalonia.Controls;
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

        if (Design.IsDesignMode) return;
        LocalStorage.GetPersistPath("previews").CreateForceDirectory();
        LocalStorage.GetPersistPath("full").CreateForceDirectory();
    }
    
    void ExitMenuItem_OnClick(object? sender, EventArgs e)
    {
        MainWindow.ForceClose = true;
        MainWindow.Instance.Close();
    }
    
    void ShowMenuItem_OnClick(object? sender, EventArgs e)
    {
        MainWindow.Instance.Show();
    }

    void TrayIcon_OnClicked(object? sender, EventArgs e)
    {
        if (MainWindow.Instance.IsVisible)
        {
            MainWindow.Instance.Hide();
        }
        else
        {
            if (MainWindow.Instance.WindowState == WindowState.Minimized)
                MainWindow.Instance.WindowState = WindowState.Maximized;

            MainWindow.Instance.Show();
        }
    }
}
