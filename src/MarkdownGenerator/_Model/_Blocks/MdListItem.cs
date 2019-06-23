using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a item in an bullet or ordered list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items
    /// </summary>
    public sealed class MdListItem : MdContainerBlockBase
    {
        /// <summary>
        /// Initializes a new, empty instance of <see cref="MdListItem"/>.
        /// </summary>
        public MdListItem() : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified content.
        /// </summary>
        /// <param name="content">The block to initially add to the list item.</param>
        public MdListItem(object content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified content.
        /// </summary>
        /// <param name="content">The list to initially add to the list item.</param>
        public MdListItem(params object[] content) : base(content)
        { }


        public override bool DeepEquals(MdBlock other) => other is MdListItem listItem ? DeepEquals(listItem) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
