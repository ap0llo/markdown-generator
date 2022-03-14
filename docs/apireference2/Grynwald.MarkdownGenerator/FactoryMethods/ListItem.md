# FactoryMethods.ListItem method (1 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md).

```csharp
public static MdListItem ListItem()
```

## See Also

* class [MdListItem](../MdListItem.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.ListItem method (2 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md) containing the specified blocks.

```csharp
public static MdListItem ListItem(IEnumerable<MdBlock> content)
```

| parameter | description |
| --- | --- |
| content | The blocks to initially add to the list item. |

## See Also

* class [MdListItem](../MdListItem.md)
* class [MdBlock](../MdBlock.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.ListItem method (3 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md) containing the specified blocks.

```csharp
public static MdListItem ListItem(params MdBlock[] content)
```

| parameter | description |
| --- | --- |
| content | The blocks to initially add to the list item. |

## See Also

* class [MdListItem](../MdListItem.md)
* class [MdBlock](../MdBlock.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.ListItem method (4 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md) containing the content.

```csharp
public static MdListItem ListItem(MdContainerBlockBase content)
```

| parameter | description |
| --- | --- |
| content | The block to initially add to the list item. |

## See Also

* class [MdListItem](../MdListItem.md)
* class [MdContainerBlockBase](../MdContainerBlockBase.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.ListItem method (5 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md) containing the content.

```csharp
public static MdListItem ListItem(MdList content)
```

| parameter | description |
| --- | --- |
| content | The block to initially add to the list item. |

## See Also

* class [MdListItem](../MdListItem.md)
* class [MdList](../MdList.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.ListItem method (6 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md) containing the specified span

```csharp
public static MdListItem ListItem(MdSpan content)
```

| parameter | description |
| --- | --- |
| content | The list item's content as a [`MdSpan`](../MdSpan.md). The span will implicitly be wrapped in a instance of see [`MdParagraph`](../MdParagraph.md) |

## See Also

* class [MdListItem](../MdListItem.md)
* class [MdSpan](../MdSpan.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.ListItem method (7 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md) containing the specified spans

```csharp
public static MdListItem ListItem(params MdSpan[] content)
```

| parameter | description |
| --- | --- |
| content | The list item's content as one or more instances of [`MdSpan`](../MdSpan.md). The spans will implicitly be wrapped in a instance of see [`MdParagraph`](../MdParagraph.md) |

## See Also

* class [MdListItem](../MdListItem.md)
* class [MdSpan](../MdSpan.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# FactoryMethods.ListItem method (8 of 8)

Creates a new instance of [`MdListItem`](../MdListItem.md) containing the specified span

```csharp
public static MdListItem ListItem(string content)
```

| parameter | description |
| --- | --- |
| content | The list item's content as a [`MdSpan`](../MdSpan.md). The span will implicitly be wrapped in a instance of see [`MdParagraph`](../MdParagraph.md) |

## Remarks

Although there is an implicit conversion from String to [`MdSpan`](../MdSpan.md) the compiler does not seem to match the method in all situations, e.g. `new [] { "foo", "bar" }).Select(ListItem)` so this overload is still necessary.

## See Also

* class [MdListItem](../MdListItem.md)
* class [FactoryMethods](../FactoryMethods.md)
* namespace [Grynwald.MarkdownGenerator](../FactoryMethods.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

<!-- DO NOT EDIT: generated by xmldocmd for Grynwald.MarkdownGenerator.dll -->
