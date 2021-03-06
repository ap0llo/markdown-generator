﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# FactoryMethods.BulletList Method

**Declaring Type:** [FactoryMethods](../index.md)  
**Namespace:** [Grynwald.MarkdownGenerator](../../index.md)  
**Assembly:** Grynwald.MarkdownGenerator

## Overloads

| Signature                                                                 | Description                                                                                         |
| ------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| [BulletList(IEnumerable\<MdListItem\>)](#bulletlistienumerablemdlistitem) | Creates a new instance of [MdBulletList](../../MdBulletList/index.md) with the specified list items |
| [BulletList(MdListItem\[\])](#bulletlistmdlistitem)                       | Creates a new instance of [MdBulletList](../../MdBulletList/index.md) with the specified list items |

## BulletList(IEnumerable\<MdListItem\>)

Creates a new instance of [MdBulletList](../../MdBulletList/index.md) with the specified list items

```csharp
public static MdBulletList BulletList(IEnumerable<MdListItem> listItems);
```

### Parameters

`listItems`  IEnumerable\<[MdListItem](../../MdListItem/index.md)\>

The list items to initially add to the list

### Returns

[MdBulletList](../../MdBulletList/index.md)

## BulletList(MdListItem\[\])

Creates a new instance of [MdBulletList](../../MdBulletList/index.md) with the specified list items

```csharp
public static MdBulletList BulletList(params MdListItem[] listItems);
```

### Parameters

`listItems`  [MdListItem](../../MdListItem/index.md)\[\]

The list items to initially add to the list

### Returns

[MdBulletList](../../MdBulletList/index.md)

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
