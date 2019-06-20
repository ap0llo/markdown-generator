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
        /// <inheritdoc />
        public abstract override string ToString();

        public abstract string ToString(MdSerializationOptions options);

        public abstract bool DeepEquals(MdSpan other);


        internal abstract MdSpan DeepCopy();

        internal abstract void Accept(ISpanVisitor visitor);


        /// <summary>
        /// Implicitly creates a <see cref="MdSpan"/> from a string.
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/> and thus be escaped in the output.
        /// </summary>
        /// <param name="text">The string value to wrap in a span.</param>
        public static implicit operator MdSpan(string text) => text == null ? null : new MdTextSpan(text);
    }
}
