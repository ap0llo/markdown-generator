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


        public override string ToString() => ToString(MdEmphasisStyle.Asterisk);
       
        public override string ToString(MdSerializationOptions options) => ToString(options.EmphasisStyle);        


        internal override MdSpan DeepCopy() => new MdEmphasisSpan(Text.DeepCopy());

        private string ToString(MdEmphasisStyle style)
        {
            var text = Text.ToString();

            if(String.IsNullOrEmpty(text))
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

            return $"{emphasisChar}{text}{emphasisChar}";
        }
    }
}
