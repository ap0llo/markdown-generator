using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator.Extensions
{
    // TODO: Documentation comments
    class MdTaskList : MdList<MdTaskListItem>
    {
        // TODO: Documentation comments
        public MdTaskList(params MdTaskListItem[] listItems) : base(listItems)
        { }

        // TODO: Documentation comments
        public MdTaskList(IEnumerable<MdTaskListItem> listItems) : base(listItems)
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock? other) => other is MdTaskList list ? DeepEquals(list) : false;


        /// <inheritdoc />
        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);


        //TODO: prevent list items other than MdTaskListItem from being added
    }
}
