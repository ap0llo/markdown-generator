using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Base class for ordered and bullet lists.
    /// Implementations are <see cref="MdBulletList"/> respectively <see cref="MdOrderedList"/>.
    /// </summary>
    public abstract class MdList : MdBlock
    {
        private readonly List<MdListItem> m_ListItems;


        /// <summary>
        /// Gets the list's items.
        /// </summary>
        public IReadOnlyList<MdListItem> Items => m_ListItems;


        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdList(params MdListItem[] content) : this((IEnumerable<MdListItem>) content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdList(IEnumerable<MdListItem> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (content.Any(x => x == null))
                throw new ArgumentNullException(nameof(content), "Enumerable must not contain elements that are null.");

            m_ListItems = new List<MdListItem>(content);
        }


        /// <summary>
        /// Adds the specified item to the list.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is <c>null</c>.</exception>
        public void Add(MdListItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            m_ListItems.Add(item);
        }

        /// <summary>
        /// Inserts the specified item into the list at the specified index.
        /// </summary>
        /// <param name="index">The index (zero-based) to insert the item at.</param>
        /// <param name="item">The item to insert.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is negative or greater than the number of items in the list.</exception>
        public void Insert(int index, MdListItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (index < 0 || index > m_ListItems.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            m_ListItems.Insert(index, item);
        }


        protected bool DeepEquals(MdList other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (m_ListItems.Count != other.m_ListItems.Count)
                return false;

            for(var i = 0; i< m_ListItems.Count; i++)
            {
                if (!m_ListItems[i].DeepEquals(other.m_ListItems[i]))
                    return false;
            }

            return true;
        }
    }
}
