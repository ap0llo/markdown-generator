using System;
using System.Text;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents an (unformatted) text element which's content will be
    /// escaped before being written to the output
    /// </summary>
    public sealed class MdTextSpan : MdSpan
    {
        /// <summary>
        /// Gets the element's content.
        /// The value will be escaped before being written to the output.
        /// </summary>
        public string Text { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdTextSpan"/>
        /// </summary>
        /// <param name="text">The element's content. The value will be escaped before being written to the output.</param>
        public MdTextSpan(string text) =>
            Text = text ?? throw new ArgumentNullException(nameof(text));

        /// <inheritdoc />
        public override string ToString() => ToString(MdSerializationOptions.Default);

        /// <inheritdoc />
        public override string ToString(MdSerializationOptions options)
        {
            var escaper = options.TextFormatter ?? DefaultTextFormatter.Instance;
            return escaper.EscapeText(Text);
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdSpan other) => DeepEquals(other as MdTextSpan);


        internal override MdSpan DeepCopy() => new MdTextSpan(Text);

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdTextSpan other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return StringComparer.Ordinal.Equals(Text, other.Text);
        }

        /// <summary>
        /// Implicitly creates a <see cref="MdTextSpan"/> from a string.
        /// </summary>
        /// <param name="text">The string value to wrap in an instance of <see cref="MdTextSpan"/></param>
        public static implicit operator MdTextSpan(string text) => text == null ? null : new MdTextSpan(text);
    }
}
