﻿using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a span of raw Markdown content that will not be escaped before being written to the output
    /// </summary>
    public sealed class MdRawMarkdownSpan : MdSpan
    {
        /// <summary>
        /// Gets the element's content
        /// </summary>
        public string Content { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdRawMarkdownSpan"/>
        /// </summary>
        /// <param name="content">The span's content. The text will be written to the output without escaping.</param>
        public MdRawMarkdownSpan(string content) =>
            Content = content ?? throw new ArgumentNullException(nameof(content));


        public override string ToString() => Content;

        public override string ToString(MdSerializationOptions options) => ToString();

        public override bool DeepEquals(MdSpan other) => DeepEquals(other as MdRawMarkdownSpan);


        internal override MdSpan DeepCopy() => new MdRawMarkdownSpan(Content);


        private bool DeepEquals(MdRawMarkdownSpan other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return StringComparer.Ordinal.Equals(Content, other.Content);
        }
    }
}
