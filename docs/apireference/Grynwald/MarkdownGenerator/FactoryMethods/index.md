# FactoryMethods Class

⚠️ **Warning:** FactoryMethods is obsolete. Use the constructors of the markdown data types directly instead.

**Namespace:** [Grynwald.MarkdownGenerator](../index.md)

**Assembly:** Grynwald.MarkdownGenerator

Defines static factory methods for blocks in markdown documents. When imported via "using static", this allows for more readable  construction of documents, e.g.

```
new MdDocument(new MdParagraph("My content")) 
```

can be rewritten as

```
Document(Paragraph("My Content"))
```
```csharp
[Obsolete("FactoryMethods is obsolete. Use the constructors of the markdown data types directly instead.")]
public static class FactoryMethods
```

**Inheritance:** object → FactoryMethods

**Attributes:** ObsoleteAttribute

## Methods

| Name                                                                                                   | Description                                                                                                             |
| ------------------------------------------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------------------------------- |
| [BlockQuote()](methods/BlockQuote.md#blockquote)                                                       | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md).                                                     |
| [BlockQuote(IEnumerable\<MdBlock\>)](methods/BlockQuote.md#blockquoteienumerablemdblock)               | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md) with the specified content                           |
| [BlockQuote(MdBlock\[\])](methods/BlockQuote.md#blockquotemdblock)                                     | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md) with the specified content                           |
| [BlockQuote(MdContainerBlockBase)](methods/BlockQuote.md#blockquotemdcontainerblockbase)               | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md) with the specified content.                          |
| [BlockQuote(MdList)](methods/BlockQuote.md#blockquotemdlist)                                           | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md) with the specified content.                          |
| [BlockQuote(MdSpan)](methods/BlockQuote.md#blockquotemdspan)                                           | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md) with the specified content                           |
| [BlockQuote(MdSpan\[\])](methods/BlockQuote.md#blockquotemdspan)                                       | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md) with the specified content                           |
| [BlockQuote(string)](methods/BlockQuote.md#blockquotestring)                                           | Creates a new instance of [MdBlockQuote](../MdBlockQuote/index.md) with the specified content                           |
| [Bold(IEnumerable\<MdSpan\>)](methods/Bold.md#boldienumerablemdspan)                                   | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [Bold(MdCompositeSpan)](methods/Bold.md#boldmdcompositespan)                                           | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [Bold(MdSpan)](methods/Bold.md#boldmdspan)                                                             | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [Bold(MdSpan\[\])](methods/Bold.md#boldmdspan)                                                         | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [Bold(string)](methods/Bold.md#boldstring)                                                             | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md). The specified text will be escaped. |
| [BulletList(IEnumerable\<MdListItem\>)](methods/BulletList.md#bulletlistienumerablemdlistitem)         | Creates a new instance of [MdBulletList](../MdBulletList/index.md) with the specified list items                        |
| [BulletList(MdListItem\[\])](methods/BulletList.md#bulletlistmdlistitem)                               | Creates a new instance of [MdBulletList](../MdBulletList/index.md) with the specified list items                        |
| [CodeBlock(string)](methods/CodeBlock.md#codeblockstring)                                              | Creates a new instance of [MdCodeBlock](../MdCodeBlock/index.md) with the specified text.                               |
| [CodeBlock(string, string)](methods/CodeBlock.md#codeblockstring-string)                               | Creates a new instance of [MdCodeBlock](../MdCodeBlock/index.md).                                                       |
| [CodeSpan(string)](methods/CodeSpan.md)                                                                | Creates a new instance of [MdCodeSpan](../MdCodeSpan/index.md)                                                          |
| [CompositeSpan(IEnumerable\<MdSpan\>)](methods/CompositeSpan.md#compositespanienumerablemdspan)        | Creates a new instance of [MdCompositeSpan](../MdCompositeSpan/index.md) with the specified inline\-elements.           |
| [CompositeSpan(MdSpan\[\])](methods/CompositeSpan.md#compositespanmdspan)                              | Creates a new instance of [MdCompositeSpan](../MdCompositeSpan/index.md) with the specified inline\-elements.           |
| [Container(IEnumerable\<MdBlock\>)](methods/Container.md#containerienumerablemdblock)                  | Creates a new instance of [MdContainerBlock](../MdContainerBlock/index.md) with the specified content.                  |
| [Container(MdBlock\[\])](methods/Container.md#containermdblock)                                        | Creates a new instance of [MdContainerBlock](../MdContainerBlock/index.md) with the specified content.                  |
| [Container(MdContainerBlockBase)](methods/Container.md#containermdcontainerblockbase)                  | Creates a new instance of [MdContainerBlock](../MdContainerBlock/index.md) with the specified content.                  |
| [Container(MdList)](methods/Container.md#containermdlist)                                              | Creates a new instance of [MdContainerBlock](../MdContainerBlock/index.md) with the specified content.                  |
| [Document(IEnumerable\<MdBlock\>)](methods/Document.md#documentienumerablemdblock)                     | Creates a new instance of [MdDocument](../MdDocument/index.md) with the specified content.                              |
| [Document(MdAdmonition)](methods/Document.md#documentmdadmonition)                                     | Creates a new instance of [MdDocument](../MdDocument/index.md) with the specified content.                              |
| [Document(MdBlock\[\])](methods/Document.md#documentmdblock)                                           | Creates a new instance of [MdDocument](../MdDocument/index.md) with the specified content.                              |
| [Document(MdBlockQuote)](methods/Document.md#documentmdblockquote)                                     | Creates a new instance of [MdDocument](../MdDocument/index.md) with the specified content.                              |
| [Document(MdContainerBlock)](methods/Document.md#documentmdcontainerblock)                             | Creates a new instance of [MdDocument](../MdDocument/index.md) with the specified block as root element.                |
| [Document(MdList)](methods/Document.md#documentmdlist)                                                 | Creates a new instance of [MdDocument](../MdDocument/index.md) with the specified content.                              |
| [DocumentSet()](methods/DocumentSet.md)                                                                | Creates a new instance if [MdDocumentSet](../MdDocumentSet/index.md).                                                   |
| [Emphasis(IEnumerable\<MdSpan\>)](methods/Emphasis.md#emphasisienumerablemdspan)                       | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Emphasis(MdCompositeSpan)](methods/Emphasis.md#emphasismdcompositespan)                               | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Emphasis(MdSpan)](methods/Emphasis.md#emphasismdspan)                                                 | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Emphasis(MdSpan\[\])](methods/Emphasis.md#emphasismdspan)                                             | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Emphasis(string)](methods/Emphasis.md#emphasisstring)                                                 | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md).                                                 |
| [Heading(int, MdSpan)](methods/Heading.md#headingint-mdspan)                                           | Creates a new instance of [MdHeading](../MdHeading/index.md)                                                            |
| [Heading(int, MdSpan\[\])](methods/Heading.md#headingint-mdspan)                                       | Creates a new instance of [MdHeading](../MdHeading/index.md)                                                            |
| [Heading(MdSpan, int)](methods/Heading.md#headingmdspan-int)                                           | Creates a new instance of [MdHeading](../MdHeading/index.md)                                                            |
| [Image(MdSpan, string)](methods/Image.md#imagemdspan-string)                                           | Creates a new instance of [MdImageSpan](../MdImageSpan/index.md).                                                       |
| [Image(MdSpan, Uri)](methods/Image.md#imagemdspan-uri)                                                 | Creates a new instance of [MdImageSpan](../MdImageSpan/index.md).                                                       |
| [Image(string, string)](methods/Image.md#imagestring-string)                                           | Creates a new instance of [MdImageSpan](../MdImageSpan/index.md).                                                       |
| [Image(string, Uri)](methods/Image.md#imagestring-uri)                                                 | Creates a new instance of [MdImageSpan](../MdImageSpan/index.md).                                                       |
| [Italic(IEnumerable\<MdSpan\>)](methods/Italic.md#italicienumerablemdspan)                             | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Italic(MdCompositeSpan)](methods/Italic.md#italicmdcompositespan)                                     | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Italic(MdSpan)](methods/Italic.md#italicmdspan)                                                       | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Italic(MdSpan\[\])](methods/Italic.md#italicmdspan)                                                   | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Italic(string)](methods/Italic.md#italicstring)                                                       | Creates a new instance of [MdEmphasisSpan](../MdEmphasisSpan/index.md) with the specified content                       |
| [Link(MdSpan, string)](methods/Link.md#linkmdspan-string)                                              | Creates a new instance of [MdLinkSpan](../MdLinkSpan/index.md).                                                         |
| [Link(MdSpan, Uri)](methods/Link.md#linkmdspan-uri)                                                    | Creates a new instance of [MdLinkSpan](../MdLinkSpan/index.md).                                                         |
| [Link(string, string)](methods/Link.md#linkstring-string)                                              | Creates a new instance of [MdLinkSpan](../MdLinkSpan/index.md).                                                         |
| [Link(string, Uri)](methods/Link.md#linkstring-uri)                                                    | Creates a new instance of [MdLinkSpan](../MdLinkSpan/index.md).                                                         |
| [ListItem()](methods/ListItem.md#listitem)                                                             | Creates a new instance of [MdListItem](../MdListItem/index.md).                                                         |
| [ListItem(IEnumerable\<MdBlock\>)](methods/ListItem.md#listitemienumerablemdblock)                     | Creates a new instance of [MdListItem](../MdListItem/index.md) containing the specified blocks.                         |
| [ListItem(MdBlock\[\])](methods/ListItem.md#listitemmdblock)                                           | Creates a new instance of [MdListItem](../MdListItem/index.md) containing the specified blocks.                         |
| [ListItem(MdContainerBlockBase)](methods/ListItem.md#listitemmdcontainerblockbase)                     | Creates a new instance of [MdListItem](../MdListItem/index.md) containing the content.                                  |
| [ListItem(MdList)](methods/ListItem.md#listitemmdlist)                                                 | Creates a new instance of [MdListItem](../MdListItem/index.md) containing the content.                                  |
| [ListItem(MdSpan)](methods/ListItem.md#listitemmdspan)                                                 | Creates a new instance of [MdListItem](../MdListItem/index.md) containing the specified span                            |
| [ListItem(MdSpan\[\])](methods/ListItem.md#listitemmdspan)                                             | Creates a new instance of [MdListItem](../MdListItem/index.md) containing the specified spans                           |
| [ListItem(string)](methods/ListItem.md#listitemstring)                                                 | Creates a new instance of [MdListItem](../MdListItem/index.md) containing the specified span                            |
| [OrderedList(IEnumerable\<MdListItem\>)](methods/OrderedList.md#orderedlistienumerablemdlistitem)      | Creates a new instance of [MdOrderedList](../MdOrderedList/index.md) with the specified list items.                     |
| [OrderedList(MdListItem\[\])](methods/OrderedList.md#orderedlistmdlistitem)                            | Creates a new instance of [MdOrderedList](../MdOrderedList/index.md) with the specified list items.                     |
| [Paragraph(MdSpan)](methods/Paragraph.md#paragraphmdspan)                                              | Creates a new instance of [MdParagraph](../MdParagraph/index.md) with the specified content.                            |
| [Paragraph(MdSpan\[\])](methods/Paragraph.md#paragraphmdspan)                                          | Creates a new instance of [MdParagraph](../MdParagraph/index.md) with the specified content.                            |
| [Paragraph(string)](methods/Paragraph.md#paragraphstring)                                              | Creates a new instance of [MdParagraph](../MdParagraph/index.md) with the specified content.                            |
| [RawMarkdown(string)](methods/RawMarkdown.md)                                                          | Creates a new instance of [MdRawMarkdownSpan](../MdRawMarkdownSpan/index.md)                                            |
| [Row()](methods/Row.md#row)                                                                            | Creates a new instance of [MdTableRow](../MdTableRow/index.md).                                                         |
| [Row(IEnumerable\<MdSpan\>)](methods/Row.md#rowienumerablemdspan)                                      | Creates a new instance of [MdTableRow](../MdTableRow/index.md) with the specified cells\/columns.                       |
| [Row(IEnumerable\<string\>)](methods/Row.md#rowienumerablestring)                                      | Creates a new instance of [MdTableRow](../MdTableRow/index.md) with the specified cells\/columns.                       |
| [Row(MdCompositeSpan)](methods/Row.md#rowmdcompositespan)                                              | Creates a new instance of [MdTableRow](../MdTableRow/index.md) with the specified cell.                                 |
| [Row(MdSpan\[\])](methods/Row.md#rowmdspan)                                                            | Creates a new instance of [MdTableRow](../MdTableRow/index.md) with the specified cells\/columns.                       |
| [Row(string\[\])](methods/Row.md#rowstring)                                                            | Creates a new instance of [MdTableRow](../MdTableRow/index.md) with the specified cells\/columns.                       |
| [StrongEmphasis(IEnumerable\<MdSpan\>)](methods/StrongEmphasis.md#strongemphasisienumerablemdspan)     | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [StrongEmphasis(MdCompositeSpan)](methods/StrongEmphasis.md#strongemphasismdcompositespan)             | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [StrongEmphasis(MdSpan)](methods/StrongEmphasis.md#strongemphasismdspan)                               | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [StrongEmphasis(MdSpan\[\])](methods/StrongEmphasis.md#strongemphasismdspan)                           | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md) with the specified content.          |
| [StrongEmphasis(string)](methods/StrongEmphasis.md#strongemphasisstring)                               | Creates a new instance of [MdStrongEmphasisSpan](../MdStrongEmphasisSpan/index.md). The specified text will be escaped. |
| [Table(MdTableRow, IEnumerable\<MdTableRow\>)](methods/Table.md#tablemdtablerow-ienumerablemdtablerow) | Creates a new instance of [MdTable](../MdTable/index.md) with the specified content                                     |
| [Table(MdTableRow, MdTableRow\[\])](methods/Table.md#tablemdtablerow-mdtablerow)                       | Creates a new instance of [MdTable](../MdTable/index.md) with the specified content                                     |
| [Text(string)](methods/Text.md)                                                                        | Creates a new instance of [MdTextSpan](../MdTextSpan/index.md)                                                          |
| [ThematicBreak()](methods/ThematicBreak.md)                                                            | Creates a new instance of [MdThematicBreak](../MdThematicBreak/index.md)                                                |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*