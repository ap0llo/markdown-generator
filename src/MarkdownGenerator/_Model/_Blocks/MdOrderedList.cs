using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a ordered list.
    /// For specification see <see href="https://spec.commonmark.org/0.28/#list-items">CommonMark - List items</see>.
    /// </summary>
    /// <seealso cref="MdOrderedListStyle"/>
    public sealed class MdOrderedList : MdList
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public MdOrderedList(params MdListItem[] listItems) : base(listItems)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public MdOrderedList(IEnumerable<MdListItem> listItems) : base(listItems)
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock? other) => other is MdOrderedList list ? DeepEquals(list) : false;


        /// <inheritdoc />
        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
