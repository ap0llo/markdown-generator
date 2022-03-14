# MdAdmonition constructor (1 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md) without content.

```csharp
public MdAdmonition(string type)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |

## See Also

* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (2 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md).

```csharp
public MdAdmonition(string type, IEnumerable<MdBlock> content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |

## See Also

* class [MdBlock](../../Grynwald.MarkdownGenerator/MdBlock.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (3 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md).

```csharp
public MdAdmonition(string type, params MdBlock[] content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |

## See Also

* class [MdBlock](../../Grynwald.MarkdownGenerator/MdBlock.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (4 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md) with the specified type and content.

```csharp
public MdAdmonition(string type, MdContainerBlockBase content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |

## See Also

* class [MdContainerBlockBase](../../Grynwald.MarkdownGenerator/MdContainerBlockBase.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (5 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md).

```csharp
public MdAdmonition(string type, MdList content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |

## See Also

* class [MdList](../../Grynwald.MarkdownGenerator/MdList.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (6 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md) with the specified type and title but without any content.

```csharp
public MdAdmonition(string type, MdSpan title)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| title | The admonition's title. To create a admonition without title, use a different constructor overload. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |
| ArgumentNullException | Thrown when *title* is `null`. |

## See Also

* class [MdSpan](../../Grynwald.MarkdownGenerator/MdSpan.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (7 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md).

```csharp
public MdAdmonition(string type, MdSpan title, IEnumerable<MdBlock> content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| title | The admonition's title. To create a admonition without title, use a different constructor overload. |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |
| ArgumentNullException | Thrown when *title* is `null`. |

## See Also

* class [MdSpan](../../Grynwald.MarkdownGenerator/MdSpan.md)
* class [MdBlock](../../Grynwald.MarkdownGenerator/MdBlock.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (8 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md).

```csharp
public MdAdmonition(string type, MdSpan title, params MdBlock[] content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| title | The admonition's title. To create a admonition without title, use a different constructor overload. |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |
| ArgumentNullException | Thrown when *title* is `null`. |

## See Also

* class [MdSpan](../../Grynwald.MarkdownGenerator/MdSpan.md)
* class [MdBlock](../../Grynwald.MarkdownGenerator/MdBlock.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (9 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md).

```csharp
public MdAdmonition(string type, MdSpan title, MdContainerBlockBase content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| title | The admonition's title. To create a admonition without title, use a different constructor overload. |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |
| ArgumentNullException | Thrown when *title* is `null`. |

## See Also

* class [MdSpan](../../Grynwald.MarkdownGenerator/MdSpan.md)
* class [MdContainerBlockBase](../../Grynwald.MarkdownGenerator/MdContainerBlockBase.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

---

# MdAdmonition constructor (10 of 10)

Initializes a new instance of [`MdAdmonition`](../MdAdmonition.md).

```csharp
public MdAdmonition(string type, MdSpan title, MdList content)
```

| parameter | description |
| --- | --- |
| type | The admonition's type. Any non-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`, `hint`, `important`, `note`, `tip` and `warning` |
| title | The admonition's title. To create a admonition without title, use a different constructor overload. |
| content | The admonition's content. |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentException | Thrown when *type* is null or whitespace. |
| ArgumentNullException | Thrown when *title* is `null`. |

## See Also

* class [MdSpan](../../Grynwald.MarkdownGenerator/MdSpan.md)
* class [MdList](../../Grynwald.MarkdownGenerator/MdList.md)
* class [MdAdmonition](../MdAdmonition.md)
* namespace [Grynwald.MarkdownGenerator.Extensions](../MdAdmonition.md.md)
* assembly [Grynwald.MarkdownGenerator](../../Grynwald.MarkdownGenerator.md)

<!-- DO NOT EDIT: generated by xmldocmd for Grynwald.MarkdownGenerator.dll -->
