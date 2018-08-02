using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{    
    /// <summary>
    /// Base class for blocks that can contains other blocks.
    /// </summary>
    public abstract class MdContainerBlockBase : MdBlock, IEnumerable<MdBlock>
    {
        private readonly LinkedList<MdBlock> m_Blocks;


        /// <summary>
        /// Gets the container's inner blocks
        /// </summary>
        public IEnumerable<MdBlock> Blocks => m_Blocks;


        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase(params MdBlock[] content) : this((IEnumerable<MdBlock>) content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase(IEnumerable<MdBlock> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            m_Blocks = new LinkedList<MdBlock>(content);            
        }

        /// <summary>
        /// Adds the specified block to the container block
        /// </summary>
        /// <param name="block">The block to add to the container</param>
        public void Add(MdBlock block)
        {            
            m_Blocks.AddLast(block);
        }

        /// <summary>
        /// Adds the specified blocks to the container blcoks
        /// </summary>
        /// <param name="blocks">The blocks to add to the container</param>
        public void Add(params MdBlock[] blocks)
        {
            for (var i = 0; i < blocks.Length; i++)
            {
                m_Blocks.AddLast(blocks[i]);
            }
        }

        public IEnumerator<MdBlock> GetEnumerator() => m_Blocks.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Blocks.GetEnumerator();
    }
}
