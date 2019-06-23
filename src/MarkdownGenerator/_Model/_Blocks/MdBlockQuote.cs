using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represent a block quote in a markdown document.
    /// For specification see https://spec.commonmark.org/0.28/#block-quotes
    /// </summary>
    public sealed class MdBlockQuote : MdContainerBlockBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/>.
        /// </summary>
        public MdBlockQuote() : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content.
        /// </summary>
        /// <param name="content">The block to initially add to the block quote.</param>
        public MdBlockQuote(object content) : base(content)
        { }
                
        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">The content of the quote as one or more blocks (see <see cref="MdBlock"/>)</param>
        public MdBlockQuote(params object[] content) : base(content)
        { }
        
        public override bool DeepEquals(MdBlock other) => other is MdBlockQuote blockQuote ? base.DeepEquals(blockQuote) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
