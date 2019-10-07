# MdAdmonition Constructors

**Declaring Type:** [MdAdmonition](../index.md)

## Overloads

| Signature                                                                                             | Description                                                                                                          |
| ----------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| [MdAdmonition(string)](#mdadmonitionstring)                                                           | Initializes a new instance of [MdAdmonition](../index.md) without content.                                           |
| [MdAdmonition(string, IEnumerable\<MdBlock\>)](#mdadmonitionstring-ienumerablemdblock)                | Initializes a new instance of [MdAdmonition](../index.md).                                                           |
| [MdAdmonition(string, MdBlock\[\])](#mdadmonitionstring-mdblock)                                      | Initializes a new instance of [MdAdmonition](../index.md).                                                           |
| [MdAdmonition(string, MdContainerBlockBase)](#mdadmonitionstring-mdcontainerblockbase)                | Initializes a new instance of [MdAdmonition](../index.md) with the specified type and content.                       |
| [MdAdmonition(string, MdList)](#mdadmonitionstring-mdlist)                                            | Initializes a new instance of [MdAdmonition](../index.md).                                                           |
| [MdAdmonition(string, MdSpan)](#mdadmonitionstring-mdspan)                                            | Initializes a new instance of [MdAdmonition](../index.md) with the specified type and title but without any content. |
| [MdAdmonition(string, MdSpan, IEnumerable\<MdBlock\>)](#mdadmonitionstring-mdspan-ienumerablemdblock) | Initializes a new instance of [MdAdmonition](../index.md).                                                           |
| [MdAdmonition(string, MdSpan, MdBlock\[\])](#mdadmonitionstring-mdspan-mdblock)                       | Initializes a new instance of [MdAdmonition](../index.md).                                                           |
| [MdAdmonition(string, MdSpan, MdContainerBlockBase)](#mdadmonitionstring-mdspan-mdcontainerblockbase) | Initializes a new instance of [MdAdmonition](../index.md).                                                           |
| [MdAdmonition(string, MdSpan, MdList)](#mdadmonitionstring-mdspan-mdlist)                             | Initializes a new instance of [MdAdmonition](../index.md).                                                           |

## MdAdmonition(string)

Initializes a new instance of [MdAdmonition](../index.md) without content.

```csharp
public MdAdmonition(string type);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

## MdAdmonition(string, IEnumerable\<MdBlock\>)

Initializes a new instance of [MdAdmonition](../index.md).

```csharp
public MdAdmonition(string type, IEnumerable<MdBlock> content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`content`  IEnumerable\<[MdBlock](../../../MdBlock/index.md)\>

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

## MdAdmonition(string, MdBlock\[\])

Initializes a new instance of [MdAdmonition](../index.md).

```csharp
public MdAdmonition(string type, MdBlock[] content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`content`  [MdBlock](../../../MdBlock/index.md)\[\]

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

## MdAdmonition(string, MdContainerBlockBase)

Initializes a new instance of [MdAdmonition](../index.md) with the specified type and content.

```csharp
public MdAdmonition(string type, MdContainerBlockBase content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`content`  [MdContainerBlockBase](../../../MdContainerBlockBase/index.md)

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

## MdAdmonition(string, MdList)

Initializes a new instance of [MdAdmonition](../index.md).

```csharp
public MdAdmonition(string type, MdList content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`content`  [MdList](../../../MdList/index.md)

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

## MdAdmonition(string, MdSpan)

Initializes a new instance of [MdAdmonition](../index.md) with the specified type and title but without any content.

```csharp
public MdAdmonition(string type, MdSpan title);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`title`  [MdSpan](../../../MdSpan/index.md)

The admonition's title. To create a admonition without title, use a different constructor overload.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

ArgumentNullException

Thrown when `title` is `null`.

## MdAdmonition(string, MdSpan, IEnumerable\<MdBlock\>)

Initializes a new instance of [MdAdmonition](../index.md).

```csharp
public MdAdmonition(string type, MdSpan title, IEnumerable<MdBlock> content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`title`  [MdSpan](../../../MdSpan/index.md)

The admonition's title. To create a admonition without title, use a different constructor overload.

`content`  IEnumerable\<[MdBlock](../../../MdBlock/index.md)\>

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

ArgumentNullException

Thrown when `title` is `null`.

## MdAdmonition(string, MdSpan, MdBlock\[\])

Initializes a new instance of [MdAdmonition](../index.md).

```csharp
public MdAdmonition(string type, MdSpan title, MdBlock[] content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`title`  [MdSpan](../../../MdSpan/index.md)

The admonition's title. To create a admonition without title, use a different constructor overload.

`content`  [MdBlock](../../../MdBlock/index.md)\[\]

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

ArgumentNullException

Thrown when `title` is `null`.

## MdAdmonition(string, MdSpan, MdContainerBlockBase)

Initializes a new instance of [MdAdmonition](../index.md).

```csharp
public MdAdmonition(string type, MdSpan title, MdContainerBlockBase content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`title`  [MdSpan](../../../MdSpan/index.md)

The admonition's title. To create a admonition without title, use a different constructor overload.

`content`  [MdContainerBlockBase](../../../MdContainerBlockBase/index.md)

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

ArgumentNullException

Thrown when `title` is `null`.

## MdAdmonition(string, MdSpan, MdList)

Initializes a new instance of [MdAdmonition](../index.md).

```csharp
public MdAdmonition(string type, MdSpan title, MdList content);
```

### Parameters

`type`  string

The admonition's type. Any non\-empty string is allowed. Recommended values are `attention`, `caution`, `danger`, `error`,`hint`, `important`, `note`, `tip` and `warning`

`title`  [MdSpan](../../../MdSpan/index.md)

The admonition's title. To create a admonition without title, use a different constructor overload.

`content`  [MdList](../../../MdList/index.md)

The admonition's content.

### Exceptions

ArgumentException

Thrown when `type` is null or whitespace.

ArgumentNullException

Thrown when `title` is `null`.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
