using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Base class for blocks that can contains other blocks.
    /// </summary>
    public abstract class MdContainerBlockBase : MdBlock, IReadOnlyCollection<MdBlock>
    {
        private readonly List<MdBlock> m_Blocks = new List<MdBlock>();


        /// <summary>
        /// Gets the container's inner blocks
        /// </summary>
        public IReadOnlyList<MdBlock> Blocks => m_Blocks;

        /// <summary>
        /// Gets the number of blocks in the container.
        /// </summary>
        /// <value>The number of blocks in the container.</value>
        public int Count => m_Blocks.Count;

        // private protected constructor => class cannot be derived from outside this assembly
        internal MdContainerBlockBase()
        { }

        // private protected constructor => class cannot be derived from outside this assembly
        internal MdContainerBlockBase(object content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            AddContent(content);
        }

        internal MdContainerBlockBase(params object[] content) : this((object) content)
        { }

        /// <summary>
        /// Adds the specified content to the container block.
        /// </summary>
        /// <param name="content">The content to add to the container</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> is <c>null</c>.</exception>
        public void Add(object content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            AddContent(content);
        }

        /// <summary>
        /// Adds the specified content to the container block.
        /// </summary>
        /// <param name="content">The content to add to the container.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="content"/> is <c>null</c>.</exception>
        public void Add(params object[] content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            AddContent(content);
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

            for (var i = 0; i < m_Blocks.Count; i++)
            {
                if (!m_Blocks[i].DeepEquals(other.m_Blocks[i]))
                    return false;
            }

            return true;
        }


        private void AddContent(object content)
        {
            if(content == null)
            {
                throw new ArgumentNullException(nameof(content), "Cannot add null content to container block");
            }
            else if(content is MdBlock blockContent)
            {
                m_Blocks.Add(blockContent);
            }
            // wrap spans and strings into a paragraph
            else if(content is MdSpan spanContent)
            {
                if(m_Blocks.Count > 0 && m_Blocks[m_Blocks.Count -1] is MdParagraph paragraph)
                {
                    paragraph.Add(spanContent);
                }
                else
                {
                    m_Blocks.Add(new MdParagraph(spanContent));
                }
            }
            else if(content is string stringContent)
            {
                AddContent(new MdTextSpan(stringContent));
            }
            else if (TryGetSimpleContentString(content, out var simpleContent))
            {
                AddContent(new MdTextSpan(simpleContent));
            }
            else if (content is IEnumerable enumerableContent)
            {
                foreach(var item in enumerableContent)
                {
                    AddContent(item);
                }
            }
            else
            {
                throw new ArgumentException($"Cannot add object of type '{content?.GetType()?.FullName}' to the container block.");
            }
        }


        private bool TryGetSimpleContentString(object content, out string stringContent)
        {
            if(content is bool ||
               content is byte ||
               content is sbyte ||
               content is char ||
               content is double ||
               content is float ||
               content is int ||
               content is uint ||
               content is long ||
               content is ulong ||
               content is short ||
               content is ushort)
            {
                stringContent = content.ToString();
                return true;
            }

            stringContent = default;
            return false;
        }

    }
}
