﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# MdTableRow Class

**Namespace:** [Grynwald.MarkdownGenerator](../index.md)  
**Assembly:** Grynwald.MarkdownGenerator

Represent a row in a table (see [MdTable](../MdTable/index.md))

```csharp
public sealed class MdTableRow : IReadOnlyList<MdSpan>, IEnumerable<MdSpan>, IEnumerable, IReadOnlyCollection<MdSpan>
```

**Inheritance:** object → MdTableRow

**Implements:** IReadOnlyList\<[MdSpan](../MdSpan/index.md)\>,IEnumerable\<[MdSpan](../MdSpan/index.md)\>,IEnumerable,IReadOnlyCollection\<[MdSpan](../MdSpan/index.md)\>

## Constructors

| Name                                                                                   | Description                                                                 |
| -------------------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| [MdTableRow(IEnumerable\<MdSpan\>)](constructors/index.md#mdtablerowienumerablemdspan) | Initializes a new instance of MdTableRow with the specified cells\/columns. |
| [MdTableRow(IEnumerable\<string\>)](constructors/index.md#mdtablerowienumerablestring) | Initializes a new instance of MdTableRow with the specified cells\/columns. |
| [MdTableRow(MdCompositeSpan)](constructors/index.md#mdtablerowmdcompositespan)         | Initializes a new instance of MdTableRow with the specified cell.           |
| [MdTableRow(MdSpan\[\])](constructors/index.md#mdtablerowmdspan)                       | Initializes a new instance of MdTableRow with the specified cells\/columns. |

## Properties

| Name                                     | Description                            |
| ---------------------------------------- | -------------------------------------- |
| [Cells](properties/Cells.md)             | Gets the row's cells                   |
| [ColumnCount](properties/ColumnCount.md) | Gets the number of columns in the row  |
| [Count](properties/Count.md)             | Gets the number of columns in the row. |

## Indexers

| Name                            | Description                            |
| ------------------------------- | -------------------------------------- |
| [Item\[int\]](indexers/Item.md) | Gets the value in the specified column |

## Methods

| Name                                            | Description                                                        |
| ----------------------------------------------- | ------------------------------------------------------------------ |
| [Add(MdSpan)](methods/Add.md#addmdspan)         | Adds a column to the row                                           |
| [Add(string)](methods/Add.md#addstring)         | Adds a column to the row                                           |
| [DeepEquals(MdTableRow)](methods/DeepEquals.md) |                                                                    |
| [GetEnumerator()](methods/GetEnumerator.md)     | Returns an enumerator that iterates through the table row's cells. |
| [Insert(int, MdSpan)](methods/Insert.md)        | Inserts a table cell at the specified index.                       |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
