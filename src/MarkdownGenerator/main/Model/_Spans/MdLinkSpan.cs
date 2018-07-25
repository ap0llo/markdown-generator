using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a link elememt
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
        /// The specified text will be escaped.
        /// </summary>
        /// <param name="text">The link's text. Value will be escaped.</param>
        /// <param name="uri">The link's target uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public MdLinkSpan(string text, string uri) : this(new MdTextSpan(text), new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdLinkSpan"/>.
        /// The specified text will be escaped.
        /// </summary>
        /// <param name="text">The link's text. Value will be escaped.</param>
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

        public override MdSpan Copy() => new MdLinkSpan(Text.Copy(), Uri);
    }
}
