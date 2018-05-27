﻿namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Base class for all types of leaf blocks (blocks that cannot contain other blocks)
    /// </summary>
    public abstract class MdLeafBlock : MdBlock
    {
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdLeafBlock()
        {
        }
    }
}
