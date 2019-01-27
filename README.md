# Markdown Generator

## Overview

[![NuGet](https://img.shields.io/nuget/v/Grynwald.MarkdownGenerator.svg)](https://www.nuget.org/packages/Grynwald.MarkdownGenerator)
[![MyGet](https://img.shields.io/myget/ap0llo-markdown-generator/vpre/Grynwald.MarkdownGenerator.svg?label=myget)](https://www.myget.org/feed/ap0llo-markdown-generator/package/nuget/Grynwald.MarkdownGenerator)
[![Build Status](https://dev.azure.com/ap0llo/OSS/_apis/build/status/markdown-generator?branchName=master)](https://dev.azure.com/ap0llo/OSS/_build/latest?definitionId=7?branchName=master)

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

## Building from source

MarkdownGenerator is a .NET Standard library and can be built using the .NET SDK (tested with Visual Studio 15.7)

```bat
  dotnet restore .\src\MarkdownGenerator.sln

  dotnet build .\src\MarkdownGenerator.sln
```

## Versioning and Branching

See [Versioning and Branching](./docs/meta/versioning.md) for details.

## Acknowledgments

Markdown Generator was made possible through a number of libraries (aside from
.NET Core and .NET Standard):

- [Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning/)
- [SourceLink](https://github.com/dotnet/sourcelink)

Addititional dependencies used for testing:

- [Markdig](https://github.com/lunet-io/markdig)
- [Roslyn](https://github.com/dotnet/roslyn)
- [xUnit](http://xunit.github.io/)
