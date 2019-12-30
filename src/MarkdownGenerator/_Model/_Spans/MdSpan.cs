using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represent a inline text element in a markdown document.
    /// </summary>
    public abstract class MdSpan
    {
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdSpan()
        { }


        // force re-implementation of ToString()
        /// <summary>
        /// Converts the span to a Markdown string.
        /// </summary>
        public abstract override string ToString();

        /// <summary>
        /// Converts the span to a Markdown string using the specified serialization options.
        /// </summary>
        public abstract string ToString(MdSerializationOptions? options);

        /// <summary>
        /// Recursively compares the span to the specified instance of <see cref="MdSpan"/>.
        /// </summary>
        public abstract bool DeepEquals(MdSpan? other);


        internal abstract MdSpan DeepCopy();

        internal abstract void Accept(ISpanVisitor visitor);


        /// <summary>
        /// Implicitly creates a <see cref="MdSpan"/> from a string.
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </summary>
        /// <remarks>
        /// Wraps a string in an instance of <see cref="MdTextSpan"/>.
        /// Although the nullable annotations do not indicate it, passing in <c>null</c> will return <c>null</c>.
        /// </remarks>
        /// <param name="text">The string value to wrap in a span.</param>
        //
        // The nullable annotations for this method should actually be:
        //
        //    [return: NotNullIfNotNull("text")]        
        //    public static implicit operator MdSpan?(string? text)
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
        public static implicit operator MdSpan(string? text) => text == null ? null! : new MdTextSpan(text);
    }
}
