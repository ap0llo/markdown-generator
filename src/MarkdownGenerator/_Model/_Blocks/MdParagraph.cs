using System;
using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a paragraph in a markdown document.
    /// For specification see https://spec.commonmark.org/0.28/#paragraphs
    /// </summary>
    public sealed class MdParagraph : MdLeafBlock
    {
        /// <summary>
        /// Gets the paragraph's text.
        /// </summary>
        public MdSpan Text { get; private set; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdParagraph"/> without any content.
        /// </summary>
        public MdParagraph()
        {
            Text = new MdCompositeSpan();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="text">The paragraph's content</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is <c>null</c>.</exception>
        public MdParagraph(MdSpan text)
        {
            if (text is MdCompositeSpan compositeSpan)
            {
                Text = compositeSpan;
            }
            else
            {
                Text = new MdCompositeSpan(text);
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="spans">
        /// One or more instances of <see cref="MdSpan"/>.
        /// As <see cref="MdParagraph"/> only supports a single span instance as text,
        /// the spans will be wrapped in an instance of <see cref="MdCompositeSpan"/>.
        /// </param>
        /// <remarks>
        /// The content spans will be wrapped in a instance of <see cref="MdCompositeSpan"/>.
        /// Thus <c>new MdParagraph(span1, span2)</c> is equivalent to <c>new MdParagraph(new MdCompositeSpan(span1, span2))</c>
        /// </remarks>
        public MdParagraph(params MdSpan[] spans) : this((IEnumerable<MdSpan>)spans)
        { }

        public MdParagraph(IEnumerable<MdSpan> spans)
        {
            if (spans == null)
                throw new ArgumentNullException(nameof(spans));

            Text = new MdCompositeSpan(spans);
        }


        /// <summary>
        /// Adds the specified span to the paragraph
        /// </summary>
        /// <param name="span">The text element to add to the paragraph</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="span"/> is null</exception>
        public void Add(MdSpan span)
        {
            span = span ?? throw new ArgumentNullException(nameof(span));

            // append new content to composite span
            if(Text is MdCompositeSpan compositeSpan)
            {
                compositeSpan.Add(span);
            }
            // wrap current text into a composite span and append new span
            else
            {
                var newCompositeSpan = new MdCompositeSpan();
                newCompositeSpan.Add(Text);
                newCompositeSpan.Add(span);

                Text = newCompositeSpan;
            }
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => DeepEquals(other as MdParagraph);


        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdParagraph other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Text.DeepEquals(other.Text);
        }
    }
}
