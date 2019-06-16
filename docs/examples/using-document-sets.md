# Example: Create multiple documents using document sets

*Document sets* allows creating multiple documents together. A set is a
collection of documents associated with a output path. A document's
path must be a **relative path** (relative to the root of the output directory).

The document set makes it easy to insert links to other documents of the set as
it can determine the relative path between documents.

By calling `Save()` all documents in the set can be written to a folder in
a single call.

```csharp
using Grynwald.MarkdownGenerator;

public class Program
{
    static void Main()
    {
        // create a new document set
        var set = new MdDocumentSet();

        // new documents can be added to the set by
        // calling CreateDocument() which creates a new document
        // at the specified path
        var document1 = set.CreateDocument("document1.md");
        document1.Root.Add(new MdHeading(1, "Document 1"));

        // alternatively, existing documents can be added to
        // the set using Add()
        var document2 = new MdDocument(
            new MdHeading(1, "Document 2")
        );
        set.Add("directory/document2.md", document2);

        // using MdDocumentSet.GetLink(), links between documents
        // in the set can be created
        document2.Root.Add(new MdParagraph(
            "This is a link to ",
            set.GetLink(document2, document1, "Document 1")
        ));

        // all documents in a set can be saved to disk by calling Save()
        var outputDirectory = "./OutputDirectory";
        set.Save(outputDirectory);
    }
}
```

The code sample above saves two markdown files with the following content:

`document1.md`:

```md
# Document 1

```

`directory/document2.md`:

```md
# Document 2

This is a link to [Document 1](../document1.md)

```
