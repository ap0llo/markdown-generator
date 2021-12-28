# Markdown Generator

## Overview

[![Build Status](https://dev.azure.com/ap0llo/OSS/_apis/build/status/markdown-generator?branchName=master)](https://dev.azure.com/ap0llo/OSS/_build/?definitionId=7)
[![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-1.0.0-yellow.svg)](https://conventionalcommits.org)
[![Renovate](https://img.shields.io/badge/Renovate-enabled-brightgreen)](https://renovatebot.com/)

[![MyGet](https://img.shields.io/myget/ap0llo-markdown-generator/vpre/Grynwald.MarkdownGenerator.svg?label=myget)](https://www.myget.org/feed/ap0llo-markdown-generator/package/nuget/Grynwald.MarkdownGenerator)
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

## Building from source

MarkdownGenerator is a .NET Standard library.
Building it from source requires the .NET 6 SDK (version 6.0.101 as specified in [global.json](./global.json)) and uses [Cake](https://cakebuild.net/) for the build.

To execute the default task, run

```ps1
.\build.ps1
```

This will build the project, run all tests and pack the NuGet package.

## Issues

If you run into any issues or if you are missing a feature, feel free
to open an [issue](https://github.com/ap0llo/markdown-generator/issues).

I'm also using issues as a backlog of things that come into my mind or
things I plan to implement, so don't be surprised if many issues were
created by me without anyone else being involved in the discussion.

## Acknowledgments

Markdown Generator was made possible through a number of libraries (aside from
.NET Core and .NET Standard):

- [Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning/)
- [SourceLink](https://github.com/dotnet/sourcelink)
- [SauceControl.InheritDoc](https://github.com/saucecontrol/InheritDoc)

The implementation of ASCII-art tree used to visualize the structure of a document
is basd on [AsciiTreeDiagram](https://github.com/andrewlock/blog-examples/tree/bf9da19db2867cbf371f74299148f17e1f82ad09/AsciiTreeDiagram) 
by Andrew Lock, licensed under the MIT license.  
See [Creating an ASCII-art tree in C#](https://andrewlock.net/creating-an-ascii-art-tree-in-csharp/) for details.

Addititional dependencies (used for testing), in no specific order:

- [Markdig](https://github.com/lunet-io/markdig)
- [Roslyn](https://github.com/dotnet/roslyn)
- [xUnit](http://xunit.github.io/)
- [PublicApiGenerator](https://github.com/JakeGinnivan/ApiApprover)
- [ApprovalTests](https://github.com/approvals/ApprovalTests.Net)
- [Moq](https://github.com/moq/moq4)
- [Xunit.Combinatorial](https://github.com/AArnott/Xunit.Combinatorial)
- [Cake](https://cakebuild.net/)
- [Cake.BuildSystems.Module](https://github.com/cake-contrib/Cake.BuildSystems.Module)

## Versioning and Branching

The version of the library is automatically derived from git and the information
in `version.json` using [Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning):

- The master branch  always contains the latest version. Packages produced from
  master are always marked as pre-release versions (using the `-pre` suffix).
- Stable versions are built from release branches. Build from release branches
  will have no `-pre` suffix
- Builds from any other branch will have both the `-pre` prerelease tag and the git
  commit hash included in the version string

To create a new release branch use the [`nbgv` tool](https://www.nuget.org/packages/nbgv/)
(at least version `3.0.24`):

```ps1
dotnet tool install --global nbgv 
nbgv prepare-release
```

