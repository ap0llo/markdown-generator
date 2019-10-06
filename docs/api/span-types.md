# Span Types

Spans are inline text elements that either wrap string content or other spans.
All span types derive from the base class
[`MdSpan`](../apireference/Grynwald/MarkdownGenerator/MdSpan/index.md).

## Types

- [`MdTextSpan`](../apireference/Grynwald/MarkdownGenerator/MdTextSpan/index.md):
  The most common span type that represents plain text content.  
  **Note:** All content of text spans will be escaped in the output,
  e.g. ``**text**`` will show up unchanged in the output and **not**
  be rendered as emphasized text.
- [`MdCodeSpan`](../apireference/Grynwald/MarkdownGenerator/MdCodeSpan/index.md)
  represents a inline [code span](https://spec.commonmark.org/0.28/#code-spans).
- [`MdCompositeSpan`](../apireference/Grynwald/MarkdownGenerator/MdCompositeSpan/index.md)
  is a utility span class that can be used to combine
  multiple spans into a single instance (most block types can only have a
  single content item)
- [`MdEmphasisSpan`](../apireference/Grynwald/MarkdownGenerator/MdEmphasisSpan/index.md)
  represents [emphasized text](https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis)
- [`MdStrongEmphasisSpan`](../apireference/Grynwald/MarkdownGenerator/MdStrongEmphasisSpan/index.md)
  represents [strongly emphasized text](https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis)
- [`MdImageSpan`](../apireference/Grynwald/MarkdownGenerator/MdImageSpan/index.md)
  represents an [inline image](https://spec.commonmark.org/0.28/#images)
- [`MdLinkSpan`](../apireference/Grynwald/MarkdownGenerator/MdLinkSpan/index.md)
  represents a [link element](https://spec.commonmark.org/0.28/#links)
- [`MdRawMarkdownSpan`](../apireference/Grynwald/MarkdownGenerator/MdRawMarkdownSpan/index.md):
  Raw markdown content that will be written to the output unchanged, i.e.
  the text will not be escaped and this span can thus be used to write markdown content
  and also inline html content to the output
- [`MdSingleLineSpan`](../apireference/Grynwald/MarkdownGenerator/MdSingleLineSpan/index.md)
  is a span class that can be used to cause any other span to be
  written to the output wihtout line breaks. Spans for elements that only allow
  single line content (e.g. table cells or headings) will automatically be wrapped
  into a instance of `MdSingleLineSpan`

## Implicit conversion from string

`MdSpan` defines an implicit converion from `string`. When converting from string,
the content will be wrapped into an instance of `MdTextSpan` and thus be escaped.

To write a string to the output without escaping, use `MdRawMarkdownSpan`
