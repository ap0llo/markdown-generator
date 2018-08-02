using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// A block that can contains other blocks
    /// </summary>
    public sealed class MdContainerBlock : MdContainerBlockBase
    {
        public MdContainerBlock(params MdBlock[] content) : base(content)
        { }

        public MdContainerBlock(IEnumerable<MdBlock> content) :base(content)
        { }
    }
}
