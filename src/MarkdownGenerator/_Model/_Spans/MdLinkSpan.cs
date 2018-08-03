using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a link elememt.
    /// For specification see https://spec.commonmark.org/0.28/#links
    /// </summary>
    public sealed class MdLinkSpan : MdSpan
    {
        /// <summary>
        /// Gets the link's text
        /// </summary>
        public MdSpan Text { get; }

        /// <summary>
        /// Gets the link's target uri
        /// </summary>
        public Uri Uri { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdLinkSpan"/>.
        /// </summary>
        /// <param name="text">
        /// The link's text. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <param name="uri">The link's target uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public MdLinkSpan(string text, string uri) : this(new MdTextSpan(text), new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdLinkSpan"/>.
        /// </summary>
        /// <param name="text">
        /// The link's text. 
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <param name="uri">The link's target uri.</param>
        public MdLinkSpan(string text, Uri uri) : this(new MdTextSpan(text), uri)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdLinkSpan"/>.        
        /// </summary>
        /// <param name="text">The link's text.</param>
        /// <param name="uri">The link's target uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public MdLinkSpan(MdSpan text, string uri) : this(text, new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdLinkSpan"/>.        
        /// </summary>
        /// <param name="text">The link's text.</param>
        /// <param name="uri">The link's target uri.</param>
        public MdLinkSpan(MdSpan text, Uri uri)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }


        public override string ToString() => ToString(MdSerializationOptions.Default);

        public override string ToString(MdSerializationOptions options)
        {
            var text = Text.ToString(options);
            var uri = Uri.ToString();

            if (String.IsNullOrEmpty(text) && String.IsNullOrEmpty(uri))
            {
                return String.Empty;
            }
            else
            {
                return $"[{text}]({uri})";
            }
        }


        internal override MdSpan DeepCopy() => new MdLinkSpan(Text.DeepCopy(), Uri);
    }
}
