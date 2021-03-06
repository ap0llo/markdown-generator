﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# MdSerializationOptions.TextFormatter Property

**Declaring Type:** [MdSerializationOptions](../index.md)  
**Namespace:** [Grynwald.MarkdownGenerator](../../index.md)  
**Assembly:** Grynwald.MarkdownGenerator

Gets or sets the implementation to use for escaping text when saving a Markdown document.

```csharp
public ITextFormatter TextFormatter { get; set; }
```

## Property Value

[ITextFormatter](../../ITextFormatter/index.md)

## Remarks

The implementation of [ITextFormatter](../../ITextFormatter/index.md) set here will be used to escape plain text before writing it to the output document.

When no escaper is set, [DefaultTextFormatter](../../DefaultTextFormatter/index.md) will be used.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
