using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a thematic break.
    /// For specification see <see href="https://spec.commonmark.org/0.28/#thematic-breaks">CommonMark - Thematic breaks</see>.
    /// </summary>
    /// <seealso cref="MdThematicBreakStyle"/>
    public sealed class MdThematicBreak : MdLeafBlock
    {
        /// <inheritdoc />
        public override bool DeepEquals(MdBlock? other) => other is MdThematicBreak;

        /// <inheritdoc />
        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
