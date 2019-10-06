# MdParagraph Class

**Namespace:** [Grynwald.MarkdownGenerator](../index.md)

**Assembly:** Grynwald.MarkdownGenerator

Represents a paragraph in a markdown document. For specification see https:\/\/spec.commonmark.org\/0.28\/\#paragraphs

```csharp
public sealed class MdParagraph : MdLeafBlock
```

**Inheritance:** object → [MdBlock](../MdBlock/index.md) → [MdLeafBlock](../MdLeafBlock/index.md) → MdParagraph

## Constructors

| Name                                                               | Description                                                           |
| ------------------------------------------------------------------ | --------------------------------------------------------------------- |
| [MdParagraph()](constructors/index.md#mdparagraph)                 | Initializes a new instance of MdParagraph.                            |
| [MdParagraph(MdSpan)](constructors/index.md#mdparagraphmdspan)     | Initializes a new instance of MdParagraph with the specified content. |
| [MdParagraph(MdSpan\[\])](constructors/index.md#mdparagraphmdspan) | Initializes a new instance of MdParagraph with the specified content. |

## Properties

| Name                       | Description               |
| -------------------------- | ------------------------- |
| [Text](properties/Text.md) | Gets the paragraph's text |

## Methods

| Name                                         | Description                                                                                 |
| -------------------------------------------- | ------------------------------------------------------------------------------------------- |
| [Add(MdSpan)](methods/Add.md)                | Adds the specified span to the paragraph                                                    |
| [DeepEquals(MdBlock)](methods/DeepEquals.md) | Recursively compares the block to the specified instance of [MdBlock](../MdBlock/index.md). |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*