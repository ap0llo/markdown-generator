﻿using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents an inline image element
    /// For specification see <see href="https://spec.commonmark.org/0.28/#images">CommonMark - Images</see>.
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
        /// </summary>
        /// <param name="description">
        /// The image's description.
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
        /// <param name="uri">The image's uri. Value must be a valid absolute or relative <see cref="System.Uri"/></param>
        public MdImageSpan(string description, string uri) : this(new MdTextSpan(description), new Uri(uri, UriKind.RelativeOrAbsolute))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdImageSpan"/>.
        /// </summary>
        /// <param name="description">
        /// The image's description.
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </param>
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


        /// <inheritdoc />
        public override string ToString() => ToString(MdSerializationOptions.Default);

        /// <inheritdoc />
        public override string ToString(MdSerializationOptions? options)
        {
            var description = Description.ToString(options);
            var uri = Uri.ToString();

            if (String.IsNullOrEmpty(description) && String.IsNullOrEmpty(uri))
            {
                return String.Empty;
            }
            else
            {
                return $"![{description}]({uri})";
            }
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdSpan? other) => DeepEquals(other as MdImageSpan);


        internal override MdSpan DeepCopy() => new MdImageSpan(Description.DeepCopy(), Uri);

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdImageSpan? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Description.DeepEquals(other.Description) &&
                   Uri.Equals(other.Uri);
        }
    }
}
