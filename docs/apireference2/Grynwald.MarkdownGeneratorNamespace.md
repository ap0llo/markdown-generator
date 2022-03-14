## Grynwald.MarkdownGenerator namespace

| public type | description |
| --- | --- |
| class [DefaultTextFormatter](./Grynwald.MarkdownGenerator/DefaultTextFormatter.md) | Default implementation of [`ITextFormatter`](./Grynwald.MarkdownGenerator/ITextFormatter.md). |
| class [DocumentNotFoundException](./Grynwald.MarkdownGenerator/DocumentNotFoundException.md) |  |
| class [DocumentSet&lt;T&gt;](./Grynwald.MarkdownGenerator/DocumentSet-1.md) | A collection of documents associated with a path. |
| static class [DocumentSetExtensions](./Grynwald.MarkdownGenerator/DocumentSetExtensions.md) | Provides Markdown-specific extension methods for [`DocumentSet`](./Grynwald.MarkdownGenerator/DocumentSet-1.md). |
| static class [EnumerableExtensions](./Grynwald.MarkdownGenerator/EnumerableExtensions.md) |  |
| static class [FactoryMethods](./Grynwald.MarkdownGenerator/FactoryMethods.md) | Defines static factory methods for blocks in markdown documents. When imported via "using static", this allows for more readable construction of documents, e.g. |
| static class [HtmlUtilities](./Grynwald.MarkdownGenerator/HtmlUtilities.md) |  |
| interface [IDocument](./Grynwald.MarkdownGenerator/IDocument.md) | Represents an arbitrary document. |
| interface [ITextFormatter](./Grynwald.MarkdownGenerator/ITextFormatter.md) | Provides an abstraction over converting text to be written into a Markdown file. |
| abstract class [MdBlock](./Grynwald.MarkdownGenerator/MdBlock.md) | Represents a block in a markdown document. Blocks are the basic building units of markdown documents. A document consists of one or more blocks. |
| class [MdBlockQuote](./Grynwald.MarkdownGenerator/MdBlockQuote.md) | Represent a block quote in a markdown document. For specification see [CommonMark - Block quotes](https://spec.commonmark.org/0.28/#block-quotes). |
| class [MdBulletList](./Grynwald.MarkdownGenerator/MdBulletList.md) | Represents a bullet list. For specification see [CommonMark - List items](https://spec.commonmark.org/0.28/#list-items) |
| enum [MdBulletListStyle](./Grynwald.MarkdownGenerator/MdBulletListStyle.md) | Defines the available serialization styles for bullet lists (see [`MdBulletList`](./Grynwald.MarkdownGenerator/MdBulletList.md)). For specification see [CommonMark - List items](https://spec.commonmark.org/0.28/#list-items). |
| class [MdCodeBlock](./Grynwald.MarkdownGenerator/MdCodeBlock.md) | Represents a fenced code block. For specification see [CommonMark -Fenced code blocks](https://spec.commonmark.org/0.28/#fenced-code-blocks). |
| enum [MdCodeBlockStyle](./Grynwald.MarkdownGenerator/MdCodeBlockStyle.md) | Defines the available serialization styles for fenced code blocks (see [`MdCodeBlock`](./Grynwald.MarkdownGenerator/MdCodeBlock.md)) For specification see [CommonMark - Fenced code blocks](https://spec.commonmark.org/0.28/#fenced-code-blocks). |
| class [MdCodeSpan](./Grynwald.MarkdownGenerator/MdCodeSpan.md) | Represents a inline code span For specification see [CommonMark - Code spans](https://spec.commonmark.org/0.28/#code-spans). |
| class [MdCompositeSpan](./Grynwald.MarkdownGenerator/MdCompositeSpan.md) | Represents a list or inline-elements |
| class [MdContainerBlock](./Grynwald.MarkdownGenerator/MdContainerBlock.md) | Represents a block that can contains other blocks. For specification see [CommonMark - Container blocks ](https://spec.commonmark.org/0.28/#container-blocks). |
| abstract class [MdContainerBlockBase](./Grynwald.MarkdownGenerator/MdContainerBlockBase.md) | Base class for blocks that can contains other blocks. |
| class [MdDocument](./Grynwald.MarkdownGenerator/MdDocument.md) | Represents a markdown document |
| class [MdDocumentSet](./Grynwald.MarkdownGenerator/MdDocumentSet.md) | A collection of documents associated with a path. |
| class [MdEmphasisSpan](./Grynwald.MarkdownGenerator/MdEmphasisSpan.md) | Represents emphasized/italic text For specification see [CommonMark - Emphasis and strong emphasis](https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis). |
| enum [MdEmphasisStyle](./Grynwald.MarkdownGenerator/MdEmphasisStyle.md) | Defines the available serialization styles for emphasis (see [`MdEmphasisSpan`](./Grynwald.MarkdownGenerator/MdEmphasisSpan.md)) and strong emphasis (see [`MdStrongEmphasisSpan`](./Grynwald.MarkdownGenerator/MdStrongEmphasisSpan.md)). For specification see [CommonMark - Emphasis and strong emphasis](https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis). |
| class [MdEmptyBlock](./Grynwald.MarkdownGenerator/MdEmptyBlock.md) | Represents an empty block. |
| class [MdEmptySpan](./Grynwald.MarkdownGenerator/MdEmptySpan.md) | Represents an empty text element. |
| class [MdHeading](./Grynwald.MarkdownGenerator/MdHeading.md) | Represents a heading in a markdown document For specification see [CommonMark - ATX headings](https://spec.commonmark.org/0.28/#atx-headings) respectively [CommonMark - Setext headings](https://spec.commonmark.org/0.28/#setext-headings). |
| enum [MdHeadingAnchorStyle](./Grynwald.MarkdownGenerator/MdHeadingAnchorStyle.md) | Defines the available options for including text anchors for headings in the output. |
| enum [MdHeadingStyle](./Grynwald.MarkdownGenerator/MdHeadingStyle.md) | Defines the available serialization styles for headings (see [`MdHeading`](./Grynwald.MarkdownGenerator/MdHeading.md)). For specification see [CommonMark - ATX headings](https://spec.commonmark.org/0.28/#atx-headings) respectively [CommonMark - Setext headings](https://spec.commonmark.org/0.28/#setext-headings). |
| class [MdImageSpan](./Grynwald.MarkdownGenerator/MdImageSpan.md) | Represents an inline image element For specification see [CommonMark - Images](https://spec.commonmark.org/0.28/#images). |
| abstract class [MdLeafBlock](./Grynwald.MarkdownGenerator/MdLeafBlock.md) | Base class for all types of leaf blocks (blocks that cannot contain other blocks) For specification see [CommonMark - Leaf blocks](https://spec.commonmark.org/0.28/#leaf-blocks). |
| class [MdLinkSpan](./Grynwald.MarkdownGenerator/MdLinkSpan.md) | Represents a link element. For specification see [CommonMark - Links](https://spec.commonmark.org/0.28/#links). |
| abstract class [MdList](./Grynwald.MarkdownGenerator/MdList.md) | Base class for ordered and bullet lists. Implementations are [`MdBulletList`](./Grynwald.MarkdownGenerator/MdBulletList.md) respectively [`MdOrderedList`](./Grynwald.MarkdownGenerator/MdOrderedList.md). |
| class [MdListItem](./Grynwald.MarkdownGenerator/MdListItem.md) | Represents a item in an bullet or ordered list. For specification see [CommonMark - List items](https://spec.commonmark.org/0.28/#list-items). |
| abstract class [MdListItemBase](./Grynwald.MarkdownGenerator/MdListItemBase.md) | Base class for list item implementations |
| class [MdOrderedList](./Grynwald.MarkdownGenerator/MdOrderedList.md) | Represents a ordered list. For specification see [CommonMark - List items](https://spec.commonmark.org/0.28/#list-items). |
| enum [MdOrderedListStyle](./Grynwald.MarkdownGenerator/MdOrderedListStyle.md) | Defines the available serialization styles for ordered lists (see [`MdBulletList`](./Grynwald.MarkdownGenerator/MdBulletList.md)). For specification see [CommonMark - List items](https://spec.commonmark.org/0.28/#list-items). |
| class [MdParagraph](./Grynwald.MarkdownGenerator/MdParagraph.md) | Represents a paragraph in a markdown document. For specification see [CommonMark - Paragraphs](https://spec.commonmark.org/0.28/#paragraphs). |
| class [MdRawMarkdownSpan](./Grynwald.MarkdownGenerator/MdRawMarkdownSpan.md) | Represents a span of raw Markdown content that will not be escaped before being written to the output |
| class [MdSerializationOptions](./Grynwald.MarkdownGenerator/MdSerializationOptions.md) | Encapsulates settings that control how a document is serialized. A instance of [`MdSerializationOptions`](./Grynwald.MarkdownGenerator/MdSerializationOptions.md) can be passed to the ToString overloads in [`MdBlock`](./Grynwald.MarkdownGenerator/MdBlock.md), [`MdSpan`](./Grynwald.MarkdownGenerator/MdSpan.md) and [`MdDocument`](./Grynwald.MarkdownGenerator/MdDocument.md) as well as the Save() method of [`MdDocument`](./Grynwald.MarkdownGenerator/MdDocument.md) |
| class [MdSingleLineSpan](./Grynwald.MarkdownGenerator/MdSingleLineSpan.md) | Represents a span that will be written to the output as a single line. All line breaks will be removed and replaced by spaces. Trailing line breaks are removed |
| abstract class [MdSpan](./Grynwald.MarkdownGenerator/MdSpan.md) | Represent a inline text element in a markdown document. |
| class [MdStrongEmphasisSpan](./Grynwald.MarkdownGenerator/MdStrongEmphasisSpan.md) | Represents strongly-emphasized/bold content For specification see [CommonMark - Emphasis and strong emphasis](https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis). |
| class [MdTable](./Grynwald.MarkdownGenerator/MdTable.md) | Represents a table in a Markdown document. |
| class [MdTableRow](./Grynwald.MarkdownGenerator/MdTableRow.md) | Represent a row in a table (see [`MdTable`](./Grynwald.MarkdownGenerator/MdTable.md)) |
| enum [MdTableStyle](./Grynwald.MarkdownGenerator/MdTableStyle.md) | Defines the available serialization styles for tables (see [`MdTable`](./Grynwald.MarkdownGenerator/MdTable.md)). |
| class [MdTextSpan](./Grynwald.MarkdownGenerator/MdTextSpan.md) | Represents an (unformatted) text element which's content will be escaped before being written to the output |
| class [MdThematicBreak](./Grynwald.MarkdownGenerator/MdThematicBreak.md) | Represents a thematic break. For specification see [CommonMark - Thematic breaks](https://spec.commonmark.org/0.28/#thematic-breaks). |
| enum [MdThematicBreakStyle](./Grynwald.MarkdownGenerator/MdThematicBreakStyle.md) | Defines the available serialization styles for thematic breaks (see [`MdThematicBreak`](./Grynwald.MarkdownGenerator/MdThematicBreak.md)). For specification see [CommonMark - Thematic breaks](https://spec.commonmark.org/0.28/#thematic-breaks). |
| class [MkDocsTextFormatter](./Grynwald.MarkdownGenerator/MkDocsTextFormatter.md) | Implementation of [`ITextFormatter`](./Grynwald.MarkdownGenerator/ITextFormatter.md) optimized for rendering generated Markdown file using [MkDocs](https://www.mkdocs.org/). |
| class [PresetNotFoundException](./Grynwald.MarkdownGenerator/PresetNotFoundException.md) |  |
| static class [SyntaxVisualizer](./Grynwald.MarkdownGenerator/SyntaxVisualizer.md) |  |
| class [TextDocument](./Grynwald.MarkdownGenerator/TextDocument.md) | Represents a plain text document. |

<!-- DO NOT EDIT: generated by xmldocmd for Grynwald.MarkdownGenerator.dll -->
