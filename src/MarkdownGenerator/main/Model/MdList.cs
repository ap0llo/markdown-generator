using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    public class MdList : MdBlock, IEnumerable<MdListItem>
    {
        readonly LinkedList<MdListItem> m_ListItems;


        public IEnumerable<MdListItem> Items => m_ListItems;


        public MdList(params MdListItem[] content) : this((IEnumerable<MdListItem>) content)
        {        
        }

        public MdList(IEnumerable<MdListItem> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            m_ListItems = new LinkedList<MdListItem>(content);
        }


        public void Add(MdListItem block)
        {            
            m_ListItems.AddLast(block);
        }

        public IEnumerator<MdListItem> GetEnumerator() => m_ListItems.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_ListItems.GetEnumerator();
    }
}
