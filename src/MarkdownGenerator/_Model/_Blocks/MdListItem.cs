using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a item in an bullet or ordered list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items.
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
        /// <param name="content">
        /// The content to add to the block.
        /// For documentation on how content is added, see <see cref="MdContainerBlockBase.Add(object)"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> is <c>null</c>.</exception>
        public MdListItem(object content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdListItem"/> containing the specified content.
        /// </summary>
        /// <param name="content">
        /// The content to add to the block.
        /// For documentation on how content is added, see <see cref="MdContainerBlockBase.Add(object)"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> or one of the elements of <paramref name="content"/> is <c>null</c>.</exception>
        public MdListItem(params object[] content) : base(content)
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => other is MdListItem listItem ? DeepEquals(listItem) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
