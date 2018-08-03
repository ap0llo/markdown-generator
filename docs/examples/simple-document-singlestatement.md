# Example: Create and save a simple markdown document in a single statement

Instead of calling `document.Root.Add()` for every block of the document,
blocks can also be passed directory to the document's constructor:

```csharp
using Grynwald.MarkdownGenerator;

public class Program
{
    static void Main()
    {
        // create the document and pass in the document's content
        new MdDocument(
            // add a heading and a paragraph (this will create a root block and add the blocks to it)
            new MdHeading("Heading", 1),
            new MdParagraph("Hello world!")
        )
        // save document to a file
        .Save("HelloWorld.md");
    }
}
```

This will produce the same output as the [Create a simple markdown document](./simple-document.md) example:

```md
# Heading

Hello world!
```