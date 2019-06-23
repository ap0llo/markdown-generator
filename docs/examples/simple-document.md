# Example: Create a simple markdown document

This example shows how to create a new document,
add a heading and a paragraph to it and then save the document
to a file:

```csharp
using Grynwald.MarkdownGenerator;

public class Program
{
    static void Main()
    {
        // create the document (initially empty)
        var document = new MdDocument();

        // add a heading and a paragraph to the root block
        document.Add(new MdHeading("Heading", 1));
        document.Add(new MdParagraph("Hello world!"));

        // save document to a file
        document.Save("HelloWorld.md");
    }
}
```

This will produce the output:

```md
# Heading

Hello world!
```
