using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    public class MdContainerBlock : MdBlock, IEnumerable<MdBlock>
    {
        readonly LinkedList<MdBlock> m_Blocks;


        public IEnumerable<MdBlock> Blocks => m_Blocks;


        public MdContainerBlock(params MdBlock[] content) : this((IEnumerable<MdBlock>) content)
        {            
        }

        public MdContainerBlock(IEnumerable<MdBlock> content)
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
