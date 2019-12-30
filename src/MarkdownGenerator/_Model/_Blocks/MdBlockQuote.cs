using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represent a block quote in a markdown document.
    /// For specification see <see href="https://spec.commonmark.org/0.28/#block-quotes">CommonMark - Block quotes</see>.
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
        public MdBlockQuote(MdContainerBlockBase content) : base(content)
        { }
        
        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content.
        /// </summary>
        /// <param name="content">The block to initially add to the block quote.</param>
        public MdBlockQuote(MdList content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">The content of the quote as one or more blocks (see <see cref="MdBlock"/>)</param>
        public MdBlockQuote(params MdBlock[] content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">The content of the quote as one or more blocks (see <see cref="MdBlock"/>)</param>
        public MdBlockQuote(IEnumerable<MdBlock> content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">
        /// The content of the quote as a span (see <see cref="MdSpan"/>.
        /// The span will automatically be wrapped in an instance of <see cref="MdParagraph"/>
        /// </param>
        public MdBlockQuote(MdSpan content) : this(new MdParagraph(content))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBlockQuote"/> with the specified content
        /// </summary>
        /// <param name="content">
        /// The content of the quote as one or more spans (see <see cref="MdSpan"/>.
        /// The spans will automatically be wrapped in an instance of <see cref="MdParagraph"/>
        /// </param>
        public MdBlockQuote(params MdSpan[] content) : this(new MdParagraph(content))
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock? other) => other is MdBlockQuote blockQuote ? base.DeepEquals(blockQuote) : false;


        /// <inheritdoc />
        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
