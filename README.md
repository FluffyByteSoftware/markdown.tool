# Markdown Reader

A simple, cross-platform desktop app for opening and reading Markdown (`.md`) files. Built with C# and [Avalonia UI](https://avaloniaui.net/), so it runs on Windows and Linux with no Windows-only dependencies.

## Features

- Open `.md` / `.markdown` files through the native file picker
- Renders Markdown as formatted text (headings, lists, code blocks, links, tables)
- Shows the open file's name in the window title

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Build and run

From the solution folder (`markdown.tool`):

```bash
dotnet run --project Core
```

Or open `markdown.tool.sln` in JetBrains Rider and press Run.

## Project structure

```
markdown.tool/
├── markdown.tool.sln
└── Core/
    ├── Core.csproj
    ├── Program.cs              # Entry point
    ├── App.axaml(.cs)          # Application setup
    └── MainWindow.axaml(.cs)   # Main window and file-open logic
```

## Built with

- [Avalonia UI](https://github.com/AvaloniaUI/Avalonia): cross-platform .NET UI framework
- [Markdown.Avalonia](https://github.com/whistyun/Markdown.Avalonia): Markdown rendering control

## License

Released under the [MIT License](LICENSE).