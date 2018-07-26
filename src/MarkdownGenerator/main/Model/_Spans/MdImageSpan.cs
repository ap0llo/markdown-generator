using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents an inline image element
    /// </summary>
    public sealed class MdImageSpan : MdSpan
    {
        /// <summary>
        /// Gets the image's description
        /// </summary>
        public MdSpan Description { get; }

        /// <summary>
        /// Gets the image's uri
        /// </summary>
        public Uri Uri { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdImageSpan"/>. 
        /// The specified description will be escaped.
        /// </summary>
        /// <param name="description">The image's description. The content will be escaped.</param>
        /// <param name="uri">The image's uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public MdImageSpan(string description, string uri) : this(new MdTextSpan(description), new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdImageSpan"/>. 
        /// The specified description will be escaped.
        /// </summary>
        /// <param name="description">The image's description. The content will be escaped.</param>
        /// <param name="uri">The image's uri</param>
        public MdImageSpan(string description, Uri uri) : this(new MdTextSpan(description), uri)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdImageSpan"/>. 
        /// </summary>
        /// <param name="description">The image's description</param>
        /// <param name="uri">The image's uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public MdImageSpan(MdSpan description, string uri) : this(description, new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdImageSpan"/>. 
        /// </summary>
        /// <param name="description">The image's description</param>
        /// <param name="uri">The image's uri</param>
        public MdImageSpan(MdSpan description, Uri uri)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }


        public override string ToString() => $"![{Description}]({Uri})";


        internal override MdSpan DeepCopy() => new MdImageSpan(Description.DeepCopy(), Uri);
    }
}
