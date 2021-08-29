﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Base class for ordered and bullet lists.
    /// Implementations are <see cref="MdBulletList"/> respectively <see cref="MdOrderedList"/>.
    /// </summary>
    /// <seealso cref="MdBulletList"/>
    /// <seealso cref="MdOrderedList"/>
    public abstract class MdList : MdBlock, IReadOnlyCollection<MdListItemBase>
    {
        private readonly List<MdListItemBase> m_ListItems;


        /// <summary>
        /// Gets the list's items
        /// </summary>
        public IEnumerable<MdListItemBase> Items => m_ListItems;

        /// <summary>
        /// Gets the number of list items in the list.
        /// </summary>
        /// <value>The number of list items in the list.</value>
        public int Count => m_ListItems.Count;

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdList(params MdListItemBase[] content) : this((IEnumerable<MdListItemBase>)content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdList(IEnumerable<MdListItemBase> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            m_ListItems = new List<MdListItemBase>(content);
        }


        /// <summary>
        /// Adds the specified item to the list
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is <c>null</c>.</exception>
        public void Add(MdListItemBase item)
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
        public void Insert(int index, MdListItemBase item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (index < 0 || index > m_ListItems.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            m_ListItems.Insert(index, item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list's item.
        /// </summary>
        public IEnumerator<MdListItemBase> GetEnumerator() => m_ListItems.GetEnumerator();

        /// <summary>
        /// Returns an (non-generic) enumerator that iterates through the list's item.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => m_ListItems.GetEnumerator();


        protected bool DeepEquals(MdList? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (m_ListItems.Count != other.m_ListItems.Count)
                return false;

            for (var i = 0; i < m_ListItems.Count; i++)
            {
                if (!m_ListItems[i].DeepEquals(other.m_ListItems[i]))
                    return false;
            }

            return true;
        }
    }
}
