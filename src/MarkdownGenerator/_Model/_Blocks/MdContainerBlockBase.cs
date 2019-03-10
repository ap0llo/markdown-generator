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
        private readonly List<MdBlock> m_Blocks;


        /// <summary>
        /// Gets the container's inner blocks
        /// </summary>
        public IEnumerable<MdBlock> Blocks => m_Blocks;


        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase() : this(Array.Empty<MdBlock>())
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase(MdContainerBlockBase content) : this((MdBlock)content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase(params MdBlock[] content) : this((IEnumerable<MdBlock>) content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase(IEnumerable<MdBlock> content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            m_Blocks = new List<MdBlock>(content);
        }

        /// <summary>
        /// Adds the specified block to the container block
        /// </summary>
        /// <param name="block">The block to add to the container</param>
        public void Add(MdBlock block)
        {
            m_Blocks.Add(block);
        }

        /// <summary>
        /// Adds the specified blocks to the container blocks
        /// </summary>
        /// <param name="blocks">The blocks to add to the container</param>
        public void Add(params MdBlock[] blocks)
        {
            for (var i = 0; i < blocks.Length; i++)
            {
                m_Blocks.Add(blocks[i]);
            }
        }

        public IEnumerator<MdBlock> GetEnumerator() => m_Blocks.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Blocks.GetEnumerator();


        protected bool DeepEquals(MdContainerBlockBase other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (m_Blocks.Count != other.m_Blocks.Count)
                return false;

            for (int i = 0; i < m_Blocks.Count; i++)
            {
                if (!m_Blocks[i].DeepEquals(other.m_Blocks[i]))
                    return false;
            }

            return true;
        }
    }
}
