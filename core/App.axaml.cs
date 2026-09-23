using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Core;

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
            var window = new MainWindow();

            if (desktop.Args is { Length: > 0 })
            {
                string path = desktop.Args[0];
                try
                {
                    window.Viewer.Markdown = File.ReadAllText(path);
                }
                catch (Exception e)
                {
                    window.Viewer.Markdown = $"Couldn't open {path}\n\n{e.Message}";
                }
            }

            desktop.MainWindow = window;
        }

        base.OnFrameworkInitializationCompleted();
    }
}