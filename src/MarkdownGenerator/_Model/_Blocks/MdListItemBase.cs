using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Base class for all list item types
    /// </summary>
    public abstract class MdListItemBase : MdContainerBlockBase
    {
        /// <inheritdoc />
        protected internal MdListItemBase() : base()
        { }

        /// <inheritdoc />
        protected internal MdListItemBase(MdContainerBlockBase content) : base(content)
        { }

        protected internal MdListItemBase(MdList list) : base(list)
        { }

        protected internal MdListItemBase(params MdBlock[] content) : base(content)
        { }

        protected internal MdListItemBase(IEnumerable<MdBlock> content) : base(content)
        { }

    }
}
