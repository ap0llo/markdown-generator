﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# MdAdmonition Class

**Namespace:** [Grynwald.MarkdownGenerator.Extensions](../index.md)  
**Assembly:** Grynwald.MarkdownGenerator

Represents a "admonition" in a markdown document implemented by the "Admonition" extension for Python\-Markdown. For details see [Python\-Markdown: Admonition](https://python-markdown.github.io/extensions/admonition/).

```csharp
public class MdAdmonition : MdContainerBlockBase
```

**Inheritance:** object → [MdBlock](../../MdBlock/index.md) → [MdContainerBlockBase](../../MdContainerBlockBase/index.md) → MdAdmonition

## Remarks

Using this element will produce markdown which will not be rendered correctly by most Markdown implementation and should only be used, when the renderer is known to be Python Markdown with the Admonition extension enabled.

## Constructors

| Name                                                                                                                       | Description                                                                                           |
| -------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| [MdAdmonition(string)](constructors/index.md#mdadmonitionstring)                                                           | Initializes a new instance of MdAdmonition without content.                                           |
| [MdAdmonition(string, IEnumerable\<MdBlock\>)](constructors/index.md#mdadmonitionstring-ienumerablemdblock)                | Initializes a new instance of MdAdmonition.                                                           |
| [MdAdmonition(string, MdBlock\[\])](constructors/index.md#mdadmonitionstring-mdblock)                                      | Initializes a new instance of MdAdmonition.                                                           |
| [MdAdmonition(string, MdContainerBlockBase)](constructors/index.md#mdadmonitionstring-mdcontainerblockbase)                | Initializes a new instance of MdAdmonition with the specified type and content.                       |
| [MdAdmonition(string, MdList)](constructors/index.md#mdadmonitionstring-mdlist)                                            | Initializes a new instance of MdAdmonition.                                                           |
| [MdAdmonition(string, MdSpan)](constructors/index.md#mdadmonitionstring-mdspan)                                            | Initializes a new instance of MdAdmonition with the specified type and title but without any content. |
| [MdAdmonition(string, MdSpan, IEnumerable\<MdBlock\>)](constructors/index.md#mdadmonitionstring-mdspan-ienumerablemdblock) | Initializes a new instance of MdAdmonition.                                                           |
| [MdAdmonition(string, MdSpan, MdBlock\[\])](constructors/index.md#mdadmonitionstring-mdspan-mdblock)                       | Initializes a new instance of MdAdmonition.                                                           |
| [MdAdmonition(string, MdSpan, MdContainerBlockBase)](constructors/index.md#mdadmonitionstring-mdspan-mdcontainerblockbase) | Initializes a new instance of MdAdmonition.                                                           |
| [MdAdmonition(string, MdSpan, MdList)](constructors/index.md#mdadmonitionstring-mdspan-mdlist)                             | Initializes a new instance of MdAdmonition.                                                           |

## Properties

| Name                         | Description                            |
| ---------------------------- | -------------------------------------- |
| [Title](properties/Title.md) | Gets the admonition's (optional) title |
| [Type](properties/Type.md)   | Get the admonition's type.             |

## Methods

| Name                                         | Description                                                                                    |
| -------------------------------------------- | ---------------------------------------------------------------------------------------------- |
| [DeepEquals(MdBlock)](methods/DeepEquals.md) | Recursively compares the block to the specified instance of [MdBlock](../../MdBlock/index.md). |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
