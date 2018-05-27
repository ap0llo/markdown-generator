﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents an (unordered) list
    /// </summary>
    public sealed class MdList : MdBlock, IEnumerable<MdListItem>
    {
        readonly LinkedList<MdListItem> m_ListItems;

        /// <summary>
        /// The lit's items
        /// </summary>
        public IEnumerable<MdListItem> Items => m_ListItems;


        public MdList(params MdListItem[] content) : this((IEnumerable<MdListItem>) content)
        { }

        public MdList(IEnumerable<MdListItem> content)
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
