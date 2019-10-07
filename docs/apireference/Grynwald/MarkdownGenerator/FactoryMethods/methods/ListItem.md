# FactoryMethods.ListItem Method

**Declaring Type:** [FactoryMethods](../index.md)

## Overloads

| Signature                                                       | Description                                                                                        |
| --------------------------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| [ListItem()](#listitem)                                         | Creates a new instance of [MdListItem](../../MdListItem/index.md).                                 |
| [ListItem(IEnumerable\<MdBlock\>)](#listitemienumerablemdblock) | Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified blocks. |
| [ListItem(MdBlock\[\])](#listitemmdblock)                       | Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified blocks. |
| [ListItem(MdContainerBlockBase)](#listitemmdcontainerblockbase) | Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the content.          |
| [ListItem(MdList)](#listitemmdlist)                             | Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the content.          |
| [ListItem(MdSpan)](#listitemmdspan)                             | Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified span    |
| [ListItem(MdSpan\[\])](#listitemmdspan)                         | Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified spans   |
| [ListItem(string)](#listitemstring)                             | Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified span    |

## ListItem()

Creates a new instance of [MdListItem](../../MdListItem/index.md).

```csharp
public static MdListItem ListItem();
```

### Returns

[MdListItem](../../MdListItem/index.md)

## ListItem(IEnumerable\<MdBlock\>)

Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified blocks.

```csharp
public static MdListItem ListItem(IEnumerable<MdBlock> content);
```

### Parameters

`content`  IEnumerable\<[MdBlock](../../MdBlock/index.md)\>

The blocks to initially add to the list item.

### Returns

[MdListItem](../../MdListItem/index.md)

## ListItem(MdBlock\[\])

Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified blocks.

```csharp
public static MdListItem ListItem(MdBlock[] content);
```

### Parameters

`content`  [MdBlock](../../MdBlock/index.md)\[\]

The blocks to initially add to the list item.

### Returns

[MdListItem](../../MdListItem/index.md)

## ListItem(MdContainerBlockBase)

Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the content.

```csharp
public static MdListItem ListItem(MdContainerBlockBase content);
```

### Parameters

`content`  [MdContainerBlockBase](../../MdContainerBlockBase/index.md)

The block to initially add to the list item.

### Returns

[MdListItem](../../MdListItem/index.md)

## ListItem(MdList)

Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the content.

```csharp
public static MdListItem ListItem(MdList content);
```

### Parameters

`content`  [MdList](../../MdList/index.md)

The block to initially add to the list item.

### Returns

[MdListItem](../../MdListItem/index.md)

## ListItem(MdSpan)

Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified span

```csharp
public static MdListItem ListItem(MdSpan content);
```

### Parameters

`content`  [MdSpan](../../MdSpan/index.md)

The list item's content as a [MdSpan](../../MdSpan/index.md).  The span will implicitly be wrapped in a instance of see [MdParagraph](../../MdParagraph/index.md)

### Returns

[MdListItem](../../MdListItem/index.md)

## ListItem(MdSpan\[\])

Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified spans

```csharp
public static MdListItem ListItem(MdSpan[] content);
```

### Parameters

`content`  [MdSpan](../../MdSpan/index.md)\[\]

The list item's content as one or more instances of [MdSpan](../../MdSpan/index.md).  The spans will implicitly be wrapped in a instance of see [MdParagraph](../../MdParagraph/index.md)

### Returns

[MdListItem](../../MdListItem/index.md)

## ListItem(string)

Creates a new instance of [MdListItem](../../MdListItem/index.md) containing the specified span

```csharp
public static MdListItem ListItem(string content);
```

### Parameters

`content`  string

The list item's content as a [MdSpan](../../MdSpan/index.md).  The span will implicitly be wrapped in a instance of see [MdParagraph](../../MdParagraph/index.md)

### Remarks

Although there is an implicit conversion from string to [MdSpan](../../MdSpan/index.md)the compiler does not seem to match the method in all situations, e.g. `new [] { "foo", "bar" }).Select(ListItem)` so this overload is still necessary.

### Returns

[MdListItem](../../MdListItem/index.md)

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
