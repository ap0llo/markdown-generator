using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents emphasized/italic text
    /// </summary>
    public sealed class MdEmphasisSpan : MdSpan
    {
        /// <summary>
        /// Get the emphasized text element
        /// </summary>
        public MdSpan Text { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/>.
        /// The specified text will be escaped.
        /// </summary>
        public MdEmphasisSpan(string text) : this(new MdTextSpan(text))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        public MdEmphasisSpan(MdSpan text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }


        public override string ToString()
        {
            var text = Text.ToString();
            return String.IsNullOrEmpty(text) ? String.Empty : $"*{text}*";
        }

        internal override MdSpan DeepCopy() => new MdEmphasisSpan(Text.DeepCopy());
    }
}
