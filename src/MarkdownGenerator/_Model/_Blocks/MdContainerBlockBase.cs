using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Base class for blocks that can contains other blocks.
    /// </summary>
    public abstract class MdContainerBlockBase : MdBlock, IReadOnlyCollection<MdBlock>
    {
        private readonly List<MdBlock> m_Blocks;


        /// <summary>
        /// Gets the container's inner blocks
        /// </summary>
        public IEnumerable<MdBlock> Blocks => m_Blocks;

        /// <summary>
        /// Gets the number of blocks in the container.
        /// </summary>
        /// <value>The number of blocks in the container.</value>
        public int Count => m_Blocks.Count;

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase() : this(Array.Empty<MdBlock>())
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase(MdContainerBlockBase content) : this((MdBlock)content)
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdContainerBlockBase(MdList content) : this((MdBlock)content)
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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="block"/> is <c>null</c>.</exception>
        public void Add(MdBlock block)
        {
            if (block == null)
                throw new ArgumentNullException(nameof(block));

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

        /// <summary>
        /// Inserts an block into the container at the specified index.
        /// </summary>
        /// <param name="index">The index (zero-based) to insert the block at.</param>
        /// <param name="block">The block to insert into the container.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="block"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is negative or greater than the number of blocks in the container.</exception>
        public void Insert(int index, MdBlock block)
        {
            if (block == null)
                throw new ArgumentNullException(nameof(block));

            if (index < 0 || index > m_Blocks.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            m_Blocks.Insert(index, block);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the container block's child blocks
        /// </summary>
        public IEnumerator<MdBlock> GetEnumerator() => m_Blocks.GetEnumerator();

        /// <summary>
        /// Returns an (non-generic) enumerator that iterates through the container block's child blocks
        /// </summary>
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
