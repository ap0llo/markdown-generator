using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a paragraph in a markdown document.
    /// For specification see https://spec.commonmark.org/0.28/#paragraphs
    /// </summary>
    public sealed class MdParagraph : MdLeafBlock
    {
        /// <summary>
        /// Gets the paragraph's text
        /// </summary>
        public MdSpan Text { get; private set; }


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
        public MdParagraph(params MdSpan[] spans) : this(new MdCompositeSpan(spans))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdParagraph"/> with the specified content.
        /// </summary>
        /// <param name="text">The paragraph's content</param>
        public MdParagraph(MdSpan text) =>
            Text = text ?? throw new ArgumentNullException(nameof(text));


        /// <summary>
        /// Adds the specified span to the paragraph
        /// </summary>
        /// <param name="span">The text element to add to the paragraph</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="span"/> is null</exception>
        public void Add(MdSpan span)
        {
            span = span ?? throw new ArgumentNullException(nameof(span));

            if(Text is MdCompositeSpan compositeSpan)
            {
                compositeSpan.Add(span);
            }
            else
            {
                Text = new MdCompositeSpan(Text) { span };
            }
        }

        public override bool DeepEquals(MdBlock other) => DeepEquals(other as MdParagraph);


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
