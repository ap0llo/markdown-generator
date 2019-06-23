using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a block that can contains other blocks.
    /// For specification see https://spec.commonmark.org/0.28/#container-blocks.
    /// </summary>
    public sealed class MdContainerBlock : MdContainerBlockBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdContainerBlock"/> without content.
        /// </summary>
        public MdContainerBlock() : base()
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdContainerBlock"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// The content to add to the block.
        /// For documentation on how content is added, see <see cref="MdContainerBlockBase.Add(object)"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> or one of the elements of <paramref name="content"/> is <c>null</c>.</exception>
        public MdContainerBlock(object content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdContainerBlock"/> with the specified content.
        /// </summary>
        /// <param name="content">
        /// The content to add to the block.
        /// For documentation on how content is added, see <see cref="MdContainerBlockBase.Add(object)"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> or one of the elements of <paramref name="content"/> is <c>null</c>.</exception>
        public MdContainerBlock(params object[] content) : base(content)
        { }


        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => other is MdContainerBlock containerBlock ? DeepEquals(containerBlock) : false;


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
