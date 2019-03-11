using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents emphasized/italic text
    /// For specification see https://spec.commonmark.org/0.28/#emphasis-and-strong-emphasis
    /// </summary>
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
        /// Initializes a new instance of <see cref="MdEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public MdEmphasisSpan(MdSpan text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }


        public override string ToString() => ToString(MdSerializationOptions.Default);

        public override string ToString(MdSerializationOptions options)
        {
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

        public override bool DeepEquals(MdSpan other) => DeepEquals(other as MdEmphasisSpan);


        internal override MdSpan DeepCopy() => new MdEmphasisSpan(Text.DeepCopy());

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdEmphasisSpan other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Text.DeepEquals(other.Text);
        }
    }
}
