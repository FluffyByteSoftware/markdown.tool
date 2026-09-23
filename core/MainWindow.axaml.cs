using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

namespace Core;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OnOpen(object? sender, RoutedEventArgs e)
    {
        try
        {
            var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open Markdown file",
                AllowMultiple = false,
                FileTypeFilter = [new FilePickerFileType("Markdown") { Patterns = ["*.md", "*.markdown"] }]
            });
            if (files.Count == 0) return;

            await using var stream = await files[0].OpenReadAsync();
            using var reader = new StreamReader(stream);
            Viewer.Markdown = await reader.ReadToEndAsync();
            Title = $"Markdown.Tool - {files[0].Name}";
        }
        catch (Exception ex)
        {
            // async void handlers crash the app on an unhandled exception, so show it instead
            Viewer.Markdown = $"**Could not open file**\n\n{ex.Message}";
        }
    }
}