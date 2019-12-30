using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a link element.
    /// For specification see <see href="https://spec.commonmark.org/0.28/#links">CommonMark - Links</see>.
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


        /// <inheritdoc />
        public override string ToString() => ToString(MdSerializationOptions.Default);

        /// <inheritdoc />
        public override string ToString(MdSerializationOptions? options)
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

        /// <inheritdoc />
        public override bool DeepEquals(MdSpan? other) => DeepEquals(other as MdLinkSpan);


        internal override MdSpan DeepCopy() => new MdLinkSpan(Text.DeepCopy(), Uri);

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdLinkSpan? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Text.DeepEquals(other.Text) &&
                   Uri.Equals(other.Uri);
        }
    }
}
