﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# FactoryMethods.Document Method

**Declaring Type:** [FactoryMethods](../index.md)  
**Namespace:** [Grynwald.MarkdownGenerator](../../index.md)  
**Assembly:** Grynwald.MarkdownGenerator

## Overloads

| Signature                                                       | Description                                                                                                 |
| --------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| [Document(IEnumerable\<MdBlock\>)](#documentienumerablemdblock) | Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.               |
| [Document(MdAdmonition)](#documentmdadmonition)                 | Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.               |
| [Document(MdBlockQuote)](#documentmdblockquote)                 | Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.               |
| [Document(MdBlock\[\])](#documentmdblock)                       | Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.               |
| [Document(MdContainerBlock)](#documentmdcontainerblock)         | Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified block as root element. |
| [Document(MdList)](#documentmdlist)                             | Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.               |

## Document(IEnumerable\<MdBlock\>)

Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.

```csharp
public static MdDocument Document(IEnumerable<MdBlock> content);
```

### Parameters

`content`  IEnumerable\<[MdBlock](../../MdBlock/index.md)\>

One or more blocks that make up the documents's content. The blocks will be wrapped in an instance of [MdContainerBlock](../../MdContainerBlock/index.md) that will be the documents root block.

### Returns

[MdDocument](../../MdDocument/index.md)

## Document(MdAdmonition)

Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.

```csharp
public static MdDocument Document(MdAdmonition admonition);
```

### Parameters

`admonition`  [MdAdmonition](../../Extensions/MdAdmonition/index.md)

### Remarks

MdAdmonition implements IEnumerable\<T\> so this constructor is necessary to prevent ambiguities.

### Returns

[MdDocument](../../MdDocument/index.md)

## Document(MdBlockQuote)

Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.

```csharp
public static MdDocument Document(MdBlockQuote blockQuote);
```

### Parameters

`blockQuote`  [MdBlockQuote](../../MdBlockQuote/index.md)

### Remarks

MdBlockQuote implements IEnumerable\<T\> so this constructor is necessary to prevent ambiguities.

### Returns

[MdDocument](../../MdDocument/index.md)

## Document(MdBlock\[\])

Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.

```csharp
public static MdDocument Document(params MdBlock[] content);
```

### Parameters

`content`  [MdBlock](../../MdBlock/index.md)\[\]

One or more blocks that make up the documents's content. The blocks will be wrapped in an instance of [MdContainerBlock](../../MdContainerBlock/index.md) that will be the documents root block.

### Returns

[MdDocument](../../MdDocument/index.md)

## Document(MdContainerBlock)

Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified block as root element.

```csharp
public static MdDocument Document(MdContainerBlock root);
```

### Parameters

`root`  [MdContainerBlock](../../MdContainerBlock/index.md)

The documents root block

### Returns

[MdDocument](../../MdDocument/index.md)

## Document(MdList)

Creates a new instance of [MdDocument](../../MdDocument/index.md) with the specified content.

```csharp
public static MdDocument Document(MdList list);
```

### Parameters

`list`  [MdList](../../MdList/index.md)

### Remarks

MdList implements IEnumerable\<T\> so this constructor is necessary to prevent ambiguities.

### Returns

[MdDocument](../../MdDocument/index.md)

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
