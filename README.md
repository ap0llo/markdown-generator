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

## Acknowledgments

Markdown Generator was made possible through a number of libraries (aside from
.NET Core and .NET Standard):

- [Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning/)
- [SourceLink](https://github.com/dotnet/sourcelink)

The implementation of ASCII-art tree used to visualize the structure of a document
is basd on [AsciiTreeDiagram](https://github.com/andrewlock/blog-examples/tree/bf9da19db2867cbf371f74299148f17e1f82ad09/AsciiTreeDiagram) 
by Andrew Lock, licensed under the MIT license.  
See [Creating an ASCII-art tree in C#](https://andrewlock.net/creating-an-ascii-art-tree-in-csharp/) for details.

Addititional dependencies used for testing:

- [Markdig](https://github.com/lunet-io/markdig)
- [Roslyn](https://github.com/dotnet/roslyn)
- [xUnit](http://xunit.github.io/)

## Versioning and Branching

The version of this library is automatically derived from git and the information
in `version.json` using [Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning):

- The master branch  always contains the latest version. Packages produced from
  master are always marked as pre-release versions (using the `-pre` suffix).
- Stable versions are built from release branches. Build from release branches
  will have no `-pre` suffix
- Builds from any other branch will have both the `-pre` prerelease tag and the git
  commit hash included in the version string

To create a new release branch use the [`nbgv` tool](https://www.nuget.org/packages/nbgv/)
(at least version `3.0.4-beta`):

```ps1
dotnet tool install --global nbgv --version
nbgv prepare-release
```
