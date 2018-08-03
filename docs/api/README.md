# Markdown Generator API

The API of Markdown Generator is centered around the `MdDocument` class
that represents a document. An instance of `MdDocument` is a collection of
*blocks* that make up the document.

## Blocks

There are different types of blocks to represent different Markdown features. 
At the core, there are two groups of blocks

- *Container blocks*: Blocks that are a collection of other blocks
- *Leaf blocks*: Blocks that contain content in the form of *spans* that
  can not contain other blocks

A full list of block types can be found [here](./block-types.md).

## Spans

Content of *leaf blocks* is represented as *spans*. Spans are inline text elements
that either wrap string content or other spans.

A full list of span types can be found [here](./span-types.md).

## Serialization options

For several markdown constructs, CommonMark defines multiple possible syntaxes.
(e.g. text can be emphasized using both `*` and `_`).

All serialization methods (`ToString()` in `MdDocument`, blocks and spans as well as
`MdDocument.Save()` have overloads that accept a `MdSerializationOptions` parameter.

See [Serialization options](./serialization-options.md) for details.

## Factory methods

To ease construction of markdown documents, all block and span types can
be created using factory methods defined in the class `Grynwald.MarkdownGenerator.FactoryMethods`
instead of using the `new` operator.

See [Factory Methods](./factorymethods.md) for details.