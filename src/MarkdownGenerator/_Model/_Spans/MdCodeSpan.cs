using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a inline code span
    /// For specification see <see href="https://spec.commonmark.org/0.28/#code-spans">CommonMark - Code spans</see>.
    /// </summary>
    public sealed class MdCodeSpan : MdSpan
    {
        /// <summary>
        /// The code span's content. The value will not be escaped.
        /// </summary>
        public string Text { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdCodeSpan"/>
        /// </summary>
        /// <param name="text">The content of the code span. The value will not be escaped.</param>
        public MdCodeSpan(string text) =>
            Text = text ?? throw new ArgumentNullException(nameof(text));


        /// <inheritdoc />
        public override string ToString() => String.IsNullOrEmpty(Text) ? String.Empty : $"`{Text}`";

        /// <inheritdoc />
        public override string ToString(MdSerializationOptions? options) => ToString();

        /// <inheritdoc />
        public override bool DeepEquals(MdSpan? other) => DeepEquals(other as MdCodeSpan);


        internal override MdSpan DeepCopy() => new MdCodeSpan(Text);

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdCodeSpan? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return StringComparer.Ordinal.Equals(Text, other.Text);
        }
    }
}
