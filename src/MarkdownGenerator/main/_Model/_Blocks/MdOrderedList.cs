using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a ordered list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items
    /// </summary>
    public sealed class MdOrderedList : MdList
    {
        internal override MdListKind Kind => MdListKind.Ordered;

        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list item
        /// </summary>
        /// <param name="content">The list items to intially add to the list</param>
        public MdOrderedList(params MdListItem[] content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list item
        /// </summary>
        /// <param name="content">The list items to intially add to the list</param>
        public MdOrderedList(IEnumerable<MdListItem> content) : base(content)
        { }
    }
}
