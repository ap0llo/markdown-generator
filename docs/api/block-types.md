# Block Types

All block types derive from the base class
[`MdBlock`](../apireference/Grynwald/MarkdownGenerator/MdBlock/index.md).

## Container blocks

- [`MdContainerBlock`](../apireference/Grynwald/MarkdownGenerator/MdContainerBlock/index.md)
  does not represent a syntactic construct in the markdown document but serves
  as a means to combine multiple blocks into one.
  For example, [`MdDocument`](../apireference/Grynwald/MarkdownGenerator/MdDocument/index.md)
  has a single root block that represents the entire document.
  To build a document that contains multiple blocks, they are wrapped in an
  instance of `MdContainerBlock`
- [`MdBlockQuote`](../apireference/Grynwald/MarkdownGenerator/MdBlockQuote/index.md):
  Reprents a [block quote](https://spec.commonmark.org/0.28/#block-quotes)
  The quoted content can be any other block (typically [`MdParagraph`](../apireference/Grynwald/MarkdownGenerator/MdParagraph/index.md)).
- [`MdListItem`](../apireference/Grynwald/MarkdownGenerator/MdListItem/index.md):
  Represents an [list item](https://spec.commonmark.org/0.28/#list-items).
  Whether the item an item in an ordered list or a bullet list, depdens
  on whether the item is added to a `MdOrderedList` or a `MdBulletList`

## Leaf blocks

- [`MdHeading`](../apireference/Grynwald/MarkdownGenerator/MdHeading/index.md):
  Represents a heading.
  Headings can be both [ATX headings](https://spec.commonmark.org/0.28/#atx-headings)
  or [Setext headings](https://spec.commonmark.org/0.28/#setext-headings) in the
  output depdening on the selected
  [serialization options](../apireference/Grynwald/MarkdownGenerator/MdSerializationOptions/index.md).
- [`MdCodeBlock`](../apireference/Grynwald/MarkdownGenerator/MdCodeBlock/index.md):
  Represents a [fenced code block](https://spec.commonmark.org/0.28/#fenced-code-blocks).
- [`MdParagraph`](../apireference/Grynwald/MarkdownGenerator/MdParagraph/index.md):
  Represent a [paragraph](https://spec.commonmark.org/0.28/#paragraphs)
- [`MdTable`](../apireference/Grynwald/MarkdownGenerator/MdTable/index.md):
  Represents a table. Tables are not part of the CommonMark
  specification, but a widely adopted table format is defined as part of the
  [GitHub Flavored Markdown](https://github.github.com/gfm/#tables-extension)
  specification.  
  Tables can be written to the output either as GitHub Flavored Markdown tables
  (default) or as inline HTML tables. See 
  [Serialization Options](../apireference/Grynwald/MarkdownGenerator/MdSerializationOptions/index.md)
  for details.
- [`MdThematicBreak`](../apireference/Grynwald/MarkdownGenerator/MdThematicBreak/index.md):
  Represents a [thematic break](https://spec.commonmark.org/0.28/#thematic-breaks)

## Lists

Strictly speaking, lists are neither container blocks nor leaf blocks.
Lists cannot directly contain other blocks, but a sequence of `MdListItem` instances
that in turn are container blocks.

There are two types of lists:

- [`MdBulletList`](../apireference/Grynwald/MarkdownGenerator/MdBulletList/index.md):
  Represents a bullet list
- [`MdOrderedList`](../apireference/Grynwald/MarkdownGenerator/MdOrderedList/index.md): 
  Represents a ordered list

## Extension blocks

The namespace [`Grynwald.MarkdownGenerator.Extensions`](../apireference/Grynwald/MarkdownGenerator/Extensions/index.md)
provides additional block types that implement elements supported by most
Markdown renderers.
**Use with caution**.

- [`MdAdmonition`](../apireference/Grynwald/MarkdownGenerator/Extensions/MdAdmonition/index.md):
  Adds support for emitting *admonitions* for use with the
  ["Admonitions" extension for Python Markdown](https://python-markdown.github.io/extensions/admonition/).
  