using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a bullet list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items
    /// </summary>
    public sealed class MdBulletList : MdList
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public MdBulletList(params MdListItem[] listItems) : base(listItems)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="listItems">The list items to initially add to the list</param>
        public MdBulletList(IEnumerable<MdListItem> listItems) : base(listItems)
        { }


        public override bool DeepEquals(MdBlock other) => other is MdBulletList list ? DeepEquals(list) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
