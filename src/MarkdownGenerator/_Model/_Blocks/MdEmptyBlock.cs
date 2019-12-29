using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents an empty block.
    /// </summary>
    /// <remarks>
    /// Represents an empty block.
    /// Empty blocks have no effect on the output as they are serialized to <see cref="String.Empty"/>
    /// </remarks>
    public sealed class MdEmptyBlock : MdBlock
    {
        /// <summary>
        /// Gets the default instance of <see cref="MdEmptyBlock"/>
        /// </summary>
        public static readonly MdEmptyBlock Instance = new MdEmptyBlock();


        private MdEmptyBlock()
        { }


        public override string ToString() => "";

        public override string ToString(MdSerializationOptions? options) => "";

        /// <inheritdoc />
        public override bool DeepEquals(MdBlock? other) => ReferenceEquals(this, other);


        /// <inheritdoc />
        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
