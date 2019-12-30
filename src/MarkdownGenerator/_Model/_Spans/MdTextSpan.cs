using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents an (unformatted) text element which's content will be
    /// escaped before being written to the output
    /// </summary>
    public sealed class MdTextSpan : MdSpan
    {
        /// <summary>
        /// Gets the element's content.
        /// The value will be escaped before being written to the output.
        /// </summary>
        public string Text { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="MdTextSpan"/>
        /// </summary>
        /// <param name="text">The element's content. The value will be escaped before being written to the output.</param>
        public MdTextSpan(string text) =>
            Text = text ?? throw new ArgumentNullException(nameof(text));

        /// <inheritdoc />
        public override string ToString() => ToString(MdSerializationOptions.Default);

        /// <inheritdoc />
        public override string ToString(MdSerializationOptions? options)
        {
            options ??= MdSerializationOptions.Default;

            var escaper = options.TextFormatter ?? DefaultTextFormatter.Instance;
            return escaper.EscapeText(Text);
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdSpan? other) => DeepEquals(other as MdTextSpan);


        internal override MdSpan DeepCopy() => new MdTextSpan(Text);

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);


        private bool DeepEquals(MdTextSpan? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return StringComparer.Ordinal.Equals(Text, other.Text);
        }

        /// <summary>
        /// Implicitly creates a <see cref="MdTextSpan"/> from a string.
        /// </summary>
        /// <remarks>
        /// Wraps a string in an instance of <see cref="MdTextSpan"/>.
        /// Although the nullable annotations do not indicate it, passing in <c>null</c> will return <c>null</c>.
        /// </remarks>
        /// <param name="text">The string value to wrap in an instance of <see cref="MdTextSpan"/></param>
        //
        // The nullable annotations for this method should actually be:
        //
        //    [return: NotNullIfNotNull("text")]        
        //    public static implicit operator MdTextSpan?(string? text)
        //
        // However, this is not possible, because Roslyn currently does not recognize the NotNullIfNotNull attribute
        // for user-defined operators (see https://github.com/dotnet/roslyn/issues/39802).
        // Because of this, the nullable annotation for the return type is omitted even though the conversion might return null.
        // Marking the return value as nullable would mean that the compiler assumes a nullable
        // return value for all conversions from string (including conversions from literals)
        // which would mean the return value cannot be passed to any method requiring a non-null MdSpan.
        // The NotNullIfNotNull attribute would solve that, but as long as it does not work for operators
        // this workaround will have to do.
        //
        public static implicit operator MdTextSpan(string? text) => text == null ? null! : new MdTextSpan(text);
    }
}
