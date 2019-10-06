using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a list or inline-elements
    /// </summary>
    public sealed class MdCompositeSpan : MdSpan, IReadOnlyCollection<MdSpan>
    {
        private readonly List<MdSpan> m_Spans;

        /// <summary>
        /// Gets the composite spans inner spans
        /// </summary>
        public IReadOnlyList<MdSpan> Spans => m_Spans;

        /// <summary>
        /// Gets the number of spans in the composite span.
        /// </summary>
        /// <value>The number of spans in the composite span.</value>
        public int Count => m_Spans.Count;

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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="span"/> is <c>null</c>.</exception>
        public void Add(MdSpan span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            m_Spans.Add(span);
        }

        /// <summary>
        /// Inserts a span at the specified index.
        /// </summary>
        /// <param name="index">The index (zero-based) index to insert the cell at.</param>
        /// <param name="span">The span to insert.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="span"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is negative of greater than the number of columns in the row.</exception>
        public void Insert(int index, MdSpan span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            if (index < 0 || index > m_Spans.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            m_Spans.Insert(index, span);
        }


        /// <summary>
        /// Returns an enumerator that iterates through the composite span's inner spans.
        /// </summary>
        public IEnumerator<MdSpan> GetEnumerator() => m_Spans.GetEnumerator();

        /// <summary>
        /// Returns an (non-generic) enumerator that iterates through the composite span's inner spans.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => m_Spans.GetEnumerator();

        /// <inheritdoc />
        public override string ToString() => ToString(MdSerializationOptions.Default);

        /// <inheritdoc />
        public override string ToString(MdSerializationOptions options)
        {
            var stringBuilder = new StringBuilder();
            foreach (var span in Spans)
            {
                stringBuilder.Append(span.ToString(options));
            }
            return stringBuilder.ToString();
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdSpan other) => DeepEquals(other as MdCompositeSpan);


        internal override MdSpan DeepCopy() => new MdCompositeSpan(m_Spans.Select(x => x.DeepCopy()));

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdCompositeSpan other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (m_Spans.Count != other.m_Spans.Count)
                return false;

            for (int i = 0; i < m_Spans.Count; i++)
            {
                if (!m_Spans[i].DeepEquals(other.m_Spans[i]))
                    return false;
            }

            return true;
        }
    }
}
