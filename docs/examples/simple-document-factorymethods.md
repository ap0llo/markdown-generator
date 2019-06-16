# Example: Create and save a simple markdown document using factory methods

Instead of using `new` statements to create the document and blocks,
[factory methods](../api/factorymethods.md) defined in the `FactoryMethods` class can be used:

```csharp
// import factory methods
using static Grynwald.MarkdownGenerator.FactoryMethods;

public class Program
{
    static void Main()
    {
        // create the document and pass in the document's content
        Document(
            // add a heading and a paragraph (this will create a root block and add the blocks to it)
            Heading("Heading", 1),
            Paragraph("Hello world!")
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
