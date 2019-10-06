# MdListItem Constructors

**Declaring Type:** [MdListItem](../index.md)

## Overloads

| Signature                                                           | Description                                                                               |
| ------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| [MdListItem()](#mdlistitem)                                         | Initializes a new, empty instance of [MdListItem](../index.md).                           |
| [MdListItem(IEnumerable\<MdBlock\>)](#mdlistitemienumerablemdblock) | Initializes a new instance of [MdListItem](../index.md) containing the specified blocks.  |
| [MdListItem(MdBlock\[\])](#mdlistitemmdblock)                       | Initializes a new instance of [MdListItem](../index.md) containing the specified blocks.  |
| [MdListItem(MdContainerBlockBase)](#mdlistitemmdcontainerblockbase) | Initializes a new instance of [MdListItem](../index.md) containing the specified content. |
| [MdListItem(MdList)](#mdlistitemmdlist)                             | Initializes a new instance of [MdListItem](../index.md) containing the specified content. |
| [MdListItem(MdSpan)](#mdlistitemmdspan)                             | Initializes a new instance of [MdListItem](../index.md) containing the specified span     |
| [MdListItem(MdSpan\[\])](#mdlistitemmdspan)                         | Initializes a new instance of [MdListItem](../index.md) containing the specified spans    |

## MdListItem()

Initializes a new, empty instance of [MdListItem](../index.md).

```csharp
public MdListItem();
```

## MdListItem(IEnumerable\<MdBlock\>)

Initializes a new instance of [MdListItem](../index.md) containing the specified blocks.

```csharp
public MdListItem(IEnumerable<MdBlock> content);
```

### Parameters

`content`  IEnumerable\<[MdBlock](../../MdBlock/index.md)\>

The blocks to initially add to the list item.

## MdListItem(MdBlock\[\])

Initializes a new instance of [MdListItem](../index.md) containing the specified blocks.

```csharp
public MdListItem(MdBlock[] content);
```

### Parameters

`content`  [MdBlock](../../MdBlock/index.md)\[\]

The blocks to initially add to the list item.

## MdListItem(MdContainerBlockBase)

Initializes a new instance of [MdListItem](../index.md) containing the specified content.

```csharp
public MdListItem(MdContainerBlockBase content);
```

### Parameters

`content`  [MdContainerBlockBase](../../MdContainerBlockBase/index.md)

The block to initially add to the list item.

## MdListItem(MdList)

Initializes a new instance of [MdListItem](../index.md) containing the specified content.

```csharp
public MdListItem(MdList content);
```

### Parameters

`content`  [MdList](../../MdList/index.md)

The list to initially add to the list item.

## MdListItem(MdSpan)

Initializes a new instance of [MdListItem](../index.md) containing the specified span

```csharp
public MdListItem(MdSpan content);
```

### Parameters

`content`  [MdSpan](../../MdSpan/index.md)

The list item's content as a [MdSpan](../../MdSpan/index.md). The span will implicitly be wrapped in a instance of see [MdParagraph](../../MdParagraph/index.md)

## MdListItem(MdSpan\[\])

Initializes a new instance of [MdListItem](../index.md) containing the specified spans

```csharp
public MdListItem(MdSpan[] content);
```

### Parameters

`content`  [MdSpan](../../MdSpan/index.md)\[\]

The list item's content as one or more instances of [MdSpan](../../MdSpan/index.md). The spans will implicitly be wrapped in a instance of see [MdParagraph](../../MdParagraph/index.md)

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*