using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    //TODO: seal class
    /// <summary>
    /// A block that can contains other blocks
    /// </summary>
    public abstract class MdContainerBlockBase : MdBlock, IEnumerable<MdBlock>
    {
        readonly LinkedList<MdBlock> m_Blocks;

        /// <summary>
        /// The container's sub-blocks
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


        public void Add(MdBlock block)
        {            
            m_Blocks.AddLast(block);
        }

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
