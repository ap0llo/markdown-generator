# MarkdownGenerator

[![NuGet](https://img.shields.io/nuget/v/Grynwald.MarkdownGenerator.svg)](https://www.nuget.org/packages/Grynwald.MarkdownGenerator)

Markdown Generator is a library for generating Markdown documents programatically.
It implements the [CommonMark](https://spec.commonmark.org/0.28/) specification as
well as the *table* extension specified by
[GitHub Flavored Markdown](https://github.github.com/gfm/#tables-extension).

- For an overview of the library's API, see [API](./docs/api/README.md)
- For usage examples see [Examples](./docs/examples/README.md)

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

See [Versioning and Branching](./docs/meta/versioning.md) for details.
