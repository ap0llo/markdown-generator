using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a ordered list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items
    /// </summary>
    public sealed class MdOrderedList : MdList
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to intially add to the list</param>
        public MdOrderedList(params MdListItem[] listItems) : base(listItems)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdOrderedList"/> with the specified list items.
        /// </summary>
        /// <param name="listItems">The list items to intially add to the list</param>
        public MdOrderedList(IEnumerable<MdListItem> listItems) : base(listItems)
        { }
    }
}
