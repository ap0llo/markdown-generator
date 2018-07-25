using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a list or inline-elements
    /// </summary>
    public sealed class MdCompositeSpan : MdSpan, IEnumerable<MdSpan>
    {
        private readonly List<MdSpan> m_Spans;


        public IReadOnlyList<MdSpan> Spans => m_Spans;

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

            m_Spans = new List<MdSpan>(spans);
        }


        /// <summary>
        /// Adds a new element to the composite span
        /// </summary>
        public void Add(MdSpan span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            m_Spans.Add(span);
        }

        public override MdSpan Copy() => new MdCompositeSpan(m_Spans.Select(x => x.Copy()));

        public IEnumerator<MdSpan> GetEnumerator() => m_Spans.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Spans.GetEnumerator();

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach(var span in Spans)
            {
                stringBuilder.Append(span.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
