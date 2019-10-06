# MdContainerBlockBase Class

**Namespace:** [Grynwald.MarkdownGenerator](../index.md)

**Assembly:** Grynwald.MarkdownGenerator

Base class for blocks that can contains other blocks.

```csharp
public abstract class MdContainerBlockBase : MdBlock, IReadOnlyCollection<MdBlock>, IEnumerable<MdBlock>, IEnumerable
```

**Inheritance:** object → [MdBlock](../MdBlock/index.md) → MdContainerBlockBase

**Implements:** IReadOnlyCollection\<[MdBlock](../MdBlock/index.md)\>,IEnumerable\<[MdBlock](../MdBlock/index.md)\>,IEnumerable

## Properties

| Name                           | Description                                 |
| ------------------------------ | ------------------------------------------- |
| [Blocks](properties/Blocks.md) | Gets the container's inner blocks           |
| [Count](properties/Count.md)   | Gets the number of blocks in the container. |

## Methods

| Name                                          | Description                                                                    |
| --------------------------------------------- | ------------------------------------------------------------------------------ |
| [Add(MdBlock)](methods/Add.md#addmdblock)     | Adds the specified block to the container block                                |
| [Add(MdBlock\[\])](methods/Add.md#addmdblock) | Adds the specified blocks to the container blocks                              |
| [GetEnumerator()](methods/GetEnumerator.md)   | Returns an enumerator that iterates through the container block's child blocks |
| [Insert(int, MdBlock)](methods/Insert.md)     | Inserts an block into the container at the specified index.                    |

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*