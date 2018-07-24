using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a list or inline-elements
    /// </summary>
    public sealed class MdCompositeSpan : MdSpan, IEnumerable<MdSpan>
    {
        private readonly LinkedList<MdSpan> m_Spans;


        public IEnumerable<MdSpan> Spans { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MdCompositeSpan"/> with the specified inline-elements.
        /// </summary>
        public MdCompositeSpan(params MdSpan[] spans) : this((IEnumerable<MdSpan>) spans)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdCompositeSpan"/> with the specified inline-elements.
        /// </summary>
        public MdCompositeSpan(IEnumerable<MdSpan> spans)
        {
            if (spans == null)
                throw new ArgumentNullException(nameof(spans));

            m_Spans = new LinkedList<MdSpan>(spans);
        }


        /// <summary>
        /// Adds a new element to the composite span
        /// </summary>
        public void Add(MdSpan span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            m_Spans.AddLast(span);
        }


        public IEnumerator<MdSpan> GetEnumerator() => m_Spans.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Spans.GetEnumerator();        
    }
}
