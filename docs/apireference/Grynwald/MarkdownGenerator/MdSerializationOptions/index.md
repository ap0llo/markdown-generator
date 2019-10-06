# MdSerializationOptions Class

**Namespace:** [Grynwald.MarkdownGenerator](../index.md)

**Assembly:** Grynwald.MarkdownGenerator

Encapsulates settings that control how a document is serialized. A instance of MdSerializationOptions can be passed to the ToString overloads in [MdBlock](../MdBlock/index.md), [MdSpan](../MdSpan/index.md) and [MdDocument](../MdDocument/index.md)as well as the Save() method of [MdDocument](../MdDocument/index.md)

```csharp
public class MdSerializationOptions
```

**Inheritance:** object → MdSerializationOptions

## Constructors

| Name                                              | Description |
| ------------------------------------------------- | ----------- |
| [MdSerializationOptions()](constructors/index.md) |             |

## Fields

| Name                         | Description |
| ---------------------------- | ----------- |
| [Default](fields/Default.md) |             |

## Properties

| Name                                                                     | Description                                                                                                                                                                                                                                                                              |
| ------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [BulletListStyle](properties/BulletListStyle.md)                         | Gets or sets the style for bullet list items. Default value: Dash.                                                                                                                                                                                                                       |
| [CodeBlockStyle](properties/CodeBlockStyle.md)                           | Gets or sets the style of code blocks. Default value: Backtick.                                                                                                                                                                                                                          |
| [EmphasisStyle](properties/EmphasisStyle.md)                             | Gets or sets the style for emphasized and strongly emphasized text. Default value: Asterisk.                                                                                                                                                                                             |
| [HeadingStyle](properties/HeadingStyle.md)                               | Gets or sets the style for headings. Default value: Atx.                                                                                                                                                                                                                                 |
| [MaxLineLength](properties/MaxLineLength.md)                             | Gets or sets the maximum length of a line in the output. When set to a value greater than 0, line breaks will be inserted after the specified number of characters when possible. Default value: `-1` (no line length limitation)                                                        |
| [MinimumListIndentationWidth](properties/MinimumListIndentationWidth.md) | Gets or sets the minimum number of characters to use for indenting list items in multi\-level lists (compared to items of the outer list level). The value indicates a minimum indentation. List items are always indented at least by the length of the list marker. Default value: `2` |
| [OrderedListStyle](properties/OrderedListStyle.md)                       | Gets or sets the style for ordered list items. Default value: Dot.                                                                                                                                                                                                                       |
| [TableStyle](properties/TableStyle.md)                                   | Gets or sets the style for tables. Default value: GFM.                                                                                                                                                                                                                                   |
| [TextFormatter](properties/TextFormatter.md)                             | Gets or sets the implementation to use for escaping text when saving a Markdown document.                                                                                                                                                                                                |
| [ThematicBreakStyle](properties/ThematicBreakStyle.md)                   | Gets or sets the style to use for thematic breaks. Default value: Underscore.                                                                                                                                                                                                            |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
