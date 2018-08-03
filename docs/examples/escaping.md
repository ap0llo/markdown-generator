# Example: Escaping

By default, all string content passed to blocks and spans will be escaped in the output.
To include a string unchanged, use `MdRawMarkdownSpan`

```csharp
using Grynwald.MarkdownGenerator;

public class Program
{
    static void Main()
    {
        // create the document and pass in the document's content
        new MdDocument(
            new MdParagraph(
                new MdTextSpan("**not emphasized**"),     // this span will be escaped in the output
                new MdRawMarkdownSpan("**emphasized**")   // this span will NOT be escaped in the output
            )
        )
        // save document to a file
        .Save("HelloWorld.md");
    }
}
```

This will produce the following output:

```md
\*\*not emphasized\*\*
**emphasized**
```

The first line is passed to the paragraph as `MdTextSpan` and is escaped in the output.
The second line is wrapped in an instance of `MdRawMarkdownSpan` and written
to the output unchanged. Thus, the second line will be rendered as emphasized text
when displaying the markdown document as HTML.

The code can also be rewritten using [factory methods](../api/factorymethods.md):

```csharp
using static Grynwald.MarkdownGenerator.FactoryMethods;

public class Program
{
    static void Main()
    {
        Document(
            Paragraph(
                Text("**not emphasized**"),     // this span will be escaped in the output
                RawMarkdown("**emphasized**")   // this span will NOT be escaped in the output
            )
        )
        .Save("HelloWorld.md");
    }
}
```
