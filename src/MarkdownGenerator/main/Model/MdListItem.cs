using System;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    public class MdListItem : MdContainerBlock
    {
        public MdListItem(params MdBlock[] items) : base(items)
        {
        }

        public MdListItem(IEnumerable<MdBlock> items) : base(items)
        {
        }
    }
}
