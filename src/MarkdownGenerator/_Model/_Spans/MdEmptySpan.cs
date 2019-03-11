using System;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents an empty text element.
    /// </summary>
    /// <remarks>
    /// Empty text elements have no effect on the output as they are serialized to <see cref="String.Empty"/>
    /// </remarks>
    public sealed class MdEmptySpan : MdSpan
    {
        /// <summary>
        /// Gets the default instance of <see cref="MdEmptySpan"/>
        /// </summary>
        public static readonly MdEmptySpan Instance = new MdEmptySpan();


        private MdEmptySpan()
        { }


        public override string ToString() => String.Empty;

        public override string ToString(MdSerializationOptions options) => String.Empty;

        public override bool DeepEquals(MdSpan other) => ReferenceEquals(this, other);


        internal override MdSpan DeepCopy() => Instance;

        internal override void Accept(ISpanVisitor visitor) => visitor.Visit(this);
    }
}
