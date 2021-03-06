﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# MdContainerBlockBase.Insert Method

**Declaring Type:** [MdContainerBlockBase](../index.md)  
**Namespace:** [Grynwald.MarkdownGenerator](../../index.md)  
**Assembly:** Grynwald.MarkdownGenerator

Inserts an block into the container at the specified index.

```csharp
public void Insert(int index, MdBlock block);
```

## Parameters

`index`  int

The index (zero\-based) to insert the block at.

`block`  [MdBlock](../../MdBlock/index.md)

The block to insert into the container.

## Exceptions

ArgumentNullException

Thrown when `block` is `null`.

ArgumentOutOfRangeException

Thrown when `index` is negative or greater than the number of blocks in the container.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
