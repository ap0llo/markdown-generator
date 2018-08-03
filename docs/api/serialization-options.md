# Serialization options

For several markdown constructs, CommonMark defines multiple possible syntaxes.
(e.g. text can be emphasized using both `*` and `_`).

`MdSerializationOptions` can be used to customize how these constructs are serialized.

All serialization methods (`ToString()` in `MdDocument`, blocks and spans as well as
`MdDocument.Save()` have overloads that accept a `MdSerializationOptions` parameter.

| Property           | Description                                                                                      | Default value |
| ------------------ | ------------------------------------------------------------------------------------------------ | ------------- |
| EmphasisStyle      | Specifies whether to use asterisks or underscores for emphasized text                            | Asterisk      |
| ThematicBreakStyle | Specifies whether to use underscores, dashes or asteriks for thematic breaks                     | Underscore    |
| HeadingStyle       | Specifies whether to use ATX or Setext headings                                                  | ATX           |
| CodeBlockStyle     | Specifies whether to use backticks or tildes for fenced code blocks                              | Backtick      |
| BulletListStyle    | Specifies whether to use dashes, pluses or asterisks as bullet list markers                      | Dash          |
| OrderedListStyle   | Specifies whether to use dots or parentheses for ordered list markers                            | Dot           |
| TableStyle         | Specifies whether to serilaize tables in GitHub Flavored Markdown (GFM) syntax or as inline html | GFM           |
| MaxLineLength      | Specifies whether the maximum length of a line in the output *                                   | unlimited     |

*: Not all types of blocks can be split into multiple lines. Also line breaks will only be inserted between words,
   so if the length of a word exceeds the maximum line length the max length cannot be adhered to.
