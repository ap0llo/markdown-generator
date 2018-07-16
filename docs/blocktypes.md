# Block types

All classes are defined in the `Grynwald.MarkdownGenerator.Model` namespace.  
The factory methods are defined in the class `Grynwald.MarkdownGenerator.FactoryMethods`.

## Document

A new markdown document is initialized using either the `Document` factory
method or by initializing a instance of `MdDocument`.

## Blocks

| Block type (name in specification) | Class name        | Factory method name | Specification            |
| ---------------------------------- | ----------------- | ------------------- | ------------------------ |
| Thematic break                     | `MdThematicBreak` | `ThematicBreak`     | CommonMark               |
| ATX heading                        | `MdHeading`       | `Heading`           | CommonMark               |
| Fenced code block                  | `MdCodeBlock`     | `CodeBlock`         | CommonMark               |
| Paragraph                          | `MdParagraph`     | `Paragraph`         | CommonMark               |
| Block quote                        | `MdBlockQuote`    | `BlockQuote`        | CommonMark               |
| Bullet list                        | `MdBulletList`    | `BulletList`        | CommonMark               |
| Ordered list                       | `MdOrderedList`   | `OrderedList`       | CommonMark               |
| List item                          | `MdListItem`      | `ListItem`          | CommonMark               |
| Table                              | `MdTable`         | `Table`             | GitHub Flavored Markdown |