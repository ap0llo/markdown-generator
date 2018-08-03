# Factory Methods

To ease construction of markdown documents, all block and span types can
be created using factory methods defined in the class `Grynwald.MarkdownGenerator.FactoryMethods`
instead of using the `new` operator.

These factory methods can be brought into scope with the `using static` statement.
The factory methods are named after the classes they create, but with the `Md` prefix.
and the `Block`/`Span` suffix removed

## Example

Using the factory methods, the following code

```csharp
using Grynwald.MarkdownGenerator;

public class Program
{
    static void Main()
    {
        new MdDocument(
            new MdHeading("Heading", 1),
            new MdParagraph("Hello world!")
        )
        .Save("HelloWorld.md");
    }
}
```

[See full example](../examples/simple-document-singlestatement.md)

can be rewritten to

```csharp
using static Grynwald.MarkdownGenerator.FactoryMethods;

public class Program
{
    static void Main()
    {
        Document(
            Heading("Heading", 1),
            Paragraph("Hello world!")
        )
        .Save("HelloWorld.md");
    }
}
```

[See full example](../examples/simple-document-factorymethods.md)