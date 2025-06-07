using Avalonia;
using System;
using System.IO;
using e621NET;
using WebViewControl;
using Xilium.CefGlue;

namespace eBrowser;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        e621Client.Current.Options.UserAgent = "eBrowser/1.0 (disotakyu)";
        WebView.Settings.AddCommandLineSwitch("autoplay-policy", "no-user-gesture-required");
        var builder = AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();

        return builder;
    }
}
