# FactoryMethods.BlockQuote method (1 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md).

```csharp
public static MdBlockQuote BlockQuote()
```

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.BlockQuote method (2 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(IEnumerable<MdBlock> content)
```

| parameter | description |
| --- | --- |
| content | The content of the quote as one or more blocks (see [`MdBlock`](../MdBlock.md)) |

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [MdBlock](../MdBlock.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.BlockQuote method (3 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(params MdBlock[] content)
```

| parameter | description |
| --- | --- |
| content | The content of the quote as one or more blocks (see [`MdBlock`](../MdBlock.md)) |

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [MdBlock](../MdBlock.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.BlockQuote method (4 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md) with the specified content.

```csharp
public static MdBlockQuote BlockQuote(MdContainerBlockBase content)
```

| parameter | description |
| --- | --- |
| content | The block to add to the block quote. |

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [MdContainerBlockBase](../MdContainerBlockBase.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.BlockQuote method (5 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md) with the specified content.

```csharp
public static MdBlockQuote BlockQuote(MdList content)
```

| parameter | description |
| --- | --- |
| content | The block to add to the block quote. |

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [MdList](../MdList.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.BlockQuote method (6 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(MdSpan content)
```

| parameter | description |
| --- | --- |
| content | The content of the quote as a span (see [`MdSpan`](../MdSpan.md). The span will automatically be wrapped in an instance of [`MdParagraph`](../MdParagraph.md) |

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [MdSpan](../MdSpan.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.BlockQuote method (7 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(params MdSpan[] content)
```

| parameter | description |
| --- | --- |
| content | The content of the quote as one or more spans (see [`MdSpan`](../MdSpan.md). The spans will automatically be wrapped in an instance of [`MdParagraph`](../MdParagraph.md) |

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [MdSpan](../MdSpan.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.BlockQuote method (8 of 8)

Creates a new instance of [`MdBlockQuote`](../MdBlockQuote.md) with the specified content

```csharp
public static MdBlockQuote BlockQuote(string content)
```

| parameter | description |
| --- | --- |
| content | The content of the quote as a span (see [`MdSpan`](../MdSpan.md). The string will automatically be wrapped in an instance of [`MdTextSpan`](../MdTextSpan.md) which in turn will be wrapped in an instance of [`MdParagraph`](../MdParagraph.md). This call is thus equivalent to `BlockQuote(Paragraph(Text(..))` |

## Remarks

Although there is an implicit conversion from String to [`MdSpan`](../MdSpan.md) the compiler does not seem to match the method in all situations, e.g. `new [] { "foo", "bar" }).Select(BlockQuote)` so this overload is still necessary.

## See Also

* class [MdBlockQuote](../MdBlockQuote.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

<!-- DO NOT EDIT: generated by xmldocmd for Grynwald.MarkdownGenerator.dll -->
