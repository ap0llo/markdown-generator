using System;

namespace Grynwald.MarkdownGenerator
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
        /// <param name="text">
        /// The text to emphasize. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        public MdStrongEmphasisSpan(string text) : this(new MdTextSpan(text))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdStrongEmphasisSpan"/> with the specified content
        /// </summary>
        /// <param name="text">The text to emphasize.</param>
        public MdStrongEmphasisSpan(MdSpan text) => 
            Text = text ?? throw new ArgumentNullException(nameof(text));


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

            return $"{emphasisChar}{emphasisChar}{text}{emphasisChar}{emphasisChar}";
        }

        internal override MdSpan DeepCopy() => new MdStrongEmphasisSpan(Text.DeepCopy());       
    }
}
