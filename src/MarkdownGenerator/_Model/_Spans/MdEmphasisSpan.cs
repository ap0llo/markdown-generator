using System;
using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents emphasized/italic text
    /// For specification see <see href="https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis">CommonMark - Emphasis and strong emphasis</see>.
    /// </summary>
    /// <seealso cref="MdStrongEmphasisSpan"/>
    /// <seealso cref="MdEmphasisStyle" />
    public sealed class MdEmphasisSpan : MdSpan
    {
        /// <summary>
        /// Get the emphasized text element
        /// </summary>
        public MdSpan Text { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/>.
        /// </summary>
        /// <param name="text">
        /// The text to emphasize.
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        public MdEmphasisSpan(string text) : this(new MdTextSpan(text))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public MdEmphasisSpan(MdCompositeSpan text) : this((MdSpan)text)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public MdEmphasisSpan(MdSpan text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public MdEmphasisSpan(params MdSpan[] text) : this(text.Join())
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/> with the specified content.
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public MdEmphasisSpan(IEnumerable<MdSpan> text) : this(text.Join())
        { }


        /// <inheritdoc />
        public override string ToString() => ToString(MdSerializationOptions.Default);

        /// <inheritdoc />
        public override string ToString(MdSerializationOptions? options)
        {
            options ??= MdSerializationOptions.Default;

            var text = Text.ToString(options);

            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            char emphasisChar;          
            switch (options.EmphasisStyle)
            {
                case MdEmphasisStyle.Asterisk:
                    emphasisChar = '*';
                    break;
                case MdEmphasisStyle.Underscore:
                    emphasisChar = '_';
                    break;

                default:
                    throw new ArgumentException($"Unsupported value: {options.EmphasisStyle}", nameof(options.EmphasisStyle));
            }

            return $"{emphasisChar}{text}{emphasisChar}";
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdSpan? other) => DeepEquals(other as MdEmphasisSpan);


        internal override MdSpan DeepCopy() => new MdEmphasisSpan(Text.DeepCopy());

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdEmphasisSpan? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Text.DeepEquals(other.Text);
        }
    }
}
