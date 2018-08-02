using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a block that can contains other blocks.
    /// For specification see https://spec.commonmark.org/0.28/#container-blocks
    /// </summary>
    public sealed class MdContainerBlock : MdContainerBlockBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MdContainerBlock"/> with the specified content.
        /// </summary>
        /// <param name="content">The blocks the container blocks contains</param>
        public MdContainerBlock(params MdBlock[] content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdContainerBlock"/> with the specified content.
        /// </summary>
        /// <param name="content">The blocks the container blocks contains</param>
        public MdContainerBlock(IEnumerable<MdBlock> content) : base(content)
        { }
    }
}
