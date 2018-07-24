using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdCompositeTextSpan : MdTextSpan, IEnumerable<MdTextSpan>
    {
        private readonly LinkedList<MdTextSpan> m_Spans;


        public IEnumerable<MdTextSpan> Spans { get; }


        public MdCompositeTextSpan(params MdTextSpan[] spans) : this((IEnumerable<MdTextSpan>) spans)
        { }

        public MdCompositeTextSpan(IEnumerable<MdTextSpan> spans)
        {
            if (spans == null)
                throw new ArgumentNullException(nameof(spans));

            m_Spans = new LinkedList<MdTextSpan>(spans);
        }


        public void Add(MdTextSpan span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            m_Spans.AddLast(span);
        }


        public IEnumerator<MdTextSpan> GetEnumerator() => m_Spans.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Spans.GetEnumerator();        
    }
}
