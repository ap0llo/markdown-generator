using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents strongly-emphasized/bold content
    /// </summary>
    public sealed class MdStrongEmphasisSpan : MdSpan
    {
        /// <summary>
        /// Get the emphasized text element
        /// </summary>
        public MdSpan Text { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdStrongEmphasisSpan"/>.
        /// The specified text will be escaped.
        /// </summary>
        /// <param name="text"></param>
        public MdStrongEmphasisSpan(string text) : this(new MdTextSpan(text))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content
        /// </summary>
        public MdStrongEmphasisSpan(MdSpan text) => 
            Text = text ?? throw new ArgumentNullException(nameof(text));


        public override string ToString()
        {
            var text = Text.ToString();
            return String.IsNullOrEmpty(text) ? String.Empty : $"**{Text}**";
        }

        public override string ToString(MdSerializationOptions options) => ToString();


        internal override MdSpan DeepCopy() => new MdStrongEmphasisSpan(Text.DeepCopy());
    }
}
