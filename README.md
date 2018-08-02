# MarkdownGenerator

[![NuGet](https://img.shields.io/nuget/v/Grynwald.MarkdownGenerator.svg)](https://www.nuget.org/packages/Grynwald.MarkdownGenerator)

Most Markdown libraries focus on parsing markdown inputs and converting them to html.
In contrast MarkdownGenerator is library to programmatically generate markdown files.

The library implements markdown features as described in the [CommonMark spec](https://spec.commonmark.org/0.28/).
Additionally the library supports tables as defined in [GitHub flavored markdown](https://github.github.com/gfm/).

## Installation

MarkdownGenerator is distributed as NuGet package.

- Prerelease builds are available on [MyGet](https://www.myget.org/feed/ap0llo-markdown-generator/package/nuget/Grynwald.MarkdownGenerator)
- Release versions are available on [NuGet.org](https://www.nuget.org/packages/Grynwald.MarkdownGenerator)

## Documentation

See [Documentation](./docs/README.md) for details.

## Building from source

MarkdownGenerator is a .NET Standard library and can be built using the .NET SDK (tested with Visual Studio 15.7)

```bat
  dotnet restore .\src\MarkdownGenerator.sln

  dotnet build .\src\MarkdownGenerator.sln
```

## Versioning and Branching

See [Versioning and Branching](./docs/versioning.md) for details.
