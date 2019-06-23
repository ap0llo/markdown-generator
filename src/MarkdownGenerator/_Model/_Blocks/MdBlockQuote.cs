using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a block quote.
    /// For specification see https://spec.commonmark.org/0.28/#block-quotes.
    /// </summary>
    public sealed class MdBlockQuote : MdContainerBlockBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> without any content.
        /// </summary>
        public MdBlockQuote() : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// The content to add to the block.
        /// For documentation on how content is added, see <see cref="MdContainerBlockBase.Add(object)"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> is <c>null</c>.</exception>
        public MdBlockQuote(object content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// The content to add to the block.
        /// For documentation on how content is added, see <see cref="MdContainerBlockBase.Add(object)"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> or one of the elements of <paramref name="content"/> is <c>null</c>.</exception>
        public MdBlockQuote(params object[] content) : base(content)
        { }

        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => other is MdBlockQuote blockQuote ? base.DeepEquals(blockQuote) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
