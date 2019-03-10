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
        private readonly List<MdListItem> m_ListItems;


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

            m_ListItems = new List<MdListItem>(content);
        }


        /// <summary>
        /// Adds the specified item to the list
        /// </summary>
        public void Add(MdListItem item)
        {
            m_ListItems.Add(item);
        }

        public IEnumerator<MdListItem> GetEnumerator() => m_ListItems.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_ListItems.GetEnumerator();


        protected bool DeepEquals(MdList other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (m_ListItems.Count != other.m_ListItems.Count)
                return false;

            for(int i = 0; i< m_ListItems.Count; i++)
            {
                if (!m_ListItems[i].DeepEquals(other.m_ListItems[i]))
                    return false;
            }

            return true;
        }
    }
}
