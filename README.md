# MarkdownGenerator

[![NuGet](https://img.shields.io/nuget/v/Grynwald.MarkdownGenerator.svg)](https://www.nuget.org/packages/Grynwald.MarkdownGenerator)

Most Markdown libraries focus on parsing markdown inputs and converting them to html.
In contrast MarkdownGenerator is library to programmatically generate markdown files.

The library implements markdown features as described in the [CommonMark spec](https://spec.commonmark.org/0.28/).
Additionally the library supports tables as defined in [GitHub flavored markdown](https://github.github.com/gfm/).

## Installation

MarkdownGenerator is distributed as NuGet package.

- Prerelease builds are available on [MyGet](https://www.myget.org/feed/Packages/ap0llo-markdown-generator)
- Release versions are available on [NuGet.org](https://www.nuget.org/packages/Grynwald.MarkdownGenerator)

## Usage / Examples

The library follows the CommonMark terminology for element names. See the [CommonMark spec](https://spec.commonmark.org/0.28/)
for full documentation

**Example:** Create a new instance of `MdDocument`, add a heading and a paragraph and then save the document to a file

```csharp
using Grynwald.MarkdownGenerator.Model;

var document = new MdDocument();
document.Add(new MdHeading("Heading", 1));
document.Add(new MdParagraph("Hello world!"));
document.Save("HelloWorld.md")
```

Blocks can also be passed to the constructor allowing documents to be created in a single document:

```csharp
using Grynwald.MarkdownGenerator.Model;

var document = new MdDocument(
  new MdHeading("Heading", 1),
  new MdParagraph("Hello world!")
);
document.Save("HelloWorld.md")
```

To further streamline document creation, the class `Grynwald.MarkdownGenerator.FactoryMethods` provides factory
methods for all block types that are useful when using static imports:

```csharp
using static Grynwald.MarkdownGenerator.FactoryMethods;

Document(
  Heading("Heading", 1),
  Paragraph("Hello world!")
).Save("HelloWorld.md");
```

**A full list of supported block types is available [here](./docs/blocktypes.md).**

## Building from source

MarkdownGenerator is a .NET Standard library and can be built using the .NET SDK (tested with Visual Studio 15.7)

```bat
  dotnet restore .\src\MarkdownGenerator.sln

  dotnet build .\src\MarkdownGenerator.sln
```

## Versioning and Branching

The version of the library is automatically derived from git and the information in `version.json` using
[Nerdbank.GitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning):

- The master branch  always contains the latest version. Packages produced from master are always
  marked as pre-release versions (using the `-prerelease` suffix).
- Stable versions are built from release branches. Build from release branches will have no `-prerelease` suffix
- Builds from any other branch will have both the `-prerelease` and the git commit hash included
  in the version string

The `Set-Version.ps1` script can be used to create a new release branch and update the version on *master*. 
The script will:

- read `version.json` to determine the current version of the branch (typically *master*)
- create a new release branch for version, e.g. *release/v1.0*
- Remove the pre-release tag from `version.json` on the release branch
- Increment the version on *master* so builds from that branch will produce pre-release packages
  for the next version. The next version is either the next major or minor version,
  depending on the parameters passed to `Set-Version.ps1` (either `-Major` or `-Minor`)
