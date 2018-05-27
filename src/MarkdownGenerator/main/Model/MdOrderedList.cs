using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdOrderedList : MdList
    {
        public MdOrderedList(params MdListItem[] content) : base(content)
        {
        }

        public MdOrderedList(IEnumerable<MdListItem> content) : base(content)
        {
        }
    }
}
