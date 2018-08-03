using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a list or inline-elements
    /// </summary>
    public sealed class MdCompositeSpan : MdSpan, IEnumerable<MdSpan>
    {
        private readonly List<MdSpan> m_Spans;

        /// <summary>
        /// Gets the composite spans inner spans
        /// </summary>
        public IReadOnlyList<MdSpan> Spans => m_Spans;


        /// <summary>
        /// Initializes a new instance of <see cref="MdCompositeSpan"/> with the specified inline-elements.
        /// </summary>
        /// <param name="spans">The spans to add to the composite span.</param>
        public MdCompositeSpan(params MdSpan[] spans) : this((IEnumerable<MdSpan>) spans)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdCompositeSpan"/> with the specified inline-elements.
        /// </summary>
        /// <param name="spans">The spans to add to the composite span.</param>
        public MdCompositeSpan(IEnumerable<MdSpan> spans)
        {
            if (spans == null)
                throw new ArgumentNullException(nameof(spans));

            m_Spans = new List<MdSpan>(spans);
        }


        /// <summary>
        /// Adds a new element to the composite span.
        /// </summary>
        /// <param name="span">The span to add</param>
        public void Add(MdSpan span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            m_Spans.Add(span);
        }

        public IEnumerator<MdSpan> GetEnumerator() => m_Spans.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Spans.GetEnumerator();

        public override string ToString() => ToString(MdSerializationOptions.Default);

        public override string ToString(MdSerializationOptions options)
        {
            var stringBuilder = new StringBuilder();
            foreach (var span in Spans)
            {
                stringBuilder.Append(span.ToString(options));
            }
            return stringBuilder.ToString();
        }

        internal override MdSpan DeepCopy() => new MdCompositeSpan(m_Spans.Select(x => x.DeepCopy()));
    }
}
