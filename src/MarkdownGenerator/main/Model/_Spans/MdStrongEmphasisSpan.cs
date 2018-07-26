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


        public override string ToString() => ToString(MdEmphasisStyle.Asterisk);

        public override string ToString(MdSerializationOptions options) => ToString(options.EmphasisStyle);


        internal override MdSpan DeepCopy() => new MdStrongEmphasisSpan(Text.DeepCopy());


        private string ToString(MdEmphasisStyle style)
        {
            var text = Text.ToString();

            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            char emphasisChar;
            switch (style)
            {
                case MdEmphasisStyle.Asterisk:
                    emphasisChar = '*';
                    break;
                case MdEmphasisStyle.Underscore:
                    emphasisChar = '_';
                    break;

                default:
                    throw new ArgumentException($"Unsupported value: {style}", nameof(style));
            }

            return $"{emphasisChar}{emphasisChar}{text}{emphasisChar}{emphasisChar}";
        }
    }
}
