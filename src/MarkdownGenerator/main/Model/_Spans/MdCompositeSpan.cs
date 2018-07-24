using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdCompositeSpan : MdSpan, IEnumerable<MdSpan>
    {
        private readonly LinkedList<MdSpan> m_Spans;


        public IEnumerable<MdSpan> Spans { get; }


        public MdCompositeSpan(params MdSpan[] spans) : this((IEnumerable<MdSpan>) spans)
        { }

        public MdCompositeSpan(IEnumerable<MdSpan> spans)
        {
            if (spans == null)
                throw new ArgumentNullException(nameof(spans));

            m_Spans = new LinkedList<MdSpan>(spans);
        }


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
