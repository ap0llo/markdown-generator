# FactoryMethods.BlockQuote Method

**Declaring Type:** [FactoryMethods](../index.md)

## Overloads

| Signature                                                           | Description                                                                                       |
| ------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| [BlockQuote()](#blockquote)                                         | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md).                            |
| [BlockQuote(IEnumerable\<MdBlock\>)](#blockquoteienumerablemdblock) | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content  |
| [BlockQuote(MdBlock\[\])](#blockquotemdblock)                       | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content  |
| [BlockQuote(MdContainerBlockBase)](#blockquotemdcontainerblockbase) | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content. |
| [BlockQuote(MdList)](#blockquotemdlist)                             | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content. |
| [BlockQuote(MdSpan)](#blockquotemdspan)                             | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content  |
| [BlockQuote(MdSpan\[\])](#blockquotemdspan)                         | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content  |
| [BlockQuote(string)](#blockquotestring)                             | Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content  |

## BlockQuote()

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md).

```csharp
public static MdBlockQuote BlockQuote();
```

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

## BlockQuote(IEnumerable\<MdBlock\>)

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(IEnumerable<MdBlock> content);
```

### Parameters

`content`  IEnumerable\<[MdBlock](../../MdBlock/index.md)\>

The content of the quote as one or more blocks (see [MdBlock](../../MdBlock/index.md))

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

## BlockQuote(MdBlock\[\])

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(params MdBlock[] content);
```

### Parameters

`content`  [MdBlock](../../MdBlock/index.md)\[\]

The content of the quote as one or more blocks (see [MdBlock](../../MdBlock/index.md))

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

## BlockQuote(MdContainerBlockBase)

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content.

```csharp
public static MdBlockQuote BlockQuote(MdContainerBlockBase content);
```

### Parameters

`content`  [MdContainerBlockBase](../../MdContainerBlockBase/index.md)

The block to add to the block quote.

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

## BlockQuote(MdList)

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content.

```csharp
public static MdBlockQuote BlockQuote(MdList content);
```

### Parameters

`content`  [MdList](../../MdList/index.md)

The block to add to the block quote.

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

## BlockQuote(MdSpan)

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(MdSpan content);
```

### Parameters

`content`  [MdSpan](../../MdSpan/index.md)

The content of the quote as a span (see [MdSpan](../../MdSpan/index.md). The span will automatically be wrapped in an instance of [MdParagraph](../../MdParagraph/index.md)

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

## BlockQuote(MdSpan\[\])

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(params MdSpan[] content);
```

### Parameters

`content`  [MdSpan](../../MdSpan/index.md)\[\]

The content of the quote as one or more spans (see [MdSpan](../../MdSpan/index.md). The spans will automatically be wrapped in an instance of [MdParagraph](../../MdParagraph/index.md)

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

## BlockQuote(string)

Creates a new instance of [MdBlockQuote](../../MdBlockQuote/index.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(string content);
```

### Parameters

`content`  string

The content of the quote as a span (see [MdSpan](../../MdSpan/index.md). The string will automatically be wrapped in an instance of [MdTextSpan](../../MdTextSpan/index.md)which in turn will be wrapped in an instance of [MdParagraph](../../MdParagraph/index.md). This call is thus equivalent to `BlockQuote(Paragraph(Text(..))`

### Remarks

Although there is an implicit conversion from string to [MdSpan](../../MdSpan/index.md)the compiler does not seem to match the method in all situations, e.g. `new [] { "foo", "bar" }).Select(BlockQuote)` so this overload is still necessary.

### Returns

[MdBlockQuote](../../MdBlockQuote/index.md)

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
