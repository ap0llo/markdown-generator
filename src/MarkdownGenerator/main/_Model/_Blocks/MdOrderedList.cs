using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    public sealed class MdOrderedList : MdList
    {
        internal override MdListKind Kind => MdListKind.Ordered;


        public MdOrderedList(params MdListItem[] content) : base(content)
        { }

        public MdOrderedList(IEnumerable<MdListItem> content) : base(content)
        { }
    }
}
