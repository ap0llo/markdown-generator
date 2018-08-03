using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Base class for ordered and bullet lists.
    /// Implementations are <see cref="MdBulletList"/> respectively <see cref="MdOrderedList"/>.
    /// </summary>
    public abstract class MdList : MdBlock, IEnumerable<MdListItem>
    {
        private readonly LinkedList<MdListItem> m_ListItems;


        /// <summary>
        /// Gets the list's items
        /// </summary>
        public IEnumerable<MdListItem> Items => m_ListItems;


        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdList(params MdListItem[] content) : this((IEnumerable<MdListItem>) content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdList(IEnumerable<MdListItem> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            m_ListItems = new LinkedList<MdListItem>(content);
        }


        /// <summary>
        /// Adds the specified item to the list
        /// </summary>
        public void Add(MdListItem item)
        {            
            m_ListItems.AddLast(item);
        }

        public IEnumerator<MdListItem> GetEnumerator() => m_ListItems.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_ListItems.GetEnumerator();
    }
}
