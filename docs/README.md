# Markdown Generator

Markdown Generator is a library for generating Markdown documents programatically.
It implements the [CommonMark](https://spec.commonmark.org/0.28/) specification
as well as the *table* extension specified by
[GitHub Flavored Markdown](https://github.github.com/gfm/#tables-extension).

- For an overview of the library's API, see [API](./api/README.md)
- For usage examples see [Examples](./examples/README.md)

Aside from CommonMark elements, the `Grynwald.MarkdownGenerator.Extensions`
namespace provides additional elements not supported by most Markdown renderers.
**Use with caution**.

The extensions currently provides support for the
["Admonitions" extension for Python Markdown](https://python-markdown.github.io/extensions/admonition/) using the `MdAdmonition` type.
