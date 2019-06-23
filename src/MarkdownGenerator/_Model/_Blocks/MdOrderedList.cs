using System;
using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a ordered list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items.
    /// </summary>
    public sealed class MdOrderedList : MdList
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="listItems"/> is <c>null</c> or contains a <c>null</c> element.</exception>
        public MdOrderedList(params MdListItem[] listItems) : base(listItems)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="listItems"/> is <c>null</c> or contains a <c>null</c> element.</exception>
        public MdOrderedList(IEnumerable<MdListItem> listItems) : base(listItems)
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => other is MdOrderedList list ? DeepEquals(list) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
