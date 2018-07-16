# MarkdownGenerator - Usage and Examples

The library follows the CommonMark terminology for element names. See the 
[CommonMark spec](https://spec.commonmark.org/0.28/) for full documentation.

**Example:** Create a new instance of `MdDocument`, add a heading and a
paragraph and then save the document to a file

```csharp
using Grynwald.MarkdownGenerator.Model;

var document = new MdDocument();
document.Add(new MdHeading("Heading", 1));
document.Add(new MdParagraph("Hello world!"));
document.Save("HelloWorld.md")
```

Blocks can also be passed to the constructor allowing documents to be created
in a single statement:

```csharp
using Grynwald.MarkdownGenerator.Model;

var document = new MdDocument(
  new MdHeading("Heading", 1),
  new MdParagraph("Hello world!")
);
document.Save("HelloWorld.md")
```

To further streamline document creation, the class
`Grynwald.MarkdownGenerator.FactoryMethods` provides factory methods for all 
block types that are useful when using static imports:

```csharp
using static Grynwald.MarkdownGenerator.FactoryMethods;

Document(
  Heading("Heading", 1),
  Paragraph("Hello world!")
).Save("HelloWorld.md");
```

**A full list of supported block types is available [here](./blocktypes.md).**